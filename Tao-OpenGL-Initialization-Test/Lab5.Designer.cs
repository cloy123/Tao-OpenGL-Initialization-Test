namespace Tao_OpenGL_Initialization_Test
{
    partial class Lab5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.anT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.PointInGrap = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // anT
            // 
            this.anT.AccumBits = ((byte)(0));
            this.anT.AutoCheckErrors = false;
            this.anT.AutoFinish = false;
            this.anT.AutoMakeCurrent = true;
            this.anT.AutoSwapBuffers = true;
            this.anT.BackColor = System.Drawing.Color.Black;
            this.anT.ColorBits = ((byte)(32));
            this.anT.DepthBits = ((byte)(16));
            this.anT.Location = new System.Drawing.Point(12, 12);
            this.anT.Name = "anT";
            this.anT.Size = new System.Drawing.Size(940, 594);
            this.anT.StencilBits = ((byte)(0));
            this.anT.TabIndex = 0;
            this.anT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.anT_MouseMove);
            // 
            // PointInGrap
            // 
            this.PointInGrap.Interval = 30;
            this.PointInGrap.Tick += new System.EventHandler(this.PointInGrap_Tick);
            // 
            // Lab5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 618);
            this.Controls.Add(this.anT);
            this.Name = "Lab5";
            this.Text = "Lab5";
            this.Load += new System.EventHandler(this.Lab5_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl anT;
        private System.Windows.Forms.Timer PointInGrap;
    }
}