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
    public partial class FormShift : Form
    {
        public int ShiftAmount
        {
            get
            {
                return (Convert.ToInt32(txtShiftAmount.Text, 10));
            }
            set { txtShiftAmount.Text = value.ToString(); }
        }

        public FormShift()
        {
            InitializeComponent();
        }
    }
}
