namespace ImageProcessingMyWork
{
    partial class FormShift
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
            this.btnShift = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.txtShiftAmount = new System.Windows.Forms.TextBox();
            this.btnShiftCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShift
            // 
            this.btnShift.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnShift.Location = new System.Drawing.Point(73, 48);
            this.btnShift.Name = "btnShift";
            this.btnShift.Size = new System.Drawing.Size(72, 23);
            this.btnShift.TabIndex = 0;
            this.btnShift.Text = "Shift";
            this.btnShift.UseVisualStyleBackColor = true;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(27, 25);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(94, 13);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Shift (e.g 20 or -5 )";
            // 
            // txtShiftAmount
            // 
            this.txtShiftAmount.Location = new System.Drawing.Point(127, 22);
            this.txtShiftAmount.Name = "txtShiftAmount";
            this.txtShiftAmount.Size = new System.Drawing.Size(100, 20);
            this.txtShiftAmount.TabIndex = 2;
            // 
            // btnShiftCancel
            // 
            this.btnShiftCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnShiftCancel.Location = new System.Drawing.Point(155, 48);
            this.btnShiftCancel.Name = "btnShiftCancel";
            this.btnShiftCancel.Size = new System.Drawing.Size(72, 23);
            this.btnShiftCancel.TabIndex = 3;
            this.btnShiftCancel.Text = "Cancel";
            this.btnShiftCancel.UseVisualStyleBackColor = true;
            // 
            // FormShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 93);
            this.Controls.Add(this.btnShiftCancel);
            this.Controls.Add(this.txtShiftAmount);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnShift);
            this.Name = "FormShift";
            this.Text = "FormShift";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShift;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtShiftAmount;
        private System.Windows.Forms.Button btnShiftCancel;
    }
}