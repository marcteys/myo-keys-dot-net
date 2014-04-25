using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//MYO
using Thalmic.Myo;


namespace myo_key_dot_net
{
    public partial class MainForm : Form
    {
        //MYO stuff

        private Hub _hub;
        private Thalmic.Myo.Myo _myo;


        public MainForm()
        {
            InitializeComponent();
        }

        private void test_Click(object sender, EventArgs e)
        {
           SendKeys.Send("{Left}");
        }

    }
}
