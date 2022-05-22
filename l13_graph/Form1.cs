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

namespace l13_graph
{
    public partial class Form1 : Form
    {
        private double angle;

        int vertex = 0;    // идентификатор вершинного шейдера
        int fragment = 0;  // идентификатор фрагментного шейдера
        int program = 0;   // идентификатор программного объекта

        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
            Init();
            Resize(simpleOpenGlControl1.Width, simpleOpenGlControl1.Height);
            LoadShadrers();
        }
        private static bool Init()
        {
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glShadeModel(Gl.GL_SMOOTH);

            Gl.glEnable(Gl.GL_DEPTH_TEST);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT,
                      Gl.GL_NICEST);

            return true;
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

        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();

            Gl.glTranslated(1.0, -1.0, 1.0);
            Gl.glRotated(angle, 0.0, 1.0, 0.0);

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

                Gl.glColor3d(0.0, 1.0, 1.0);
                Gl.glVertex3d(0, 0, 0);
                Gl.glVertex3d(1, 1, 1);
            Gl.glEnd();


            /*Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();

            Gl.glTranslated(0.0, -0.5, -4.0);
            Gl.glRotated(angle, 0.0, 1.0, 0.0);

            Gl.glColor3d(0.0, 1.0, 0.0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-1, -0.5, -1);
            Gl.glVertex3d(1, -0.5, -1);
            Gl.glVertex3d(1, -0.5, 1);
           *//* Gl.glVertex3d(-1, -0.5, 1);
            Gl.glVertex3d(2, 1.5, 2);*//*
            Gl.glVertex3d(-4, 1.5, 2);
            Gl.glEnd();

            Gl.glTranslated(0.0, 1.0, 0.0);

            Gl.glUseProgram(program);

            Gl.glColor3d(1.0, 0.0, 1.0);
            Glu.GLUquadric q = Glu.gluNewQuadric();
            Glu.gluSphere(q, 0.5, 50, 50);
            Glu.gluDeleteQuadric(q);

            Gl.glUseProgram(0);


            *//*Gl.glColor3d(1.0, 0.2, 0.5);
            Glu.GLUquadric q = Glu.gluNewQuadric();
            Glu.gluSphere(q, 0.5, 50, 50);
            Glu.gluDeleteQuadric(q);*//*

            Gl.glFlush();*/
        }
        private void TimerTick(object sender, EventArgs e)
        {
            angle += 1.0;
            simpleOpenGlControl1.Invalidate();
        }
        private void OpenGlControlPaint(object sender, PaintEventArgs e)
        {
            Draw();
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
    }
}
