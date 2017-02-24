using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingMyWork
{
    public partial class FormRoatate : Form
    {
        public int Rotate
        {
            get
            {
                return int.Parse(txtRotate.Text);
            }
            set { txtRotate.Text = value.ToString(); }
        }

        public FormRoatate()
        {
            InitializeComponent();
        }
    }
}
