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



    /* NEXT STUFF TO DO
     * 
     * Add the possibility of key combinaison (see e.KeyData)
     * 
     * 
     * 
     * 
     * */
    public partial class MainForm : Form
    {
        //MYO stuff

        private Hub _hub;
        private Thalmic.Myo.Myo _myo;
        public ulong _mac;

        bool startSending = false;
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
            else if (startSending)
            {

            
                 // logStatus(e.Pose.ToString());
                // Debug.WriteLine(e.Pose.ToString());


                 /* To improve :
                  * 
                  * Create an enum with all the pose. When we click on a checkbox, we enable or disable the pose.
                  * All the data (key, vibration) are stored in an object. 
                  * This code just detect if the pose is enabled and then plays it
                  * All the variables are stored in the ENUMs. Verify proprely like this method
                  * //if (e.Pose == Pose.FingersSpread)
                  *     {
                  *    this._myo.Vibrate(VibrationType.Medium);
                  *  }
                  * 
                  * */

                 // Get all CheckBox in the scene (get checked state)

                 var cb = GetAll(this, typeof(CheckBox));
                 foreach (CheckBox tmbcb in cb)
                 {
                     if (tmbcb.Checked && tmbcb.Tag.ToString() == e.Pose.ToString())
                     {

                         //Get all TextBox in the scene (get the key)
                         var tb = GetAll(this, typeof(TextBox));
                         foreach (TextBox tmptb in tb)
                         {
                             if (tmptb.Tag.ToString() == e.Pose.ToString())
                             {
                                 string t = "{" + tmptb.Text + "}";
                                 if (tmptb.Text == string.Empty) t = "{ENTER}";

                                 Debug.WriteLine(t);
                                 SendKeys.SendWait(t);

                                 //Get all Combo box in the scene (get vibration type)
                                 var combo = GetAll(this, typeof(ComboBox));
                                 foreach (ComboBox tmpcombo in combo)
                                 {
                                     if (tmpcombo.Tag.ToString() == e.Pose.ToString())
                                     {
                                        //!\ Threading problems !
                                       //  Debug.WriteLine(tmpcombo.SelectedIndex);
                                         return;
                                     }
                                 }
                                 return;
                             }
                         }
                         return;
                     } 
                 }

              
            }
        }

      

      
        private void logStatus(string message)
        {
            ThreadHelperClass.appendText(this, this.logLabel, message + " ");
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
                btnStart.Enabled = true;
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

        private void assignKey(object sender, PreviewKeyDownEventArgs e)
        {

            
            TextBox thisTextBox = (TextBox)sender;
            thisTextBox.ReadOnly = true;
            thisTextBox.Text = string.Empty;
            string key = filterKey(e.KeyCode.ToString());


            thisTextBox.Text = key;
            
            logStatus("Set a new key : " +e.KeyCode.ToString());
        }

       
     
        private void textBox_Clear(object sender, EventArgs e)
        {
            TextBox thisTextBox = (TextBox)sender;
            thisTextBox.Text = string.Empty;
        }

        public string filterKey(string k)
        {
            if (k.Length > 1)
            {
                k = k.ToUpper();
            }
            else
            {
                k = k.ToLower();
            }
            if (k == "BACK")
            {
                k = "BACKSPACE";
            }
            else if (k == "RETURN")
            {
                k = "ENTER";
            }
            else if (k == "CAPITAL")
            {
                k = "CAPSLOCK";
            }
            else if (k == "SPACE")
            {
                k = " ";
            }

            return k;

        }

        private void startSend(object sender, EventArgs e)
        {
            if (startSending)
            {
                 btnStart.Text = "Start";
                 startSending = false;
                 logStatus("Stop sending keys.");
            }
            else
            {
                btnStart.Text = "Stop";
                startSending = true;
                logStatus("Start sending keys.");

            }
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
