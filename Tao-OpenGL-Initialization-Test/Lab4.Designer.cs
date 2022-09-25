namespace Tao_OpenGL_Initialization_Test
{
    partial class Lab4
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
            this.btnOut = new System.Windows.Forms.Button();
            this.btnVisualize = new System.Windows.Forms.Button();
            this.anT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.trackBarA = new System.Windows.Forms.TrackBar();
            this.trackBarB = new System.Windows.Forms.TrackBar();
            this.trackBarC = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelA = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarC)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(749, 130);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(225, 55);
            this.btnOut.TabIndex = 11;
            this.btnOut.Text = "Выйти";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnVisualize
            // 
            this.btnVisualize.Location = new System.Drawing.Point(749, 43);
            this.btnVisualize.Name = "btnVisualize";
            this.btnVisualize.Size = new System.Drawing.Size(225, 63);
            this.btnVisualize.TabIndex = 10;
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
            this.anT.Location = new System.Drawing.Point(3, 21);
            this.anT.Name = "anT";
            this.anT.Size = new System.Drawing.Size(686, 658);
            this.anT.StencilBits = ((byte)(0));
            this.anT.TabIndex = 9;
            // 
            // trackBarA
            // 
            this.trackBarA.Location = new System.Drawing.Point(749, 257);
            this.trackBarA.Maximum = 1000;
            this.trackBarA.Name = "trackBarA";
            this.trackBarA.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarA.Size = new System.Drawing.Size(80, 422);
            this.trackBarA.TabIndex = 12;
            this.trackBarA.TickFrequency = 10;
            this.trackBarA.Value = 1000;
            this.trackBarA.Scroll += new System.EventHandler(this.trackBarA_Scroll);
            // 
            // trackBarB
            // 
            this.trackBarB.Location = new System.Drawing.Point(851, 257);
            this.trackBarB.Maximum = 1000;
            this.trackBarB.Name = "trackBarB";
            this.trackBarB.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarB.Size = new System.Drawing.Size(80, 422);
            this.trackBarB.TabIndex = 13;
            this.trackBarB.TickFrequency = 10;
            this.trackBarB.Scroll += new System.EventHandler(this.trackBarB_Scroll);
            // 
            // trackBarC
            // 
            this.trackBarC.Location = new System.Drawing.Point(973, 257);
            this.trackBarC.Maximum = 1000;
            this.trackBarC.Name = "trackBarC";
            this.trackBarC.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarC.Size = new System.Drawing.Size(80, 422);
            this.trackBarC.TabIndex = 14;
            this.trackBarC.TickFrequency = 10;
            this.trackBarC.Scroll += new System.EventHandler(this.trackBarC_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(754, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(979, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "C";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(858, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "B";
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(754, 682);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(23, 25);
            this.labelA.TabIndex = 18;
            this.labelA.Text = "1";
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(983, 682);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(23, 25);
            this.labelC.TabIndex = 19;
            this.labelC.Text = "0";
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(858, 682);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(23, 25);
            this.labelB.TabIndex = 20;
            this.labelB.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Interval = 25;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Lab4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 750);
            this.Controls.Add(this.labelB);
            this.Controls.Add(this.labelC);
            this.Controls.Add(this.labelA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarC);
            this.Controls.Add(this.trackBarB);
            this.Controls.Add(this.trackBarA);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnVisualize);
            this.Controls.Add(this.anT);
            this.Name = "Lab4";
            this.Text = "Lab4";
            this.Load += new System.EventHandler(this.Lab4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnVisualize;
        private Tao.Platform.Windows.SimpleOpenGlControl anT;
        private System.Windows.Forms.TrackBar trackBarA;
        private System.Windows.Forms.TrackBar trackBarB;
        private System.Windows.Forms.TrackBar trackBarC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Timer timer1;
    }
}