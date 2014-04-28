using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

//MYO
using Thalmic.Myo;


namespace myo_key_dot_net
{


    public partial class MainForm : Form
    {
        //MYO stuff

        private Hub _hub;
        private Thalmic.Myo.Myo _myo;
        public ulong _mac;

        /* to do : declare array (checkbox, etc) here */

        public MainForm()
        {
            InitializeComponent();

        }

        private void hub_MyoPaired(object sender, MyoEventArgs e)
        {
            if (this._myo == null)
            {
                this._myo = e.Myo;
                this._mac = e.Myo.MacAddress;
                this._myo.PoseChange += new EventHandler<PoseEventArgs>(this.myo_PoseChanged);
                this._myo.Vibrate(VibrationType.Medium);
            }
        }


        private void myo_PoseChanged(object sender, PoseEventArgs e)
        {
            if (e.Pose == Pose.None)
            {
              
            }
            else
            {
                 logStatus(e.Pose.ToString());
                // Debug.WriteLine(e.Pose.ToString());


                /* To improve :
                 * 
                 * Create an enum with all the pose. When we click on a checkbox, we enable or disable the pose.
                 * All the data (key, vibration) are stored in an object. 
                 * This code just detect if the pose is enabled and then plays it
                 * */

                 var cb = GetAll(this, typeof(CheckBox));


                 foreach (CheckBox tmbcb in cb)
                 {
                     if (tmbcb.Checked && tmbcb.Tag.ToString() == e.Pose.ToString())
                     {

                         var tb = GetAll(this, typeof(TextBox));
                         foreach (TextBox tmptb in tb)
                         {
                             Debug.WriteLine(tmptb.Tag.ToString() + " " + e.Pose.ToString());

                             if (tmptb.Tag.ToString() == e.Pose.ToString())
                             {
                                 Debug.WriteLine(tmptb.Text);

                                 //SendKeys.SendWait("{" + tmptb.Text + "}");
                                 return;
                             }
                         }
                         return;
                     } 
                 }
               

                

                 //  SendKeys.SendWait("{RETURN}");

                //if (e.Pose == Pose.FingersSpread)
                // {
                //    this._myo.Vibrate(VibrationType.Medium);
                //  }
            }
        }

      

        private void test_Click(object sender, EventArgs e)
        {

         //   logStatus("lol");

        }

        private void logStatus(string message)
        {

          //  logLabel.Text = message;
        }

        private void connect_Click(object sender, EventArgs e)
        {

        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;

            // These are done because the Myo doesn't disconnect properly
            // so you have to try and create the Hub twice
            try
            {
                this._hub = new Hub();
                logStatus("Ready");
            }
            catch { }

            try
            {
                if (this._hub == null)
                {
                    this._hub = new Hub();
                    logStatus("Ready");

                }

                this._hub.Paired += new EventHandler<MyoEventArgs>(this.hub_MyoPaired);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Please ensure the dongle is connected and not in use by another application. If you continue to receive this message, unplug the dongle and plug it back in.", "Unable to connect to Bluetooth dongle");
            }

            if (this._hub != null)
            {
                if (this._mac != 0)
                {
                    this._hub.PairByMacAddress(this._mac);
                }
                else
                {
                    this._hub.PairWithAnyMyo();
                }
                logStatus("Myo device found");
            }
            else
            {
                btnConnect.Enabled = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        /*
        private void enablePose(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text = String.Empty;
                }
            }

        }
        */
        private void checkKeyValue(object sender, EventArgs e)
        {
            var tb = GetAll(this, typeof(TextBox));
            CheckBox thiscb  = (CheckBox)sender;

            foreach (TextBox tmptb in tb)
            {
                if (tmptb.Tag.ToString() == thiscb.Tag.ToString() && tmptb.Text == "type...")
                {
                    tmptb.Text = string.Empty;
                    ActiveControl = tmptb;
                    return;
                }

            }
        }

        private void assignKey(object sender, KeyPressEventArgs e)
        {
            Keys k = (Keys)char.ToUpper(e.KeyChar);
            TextBox thisTextBox = (TextBox)sender;

            thisTextBox.ReadOnly = true;
            thisTextBox.Text = string.Empty;
            thisTextBox.Text = k.ToString();

            logStatus(k.ToString());
        }

        private void textBox_Clear(object sender, EventArgs e)
        {
            TextBox thisTextBox = (TextBox)sender;
            thisTextBox.Text = string.Empty;
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

    }




}
