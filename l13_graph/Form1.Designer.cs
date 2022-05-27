
namespace l13_graph
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblX = new System.Windows.Forms.Label();
            this.trackX = new System.Windows.Forms.TrackBar();
            this.trackY = new System.Windows.Forms.TrackBar();
            this.lblY = new System.Windows.Forms.Label();
            this.trackZ = new System.Windows.Forms.TrackBar();
            this.lblZ = new System.Windows.Forms.Label();
            this.cbRotate = new System.Windows.Forms.CheckBox();
            this.btnImage = new System.Windows.Forms.Button();
            this.openImage = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZ)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // simpleOpenGlControl1
            // 
            this.simpleOpenGlControl1.AccumBits = ((byte)(0));
            this.simpleOpenGlControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleOpenGlControl1.AutoCheckErrors = false;
            this.simpleOpenGlControl1.AutoFinish = false;
            this.simpleOpenGlControl1.AutoMakeCurrent = true;
            this.simpleOpenGlControl1.AutoSwapBuffers = true;
            this.simpleOpenGlControl1.BackColor = System.Drawing.Color.Black;
            this.simpleOpenGlControl1.ColorBits = ((byte)(32));
            this.simpleOpenGlControl1.DepthBits = ((byte)(16));
            this.simpleOpenGlControl1.Location = new System.Drawing.Point(12, 12);
            this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(763, 538);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 0;
            this.simpleOpenGlControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.OpenGlControlPaint);
            this.simpleOpenGlControl1.Resize += new System.EventHandler(this.simpleOpenGlControl1_Resize);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.TimerTick);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(14, 21);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(14, 13);
            this.lblX.TabIndex = 1;
            this.lblX.Text = "X";
            // 
            // trackX
            // 
            this.trackX.LargeChange = 2;
            this.trackX.Location = new System.Drawing.Point(17, 37);
            this.trackX.Name = "trackX";
            this.trackX.Size = new System.Drawing.Size(147, 45);
            this.trackX.TabIndex = 2;
            this.trackX.Scroll += new System.EventHandler(this.trackX_Scroll);
            // 
            // trackY
            // 
            this.trackY.LargeChange = 2;
            this.trackY.Location = new System.Drawing.Point(17, 116);
            this.trackY.Name = "trackY";
            this.trackY.Size = new System.Drawing.Size(147, 45);
            this.trackY.TabIndex = 4;
            this.trackY.Scroll += new System.EventHandler(this.trackY_Scroll);
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(14, 100);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(14, 13);
            this.lblY.TabIndex = 3;
            this.lblY.Text = "Y";
            // 
            // trackZ
            // 
            this.trackZ.LargeChange = 2;
            this.trackZ.Location = new System.Drawing.Point(17, 187);
            this.trackZ.Name = "trackZ";
            this.trackZ.Size = new System.Drawing.Size(147, 45);
            this.trackZ.TabIndex = 6;
            this.trackZ.Scroll += new System.EventHandler(this.trackZ_Scroll);
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(14, 171);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(14, 13);
            this.lblZ.TabIndex = 5;
            this.lblZ.Text = "Z";
            // 
            // cbRotate
            // 
            this.cbRotate.AutoSize = true;
            this.cbRotate.Location = new System.Drawing.Point(26, 255);
            this.cbRotate.Name = "cbRotate";
            this.cbRotate.Size = new System.Drawing.Size(71, 17);
            this.cbRotate.TabIndex = 7;
            this.cbRotate.Text = "Вращать";
            this.cbRotate.UseVisualStyleBackColor = true;
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(26, 293);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(89, 23);
            this.btnImage.TabIndex = 8;
            this.btnImage.Text = "Изображение";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // openImage
            // 
            this.openImage.FileName = "openImage";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.trackZ);
            this.panel1.Controls.Add(this.btnImage);
            this.panel1.Controls.Add(this.lblX);
            this.panel1.Controls.Add(this.cbRotate);
            this.panel1.Controls.Add(this.trackX);
            this.panel1.Controls.Add(this.lblY);
            this.panel1.Controls.Add(this.lblZ);
            this.panel1.Controls.Add(this.trackY);
            this.panel1.Location = new System.Drawing.Point(796, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 538);
            this.panel1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZ)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.TrackBar trackX;
        private System.Windows.Forms.TrackBar trackY;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.TrackBar trackZ;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.CheckBox cbRotate;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.OpenFileDialog openImage;
        private System.Windows.Forms.Panel panel1;
    }
}

