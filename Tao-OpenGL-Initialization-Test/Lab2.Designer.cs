namespace Tao_OpenGL_Initialization_Test
{
    partial class Lab2
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
            this.btnOut = new System.Windows.Forms.Button();
            this.btnVisualize = new System.Windows.Forms.Button();
            this.anT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.SuspendLayout();
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(786, 210);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(225, 55);
            this.btnOut.TabIndex = 5;
            this.btnOut.Text = "Выйти";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnVisualize
            // 
            this.btnVisualize.Location = new System.Drawing.Point(786, 106);
            this.btnVisualize.Name = "btnVisualize";
            this.btnVisualize.Size = new System.Drawing.Size(225, 63);
            this.btnVisualize.TabIndex = 4;
            this.btnVisualize.Text = "Визуализировать";
            this.btnVisualize.UseVisualStyleBackColor = true;
            this.btnVisualize.Click += new System.EventHandler(this.btnVisualize_Click);
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
            this.anT.Size = new System.Drawing.Size(728, 477);
            this.anT.StencilBits = ((byte)(0));
            this.anT.TabIndex = 3;
            // 
            // Lab2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 537);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnVisualize);
            this.Controls.Add(this.anT);
            this.Name = "Lab2";
            this.Text = "Lab2";
            this.Load += new System.EventHandler(this.Lab2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnVisualize;
        private Tao.Platform.Windows.SimpleOpenGlControl anT;
    }
}