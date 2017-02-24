using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingMyWork
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
            this.picOrigImage = new System.Windows.Forms.PictureBox();
            this.picProcImage = new System.Windows.Forms.PictureBox();
            this.lbImageUnderTest = new System.Windows.Forms.Label();
            this.lblWidthOrig = new System.Windows.Forms.Label();
            this.lblHeightOrig = new System.Windows.Forms.Label();
            this.txtWidthOrig = new System.Windows.Forms.TextBox();
            this.txtHeightOrig = new System.Windows.Forms.TextBox();
            this.lblWidthProcImage = new System.Windows.Forms.Label();
            this.txtWidthProcImage = new System.Windows.Forms.TextBox();
            this.lblHeightProcImage = new System.Windows.Forms.Label();
            this.txtHeightImage = new System.Windows.Forms.TextBox();
            this.lblOrigMousePointer = new System.Windows.Forms.Label();
            this.lblOrigWidthMousePoint = new System.Windows.Forms.Label();
            this.txtOrigMouseWidthPoint = new System.Windows.Forms.TextBox();
            this.lblOrigHeightMousePoint = new System.Windows.Forms.Label();
            this.txtOrigHeightMousePoint = new System.Windows.Forms.TextBox();
            this.lblProcPinMousePoint = new System.Windows.Forms.Label();
            this.txtProcHeightMousePoint = new System.Windows.Forms.TextBox();
            this.lblYProcMousePoint = new System.Windows.Forms.Label();
            this.txtProcWidthMousePoint = new System.Windows.Forms.TextBox();
            this.lblProcdthMousePoint = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.converyToGreyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.virticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateResizeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyFiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplacianMaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avgMaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianMaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picOrigImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picOrigImage
            // 
            this.picOrigImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOrigImage.Location = new System.Drawing.Point(13, 93);
            this.picOrigImage.Name = "picOrigImage";
            this.picOrigImage.Size = new System.Drawing.Size(448, 443);
            this.picOrigImage.TabIndex = 0;
            this.picOrigImage.TabStop = false;
            this.picOrigImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picOrigImage_MouseDown);
            this.picOrigImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picOrigImage_MouseUp);
            // 
            // picProcImage
            // 
            this.picProcImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProcImage.Location = new System.Drawing.Point(478, 93);
            this.picProcImage.Name = "picProcImage";
            this.picProcImage.Size = new System.Drawing.Size(481, 443);
            this.picProcImage.TabIndex = 1;
            this.picProcImage.TabStop = false;
            // 
            // lbImageUnderTest
            // 
            this.lbImageUnderTest.AutoSize = true;
            this.lbImageUnderTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbImageUnderTest.Location = new System.Drawing.Point(814, 33);
            this.lbImageUnderTest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbImageUnderTest.Name = "lbImageUnderTest";
            this.lbImageUnderTest.Size = new System.Drawing.Size(2, 15);
            this.lbImageUnderTest.TabIndex = 21;
            // 
            // lblWidthOrig
            // 
            this.lblWidthOrig.AutoSize = true;
            this.lblWidthOrig.Location = new System.Drawing.Point(117, 30);
            this.lblWidthOrig.Name = "lblWidthOrig";
            this.lblWidthOrig.Size = new System.Drawing.Size(18, 13);
            this.lblWidthOrig.TabIndex = 4;
            this.lblWidthOrig.Text = "W";
            // 
            // lblHeightOrig
            // 
            this.lblHeightOrig.AutoSize = true;
            this.lblHeightOrig.Location = new System.Drawing.Point(120, 57);
            this.lblHeightOrig.Name = "lblHeightOrig";
            this.lblHeightOrig.Size = new System.Drawing.Size(15, 13);
            this.lblHeightOrig.TabIndex = 5;
            this.lblHeightOrig.Text = "H";
            // 
            // txtWidthOrig
            // 
            this.txtWidthOrig.Location = new System.Drawing.Point(141, 26);
            this.txtWidthOrig.Name = "txtWidthOrig";
            this.txtWidthOrig.Size = new System.Drawing.Size(33, 20);
            this.txtWidthOrig.TabIndex = 6;
            // 
            // txtHeightOrig
            // 
            this.txtHeightOrig.Location = new System.Drawing.Point(141, 54);
            this.txtHeightOrig.Name = "txtHeightOrig";
            this.txtHeightOrig.Size = new System.Drawing.Size(33, 20);
            this.txtHeightOrig.TabIndex = 7;
            // 
            // lblWidthProcImage
            // 
            this.lblWidthProcImage.AutoSize = true;
            this.lblWidthProcImage.Location = new System.Drawing.Point(555, 33);
            this.lblWidthProcImage.Name = "lblWidthProcImage";
            this.lblWidthProcImage.Size = new System.Drawing.Size(18, 13);
            this.lblWidthProcImage.TabIndex = 23;
            this.lblWidthProcImage.Text = "W";
            // 
            // txtWidthProcImage
            // 
            this.txtWidthProcImage.Location = new System.Drawing.Point(579, 30);
            this.txtWidthProcImage.Name = "txtWidthProcImage";
            this.txtWidthProcImage.Size = new System.Drawing.Size(46, 20);
            this.txtWidthProcImage.TabIndex = 24;
            // 
            // lblHeightProcImage
            // 
            this.lblHeightProcImage.AutoSize = true;
            this.lblHeightProcImage.Location = new System.Drawing.Point(555, 57);
            this.lblHeightProcImage.Name = "lblHeightProcImage";
            this.lblHeightProcImage.Size = new System.Drawing.Size(15, 13);
            this.lblHeightProcImage.TabIndex = 25;
            this.lblHeightProcImage.Text = "H";
            // 
            // txtHeightImage
            // 
            this.txtHeightImage.Location = new System.Drawing.Point(579, 57);
            this.txtHeightImage.Name = "txtHeightImage";
            this.txtHeightImage.Size = new System.Drawing.Size(48, 20);
            this.txtHeightImage.TabIndex = 26;
            // 
            // lblOrigMousePointer
            // 
            this.lblOrigMousePointer.AutoSize = true;
            this.lblOrigMousePointer.Location = new System.Drawing.Point(12, 30);
            this.lblOrigMousePointer.Name = "lblOrigMousePointer";
            this.lblOrigMousePointer.Size = new System.Drawing.Size(75, 13);
            this.lblOrigMousePointer.TabIndex = 33;
            this.lblOrigMousePointer.Text = "Mouse Pointer";
            // 
            // lblOrigWidthMousePoint
            // 
            this.lblOrigWidthMousePoint.AutoSize = true;
            this.lblOrigWidthMousePoint.Location = new System.Drawing.Point(240, 33);
            this.lblOrigWidthMousePoint.Name = "lblOrigWidthMousePoint";
            this.lblOrigWidthMousePoint.Size = new System.Drawing.Size(14, 13);
            this.lblOrigWidthMousePoint.TabIndex = 34;
            this.lblOrigWidthMousePoint.Text = "X";
            // 
            // txtOrigMouseWidthPoint
            // 
            this.txtOrigMouseWidthPoint.Location = new System.Drawing.Point(273, 27);
            this.txtOrigMouseWidthPoint.Name = "txtOrigMouseWidthPoint";
            this.txtOrigMouseWidthPoint.Size = new System.Drawing.Size(33, 20);
            this.txtOrigMouseWidthPoint.TabIndex = 35;
            // 
            // lblOrigHeightMousePoint
            // 
            this.lblOrigHeightMousePoint.AutoSize = true;
            this.lblOrigHeightMousePoint.Location = new System.Drawing.Point(240, 57);
            this.lblOrigHeightMousePoint.Name = "lblOrigHeightMousePoint";
            this.lblOrigHeightMousePoint.Size = new System.Drawing.Size(14, 13);
            this.lblOrigHeightMousePoint.TabIndex = 36;
            this.lblOrigHeightMousePoint.Text = "Y";
            // 
            // txtOrigHeightMousePoint
            // 
            this.txtOrigHeightMousePoint.Location = new System.Drawing.Point(273, 57);
            this.txtOrigHeightMousePoint.Name = "txtOrigHeightMousePoint";
            this.txtOrigHeightMousePoint.Size = new System.Drawing.Size(33, 20);
            this.txtOrigHeightMousePoint.TabIndex = 37;
            // 
            // lblProcPinMousePoint
            // 
            this.lblProcPinMousePoint.AutoSize = true;
            this.lblProcPinMousePoint.Location = new System.Drawing.Point(445, 33);
            this.lblProcPinMousePoint.Name = "lblProcPinMousePoint";
            this.lblProcPinMousePoint.Size = new System.Drawing.Size(75, 13);
            this.lblProcPinMousePoint.TabIndex = 38;
            this.lblProcPinMousePoint.Text = "Mouse Pointer";
            // 
            // txtProcHeightMousePoint
            // 
            this.txtProcHeightMousePoint.Location = new System.Drawing.Point(708, 57);
            this.txtProcHeightMousePoint.Name = "txtProcHeightMousePoint";
            this.txtProcHeightMousePoint.Size = new System.Drawing.Size(33, 20);
            this.txtProcHeightMousePoint.TabIndex = 39;
            // 
            // lblYProcMousePoint
            // 
            this.lblYProcMousePoint.AutoSize = true;
            this.lblYProcMousePoint.Location = new System.Drawing.Point(686, 57);
            this.lblYProcMousePoint.Name = "lblYProcMousePoint";
            this.lblYProcMousePoint.Size = new System.Drawing.Size(14, 13);
            this.lblYProcMousePoint.TabIndex = 40;
            this.lblYProcMousePoint.Text = "Y";
            // 
            // txtProcWidthMousePoint
            // 
            this.txtProcWidthMousePoint.Location = new System.Drawing.Point(706, 27);
            this.txtProcWidthMousePoint.Name = "txtProcWidthMousePoint";
            this.txtProcWidthMousePoint.Size = new System.Drawing.Size(35, 20);
            this.txtProcWidthMousePoint.TabIndex = 41;
            // 
            // lblProcdthMousePoint
            // 
            this.lblProcdthMousePoint.AutoSize = true;
            this.lblProcdthMousePoint.Location = new System.Drawing.Point(686, 30);
            this.lblProcdthMousePoint.Name = "lblProcdthMousePoint";
            this.lblProcdthMousePoint.Size = new System.Drawing.Size(14, 13);
            this.lblProcdthMousePoint.TabIndex = 42;
            this.lblProcdthMousePoint.Text = "X";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.imageMoveToolStripMenuItem,
            this.resizeToolStripMenuItem,
            this.drawToolStripMenuItem,
            this.applyFiToolStripMenuItem,
            this.laplacianMaskToolStripMenuItem,
            this.sharpenToolStripMenuItem,
            this.blurrToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(971, 24);
            this.menuStrip1.TabIndex = 48;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.saveImageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.loadImageToolStripMenuItem.Text = "Load Image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.converyToGreyToolStripMenuItem,
            this.brightenToolStripMenuItem,
            this.contrastToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(92, 20);
            this.toolStripMenuItem1.Text = "Change Color";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // converyToGreyToolStripMenuItem
            // 
            this.converyToGreyToolStripMenuItem.Name = "converyToGreyToolStripMenuItem";
            this.converyToGreyToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.converyToGreyToolStripMenuItem.Text = "Convery To Grey";
            this.converyToGreyToolStripMenuItem.Click += new System.EventHandler(this.converyToGreyToolStripMenuItem_Click);
            // 
            // brightenToolStripMenuItem
            // 
            this.brightenToolStripMenuItem.Name = "brightenToolStripMenuItem";
            this.brightenToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.brightenToolStripMenuItem.Text = "Brighten";
            this.brightenToolStripMenuItem.Click += new System.EventHandler(this.brightenToolStripMenuItem_Click);
            // 
            // contrastToolStripMenuItem
            // 
            this.contrastToolStripMenuItem.Name = "contrastToolStripMenuItem";
            this.contrastToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.contrastToolStripMenuItem.Text = "Contrast";
            this.contrastToolStripMenuItem.Click += new System.EventHandler(this.contrastToolStripMenuItem_Click);
            // 
            // imageMoveToolStripMenuItem
            // 
            this.imageMoveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotationToolStripMenuItem,
            this.shiftToolStripMenuItem});
            this.imageMoveToolStripMenuItem.Name = "imageMoveToolStripMenuItem";
            this.imageMoveToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.imageMoveToolStripMenuItem.Text = "Image move";
            // 
            // rotationToolStripMenuItem
            // 
            this.rotationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.fillToolStripMenuItem});
            this.rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
            this.rotationToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.rotationToolStripMenuItem.Text = "Rotation";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // fillToolStripMenuItem
            // 
            this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            this.fillToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.fillToolStripMenuItem.Text = "Fill";
            this.fillToolStripMenuItem.Click += new System.EventHandler(this.fillToolStripMenuItem_Click);
            // 
            // shiftToolStripMenuItem
            // 
            this.shiftToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalToolStripMenuItem,
            this.virticalToolStripMenuItem});
            this.shiftToolStripMenuItem.Name = "shiftToolStripMenuItem";
            this.shiftToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.shiftToolStripMenuItem.Text = "Shift";
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // virticalToolStripMenuItem
            // 
            this.virticalToolStripMenuItem.Name = "virticalToolStripMenuItem";
            this.virticalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.virticalToolStripMenuItem.Text = "Virtical";
            this.virticalToolStripMenuItem.Click += new System.EventHandler(this.virticalToolStripMenuItem_Click);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeImageToolStripMenuItem,
            this.rotateResizeImageToolStripMenuItem});
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.resizeToolStripMenuItem.Text = "Resize";
            // 
            // resizeImageToolStripMenuItem
            // 
            this.resizeImageToolStripMenuItem.Name = "resizeImageToolStripMenuItem";
            this.resizeImageToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.resizeImageToolStripMenuItem.Text = "Resize Image";
            this.resizeImageToolStripMenuItem.Click += new System.EventHandler(this.resizeImageToolStripMenuItem_Click);
            // 
            // rotateResizeImageToolStripMenuItem
            // 
            this.rotateResizeImageToolStripMenuItem.Name = "rotateResizeImageToolStripMenuItem";
            this.rotateResizeImageToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.rotateResizeImageToolStripMenuItem.Text = "Rotate Resize image";
            this.rotateResizeImageToolStripMenuItem.Click += new System.EventHandler(this.rotateResizeImageToolStripMenuItem_Click);
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleToolStripMenuItem,
            this.drawXToolStripMenuItem});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.rectangleToolStripMenuItem_Click);
            // 
            // drawXToolStripMenuItem
            // 
            this.drawXToolStripMenuItem.Name = "drawXToolStripMenuItem";
            this.drawXToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.drawXToolStripMenuItem.Text = "DrawX";
            this.drawXToolStripMenuItem.Click += new System.EventHandler(this.drawXToolStripMenuItem_Click);
            // 
            // applyFiToolStripMenuItem
            // 
            this.applyFiToolStripMenuItem.Name = "applyFiToolStripMenuItem";
            this.applyFiToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.applyFiToolStripMenuItem.Text = "Apply Filter";
            this.applyFiToolStripMenuItem.Click += new System.EventHandler(this.applyFiToolStripMenuItem_Click);
            // 
            // laplacianMaskToolStripMenuItem
            // 
            this.laplacianMaskToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem,
            this.bToolStripMenuItem,
            this.cToolStripMenuItem});
            this.laplacianMaskToolStripMenuItem.Name = "laplacianMaskToolStripMenuItem";
            this.laplacianMaskToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.laplacianMaskToolStripMenuItem.Text = "Laplacian Mask";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aToolStripMenuItem.Text = "A";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // bToolStripMenuItem
            // 
            this.bToolStripMenuItem.Name = "bToolStripMenuItem";
            this.bToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bToolStripMenuItem.Text = "B";
            this.bToolStripMenuItem.Click += new System.EventHandler(this.bToolStripMenuItem_Click);
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cToolStripMenuItem.Text = "C";
            this.cToolStripMenuItem.Click += new System.EventHandler(this.cToolStripMenuItem_Click);
            // 
            // sharpenToolStripMenuItem
            // 
            this.sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            this.sharpenToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.sharpenToolStripMenuItem.Text = "Sharpen";
            this.sharpenToolStripMenuItem.Click += new System.EventHandler(this.sharpenToolStripMenuItem_Click);
            // 
            // blurrToolStripMenuItem
            // 
            this.blurrToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.avgMaskToolStripMenuItem,
            this.gaussianMaskToolStripMenuItem});
            this.blurrToolStripMenuItem.Name = "blurrToolStripMenuItem";
            this.blurrToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.blurrToolStripMenuItem.Text = "Blurr";
            // 
            // avgMaskToolStripMenuItem
            // 
            this.avgMaskToolStripMenuItem.Name = "avgMaskToolStripMenuItem";
            this.avgMaskToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.avgMaskToolStripMenuItem.Text = "3*3 Avg mask";
            this.avgMaskToolStripMenuItem.Click += new System.EventHandler(this.avgMaskToolStripMenuItem_Click);
            // 
            // gaussianMaskToolStripMenuItem
            // 
            this.gaussianMaskToolStripMenuItem.Name = "gaussianMaskToolStripMenuItem";
            this.gaussianMaskToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gaussianMaskToolStripMenuItem.Text = "Gaussian Mask";
            this.gaussianMaskToolStripMenuItem.Click += new System.EventHandler(this.gaussianMaskToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 549);
            this.Controls.Add(this.lblProcdthMousePoint);
            this.Controls.Add(this.txtProcWidthMousePoint);
            this.Controls.Add(this.lblYProcMousePoint);
            this.Controls.Add(this.txtProcHeightMousePoint);
            this.Controls.Add(this.lblProcPinMousePoint);
            this.Controls.Add(this.txtOrigHeightMousePoint);
            this.Controls.Add(this.lblOrigHeightMousePoint);
            this.Controls.Add(this.txtOrigMouseWidthPoint);
            this.Controls.Add(this.lblOrigWidthMousePoint);
            this.Controls.Add(this.lblOrigMousePointer);
            this.Controls.Add(this.txtHeightImage);
            this.Controls.Add(this.lblHeightProcImage);
            this.Controls.Add(this.txtWidthProcImage);
            this.Controls.Add(this.lblWidthProcImage);
            this.Controls.Add(this.txtHeightOrig);
            this.Controls.Add(this.txtWidthOrig);
            this.Controls.Add(this.lblHeightOrig);
            this.Controls.Add(this.lblWidthOrig);
            this.Controls.Add(this.lbImageUnderTest);
            this.Controls.Add(this.picProcImage);
            this.Controls.Add(this.picOrigImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picOrigImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picOrigImage;
        private System.Windows.Forms.PictureBox picProcImage;
        private System.Windows.Forms.Label lbImageUnderTest;
        private System.Windows.Forms.Label lblWidthOrig;
        private System.Windows.Forms.Label lblHeightOrig;
        private System.Windows.Forms.TextBox txtWidthOrig;
        private System.Windows.Forms.TextBox txtHeightOrig;
        private System.Windows.Forms.Label lblWidthProcImage;
        private System.Windows.Forms.TextBox txtWidthProcImage;
        private System.Windows.Forms.Label lblHeightProcImage;
        private System.Windows.Forms.TextBox txtHeightImage;
        private System.Windows.Forms.Label lblOrigMousePointer;
        private System.Windows.Forms.Label lblOrigWidthMousePoint;
        private System.Windows.Forms.TextBox txtOrigMouseWidthPoint;
        private System.Windows.Forms.Label lblOrigHeightMousePoint;
        private System.Windows.Forms.TextBox txtOrigHeightMousePoint;
        private System.Windows.Forms.Label lblProcPinMousePoint;
        private System.Windows.Forms.TextBox txtProcHeightMousePoint;
        private System.Windows.Forms.Label lblYProcMousePoint;
        private System.Windows.Forms.TextBox txtProcWidthMousePoint;
        private System.Windows.Forms.Label lblProcdthMousePoint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem converyToGreyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageMoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shiftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem virticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateResizeImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyFiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplacianMaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avgMaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussianMaskToolStripMenuItem;
    }
}

