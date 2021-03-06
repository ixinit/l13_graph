using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.DevIl;

namespace l13_graph
{
    public partial class Form1 : Form
    {
        private double angle;
        bool changeAngle = false;

        int vertex = 0;    // идентификатор вершинного шейдера
        int fragment = 0;  // идентификатор фрагментного шейдера
        int program = 0;   // идентификатор программного объекта

        // движение камеры
        double tX, tY, tZ;
        int minXYZ = -5000;
        int maxXYZ = 5000;
        int modToDouble = 1000;

        // тектура из изображения
        private int imageId;
        private uint mGlTextureObject;
        private bool textureIsLoad;

        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
            Init();
            Resize(simpleOpenGlControl1.Width, simpleOpenGlControl1.Height);
            //LoadShadrers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackX.Minimum = minXYZ;
            trackX.Maximum = maxXYZ;
            tX = 0;
            trackX.Value = 0;

            trackY.Minimum = minXYZ;
            trackY.Maximum = maxXYZ;
            tY = -0.2;
            trackY.Value = -200;

            trackZ.Minimum = minXYZ;
            trackZ.Maximum = maxXYZ;
            tZ = -0.6;
            trackZ.Value = -600;
        }

        private static bool Init()
        {
            //инициализация glut
            Glut.glutInit();

            // инициализация библиотеки openIL
            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            // инициализация Gl
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glShadeModel(Gl.GL_SMOOTH);

            Gl.glEnable(Gl.GL_DEPTH_TEST);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT,
                      Gl.GL_NICEST);

            return true;
        }

        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();

            Gl.glTranslated(tX, tY, tZ);
            
            Gl.glRotated(angle, 0, 1.0, 0);

            Gl.glBegin(Gl.GL_LINES);
                Gl.glColor3d(1.0, 0.0, 0.0);
                Gl.glVertex3d(0, 0, 0);
                Gl.glVertex3d(5, 0, 0);

                Gl.glColor3d(0.0, 1.0, 0.0);
                Gl.glVertex3d(0, 0, 0);
                Gl.glVertex3d(0, 5, 0);

                Gl.glColor3d(0.0, 0.0, 1.0);
                Gl.glVertex3d(0, 0, 0);
                Gl.glVertex3d(0, 0, 5);

                /*Gl.glColor3d(0.0, 1.0, 1.0);
                Gl.glVertex3d(0, 0, 0);
                Gl.glVertex3d(1, 1, 1);*/
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
                Gl.glColor3d(0.5, 0.5, 0.0);
                Gl.glVertex3d(1, 1, 0);
                Gl.glVertex3d(1, -1, 0);
                Gl.glVertex3d(-1, -1, 0);
                Gl.glVertex3d(-1, 1, 0);
            Gl.glEnd();
            
            if (textureIsLoad)
            {
                // включаем режим текстурирования
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                // включаем режим текстурирования , указывая индификатор mGlTextureObject
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject);

                // текстурирование для сферы
                Gl.glTexGeni(Gl.GL_S, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_SPHERE_MAP);
                Gl.glTexGeni(Gl.GL_T, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_SPHERE_MAP);

                // включение текстурирования для сферы
                Gl.glEnable(Gl.GL_TEXTURE_GEN_S);
                Gl.glEnable(Gl.GL_TEXTURE_GEN_T);

                // рисование и удаление обькта сферы
                Glu.GLUquadric q = Glu.gluNewQuadric();
                Glu.gluSphere(q, 0.2, 50, 50);
                Glu.gluDeleteQuadric(q);

                // отключение текстурирования сферы
                Gl.glDisable(Gl.GL_TEXTURE_GEN_S);
                Gl.glDisable(Gl.GL_TEXTURE_GEN_T);

                // отключаем режим текстурирования
                Gl.glDisable(Gl.GL_TEXTURE_2D);
            }
        }

        private void OpenGlControlPaint(object sender, PaintEventArgs e)
        {
            Draw();
        }

        private static void Resize(int width, int height)
        {
            if (height == 0)
            {
                height = 1;
            }

            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, width / (double)height, 0.1, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (changeAngle)
            {
                angle += 1.0;
            }
            simpleOpenGlControl1.Invalidate();
        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            Resize(simpleOpenGlControl1.Width, simpleOpenGlControl1.Height);
        }

        private void LoadShadrers()
        {
            vertex = Gl.glCreateShader(Gl.GL_VERTEX_SHADER);
            fragment = Gl.glCreateShader(Gl.GL_FRAGMENT_SHADER);
            StreamReader sr = new StreamReader("triangle.vs");
            Gl.glShaderSource(vertex, 1,
                              new string[] { sr.ReadToEnd() }, null);
            sr.Close();

            sr = new StreamReader("triangle.fs");
            Gl.glShaderSource(fragment, 1,
                              new string[] { sr.ReadToEnd() }, null);
            sr.Close();


            Gl.glAttachShader(program, vertex);
            Gl.glAttachShader(program, fragment);
            Gl.glLinkProgram(program);
            sr = null;
            GC.Collect();

        }

        private void trackX_Scroll(object sender, EventArgs e)
        {
            tX = (double)trackX.Value / modToDouble;
            lblX.Text = "X: " + tX.ToString();
        }
        private void trackY_Scroll(object sender, EventArgs e)
        {
            tY = (double)trackY.Value / modToDouble;
            lblY.Text = "Y: " + tY.ToString();
        }
        private void trackZ_Scroll(object sender, EventArgs e)
        {
            tZ = (double)trackZ.Value / modToDouble;
            lblZ.Text = "Z: " + tZ.ToString();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            // открываем окно выбора файла
            DialogResult res = openImage.ShowDialog();

            // есл файл выбран - и возвращен результат OK
            if (res == DialogResult.OK)
            {
                // создаем изображение с индификатором imageId
                Il.ilGenImages(1, out imageId);
                // делаем изображение текущим
                Il.ilBindImage(imageId);

                // адрес изображения полученный с помощью окна выбра файла
                string url = openImage.FileName;

                // пробуем загрузить изображение
                if (Il.ilLoadImage(url))
                {
                    // если загрузка прошла успешно
                    // сохраняем размеры изображения
                    int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                    int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                    // определяем число бит на пиксель
                    int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);

                    switch (bitspp) // в зависимости оп полученного результата
                    {
                        // создаем текстуру используя режим GL_RGB или GL_RGBA
                        case 24:
                            mGlTextureObject = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                            break;
                        case 32:
                            mGlTextureObject = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                            break;
                    }

                    // активируем флаг, сигнализирующий загрузку текстуры
                    textureIsLoad = true;
                    // очищаем память
                    Il.ilDeleteImages(1, ref imageId);


                }
            }
        }

        private void cbRotate_CheckedChanged(object sender, EventArgs e)
        {
            changeAngle = !changeAngle;
        }

        // создание текстуры в панями openGL
        private static uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            // индетефекатор текстурного объекта
            uint texObject;

            // генерируем текстурный объект
            Gl.glGenTextures(1, out texObject);

            // устанавливаем режим упаковки пикселей
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);

            // создаем привязку к только что созданной текстуре
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);

            // устанавливаем режим фильтрации и повторения текстуры
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);

            // создаем RGB или RGBA текстуру
            switch (Format)
            {
                case Gl.GL_RGB:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
            }

            // возвращаем индетефекатор текстурного объекта

            return texObject;
        }
    }
}
