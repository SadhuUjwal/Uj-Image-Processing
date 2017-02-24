namespace ImageRegistrationBySURF
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
            this.btnLoadImages = new System.Windows.Forms.Button();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.btnSurfRansacMatch2 = new System.Windows.Forms.Button();
            this.picOut = new System.Windows.Forms.PictureBox();
            this.btnRegisterTwoImages = new System.Windows.Forms.Button();
            this.picReg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReg)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadImages
            // 
            this.btnLoadImages.Location = new System.Drawing.Point(12, 12);
            this.btnLoadImages.Name = "btnLoadImages";
            this.btnLoadImages.Size = new System.Drawing.Size(127, 49);
            this.btnLoadImages.TabIndex = 13;
            this.btnLoadImages.Text = "Load  Images";
            this.btnLoadImages.UseVisualStyleBackColor = true;
            this.btnLoadImages.Click += new System.EventHandler(this.btnLoadImages_Click);
            // 
            // pic2
            // 
            this.pic2.Location = new System.Drawing.Point(593, 12);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(431, 350);
            this.pic2.TabIndex = 17;
            this.pic2.TabStop = false;
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(157, 12);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(430, 350);
            this.pic1.TabIndex = 16;
            this.pic1.TabStop = false;
            // 
            // btnSurfRansacMatch2
            // 
            this.btnSurfRansacMatch2.Location = new System.Drawing.Point(12, 85);
            this.btnSurfRansacMatch2.Name = "btnSurfRansacMatch2";
            this.btnSurfRansacMatch2.Size = new System.Drawing.Size(127, 48);
            this.btnSurfRansacMatch2.TabIndex = 20;
            this.btnSurfRansacMatch2.Text = "SURF Ransac Match 2 Images";
            this.btnSurfRansacMatch2.UseVisualStyleBackColor = true;
            this.btnSurfRansacMatch2.Click += new System.EventHandler(this.btnSurfRansacMatch2_Click);
            // 
            // picOut
            // 
            this.picOut.Location = new System.Drawing.Point(157, 385);
            this.picOut.Name = "picOut";
            this.picOut.Size = new System.Drawing.Size(867, 350);
            this.picOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOut.TabIndex = 21;
            this.picOut.TabStop = false;
            // 
            // btnRegisterTwoImages
            // 
            this.btnRegisterTwoImages.Location = new System.Drawing.Point(12, 167);
            this.btnRegisterTwoImages.Name = "btnRegisterTwoImages";
            this.btnRegisterTwoImages.Size = new System.Drawing.Size(127, 51);
            this.btnRegisterTwoImages.TabIndex = 22;
            this.btnRegisterTwoImages.Text = "Register Two Images";
            this.btnRegisterTwoImages.UseVisualStyleBackColor = true;
            this.btnRegisterTwoImages.Click += new System.EventHandler(this.btnRegisterTwoImages_Click);
            // 
            // picReg
            // 
            this.picReg.Location = new System.Drawing.Point(1040, 12);
            this.picReg.Name = "picReg";
            this.picReg.Size = new System.Drawing.Size(430, 350);
            this.picReg.TabIndex = 23;
            this.picReg.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 765);
            this.Controls.Add(this.picReg);
            this.Controls.Add(this.btnRegisterTwoImages);
            this.Controls.Add(this.picOut);
            this.Controls.Add(this.btnSurfRansacMatch2);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.btnLoadImages);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadImages;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Button btnSurfRansacMatch2;
        private System.Windows.Forms.PictureBox picOut;
        private System.Windows.Forms.Button btnRegisterTwoImages;
        private System.Windows.Forms.PictureBox picReg;
    }
}

