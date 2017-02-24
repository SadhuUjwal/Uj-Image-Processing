namespace LBPFaceRecognition
{
    partial class Form1
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
            this.pbxSrc = new System.Windows.Forms.PictureBox();
            this.pbxMatched = new System.Windows.Forms.PictureBox();
            this.lblSrc = new System.Windows.Forms.Label();
            this.lblMatched = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnMatch = new System.Windows.Forms.Button();
            this.lblTrainedPath = new System.Windows.Forms.Label();
            this.txtTrainingPath = new System.Windows.Forms.TextBox();
            this.btnTrainingPath = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMatched)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxSrc
            // 
            this.pbxSrc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxSrc.Location = new System.Drawing.Point(18, 85);
            this.pbxSrc.Name = "pbxSrc";
            this.pbxSrc.Size = new System.Drawing.Size(269, 290);
            this.pbxSrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxSrc.TabIndex = 0;
            this.pbxSrc.TabStop = false;
            // 
            // pbxMatched
            // 
            this.pbxMatched.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxMatched.Location = new System.Drawing.Point(306, 85);
            this.pbxMatched.Name = "pbxMatched";
            this.pbxMatched.Size = new System.Drawing.Size(269, 290);
            this.pbxMatched.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxMatched.TabIndex = 2;
            this.pbxMatched.TabStop = false;
            // 
            // lblSrc
            // 
            this.lblSrc.AutoSize = true;
            this.lblSrc.Location = new System.Drawing.Point(18, 53);
            this.lblSrc.Name = "lblSrc";
            this.lblSrc.Size = new System.Drawing.Size(41, 13);
            this.lblSrc.TabIndex = 3;
            this.lblSrc.Text = "Source";
            // 
            // lblMatched
            // 
            this.lblMatched.AutoSize = true;
            this.lblMatched.Location = new System.Drawing.Point(316, 53);
            this.lblMatched.Name = "lblMatched";
            this.lblMatched.Size = new System.Drawing.Size(49, 13);
            this.lblMatched.TabIndex = 5;
            this.lblMatched.Text = "Matched";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(109, 381);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.OnSrcOpenClicked);
            // 
            // btnMatch
            // 
            this.btnMatch.Location = new System.Drawing.Point(400, 381);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(75, 23);
            this.btnMatch.TabIndex = 8;
            this.btnMatch.Text = "Match";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // lblTrainedPath
            // 
            this.lblTrainedPath.AutoSize = true;
            this.lblTrainedPath.Location = new System.Drawing.Point(18, 22);
            this.lblTrainedPath.Name = "lblTrainedPath";
            this.lblTrainedPath.Size = new System.Drawing.Size(70, 13);
            this.lblTrainedPath.TabIndex = 9;
            this.lblTrainedPath.Text = "Training Path";
            // 
            // txtTrainingPath
            // 
            this.txtTrainingPath.Location = new System.Drawing.Point(103, 19);
            this.txtTrainingPath.Name = "txtTrainingPath";
            this.txtTrainingPath.ReadOnly = true;
            this.txtTrainingPath.Size = new System.Drawing.Size(411, 20);
            this.txtTrainingPath.TabIndex = 10;
            // 
            // btnTrainingPath
            // 
            this.btnTrainingPath.Location = new System.Drawing.Point(520, 17);
            this.btnTrainingPath.Name = "btnTrainingPath";
            this.btnTrainingPath.Size = new System.Drawing.Size(33, 23);
            this.btnTrainingPath.TabIndex = 11;
            this.btnTrainingPath.Text = "...";
            this.btnTrainingPath.UseVisualStyleBackColor = true;
            this.btnTrainingPath.Click += new System.EventHandler(this.OnTrainingPathAdded);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 427);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(587, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 452);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnTrainingPath);
            this.Controls.Add(this.txtTrainingPath);
            this.Controls.Add(this.lblTrainedPath);
            this.Controls.Add(this.btnMatch);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lblMatched);
            this.Controls.Add(this.lblSrc);
            this.Controls.Add(this.pbxMatched);
            this.Controls.Add(this.pbxSrc);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbxSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMatched)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxSrc;
        private System.Windows.Forms.PictureBox pbxMatched;
        private System.Windows.Forms.Label lblSrc;
        private System.Windows.Forms.Label lblMatched;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.Label lblTrainedPath;
        private System.Windows.Forms.TextBox txtTrainingPath;
        private System.Windows.Forms.Button btnTrainingPath;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

