using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LBPFaceRecognition
{
    public partial class Form1 : Form
    {
        private ImageProcessor ip;

        private const string PATH = "TrainingPath";

        public Form1()
        {
            InitializeComponent();
            string value = ConfigurationManager.AppSettings[PATH];
            this.txtTrainingPath.Text = value;
            this.ip = new ImageProcessor(value);
            this.toolStripLabel1.Text = ip.IsTrained ? "Trained and Ready" : this.toolStripLabel1.Text = "Not Trained";
        }

        /// <summary>
        /// opens the new source image which need to searched in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSrcOpenClicked(object sender, EventArgs e)
        {
            //1. Open a file open browser and ask user for entering an Image
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.ShowDialog();
                if (string.IsNullOrEmpty(ofd.FileName))
                    return;
                this.pbxSrc.Image = Bitmap.FromFile(ofd.FileName);
            }
        }

        /// <summary>
        /// invokes the find method and finds the match for the source image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMatch_Click(object sender, EventArgs e)
        {
            var testBmp = new Bitmap(this.pbxSrc.Image);
            this.pbxMatched.Image = this.ip.GetMatchedImage(testBmp);
        }


        /// <summary>
        /// Event raised when training path add button clicked
        /// it will also show the path in the text box
        /// also save it to app settings for future use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTrainingPathAdded(object sender, EventArgs e)
        {
            if (!this.ip.IsTrained)
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    dlg.ShowNewFolderButton = false;
                    dlg.ShowDialog();
                    if (!string.IsNullOrEmpty(dlg.SelectedPath))
                    {
                        this.toolStripLabel1.Text = "Training";
                        this.txtTrainingPath.Text = dlg.SelectedPath;
                        this.SaveSettings();
                        this.ip.Train(this.txtTrainingPath.Text);
                        this.toolStripLabel1.Text = "Training Completed";
                    }
                }
        }

        /// <summary>
        /// Saves the training path to the app settings
        /// </summary>
        private void SaveSettings()
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Add an Application Setting.
            string value = this.txtTrainingPath.Text;
            config.AppSettings.Settings.Add(PATH, value);
            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection(PATH);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ip.IsTrained)
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    dlg.ShowNewFolderButton = false;
                    dlg.ShowDialog();
                    this.txtTestPath.Text = dlg.SelectedPath;
                }
        }

        private void btnRate_Click(object sender, EventArgs e)
        {
            int validRate = 0;
            string[] files = Directory.GetFiles(this.txtTestPath.Text);
            foreach (var item in files)
            {
                string matchedFile = this.ip.GetMatchedImageFile(item);
                bool valid = this.GetFirstPart(item) == this.GetFirstPart(matchedFile);
                if (valid)
                    validRate++;
            }

            int totFiles = files.Length;
            double rate = (validRate * 100) / totFiles;
            this.txtRate.Text = rate.ToString();
        }

        private string GetFirstPart(string name)
        {
            string firstPart = string.Empty;
            string[] parts = Path.GetFileNameWithoutExtension(name).Split('_');
            if (parts != null && parts.Length != 0)
                firstPart = parts[0].ToLower();
            return firstPart;
        }

        private void txtTrainingPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
