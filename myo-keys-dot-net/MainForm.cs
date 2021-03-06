﻿using System;
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


namespace myo_keys_dot_net
{

    /* NEXT STUFF TO DO
     * 
     * Add the possibility of key combinaison (see e.KeyData)
     * Use Input simulator ? http://inputsimulator.codeplex.com/
     * 
     * */
    public partial class MainForm : Form
    {
        //MYO stuff

        private Hub _hub;
        private Thalmic.Myo.Myo _myo;
        public ulong _mac;

        bool startSending = false;
        bool validationGesture = false;
        int validationVal = 0;

        /* to do : declare array (checkbox, etc) here [ GetAll(this, typeof(CheckBox)); ] */

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
                this._myo.Vibrate(VibrationType.Short);
            }
        }


        private void myo_PoseChanged(object sender, PoseEventArgs e)
        {

            if (e.Pose == Pose.None)
            {

            }
            else
            {
                //If the validation is not set AND the validation gesture is not "None" AND the validationVal equals the current pose
                if (!validationGesture && (Thalmic.Myo.Pose)validationVal != 0 && (Thalmic.Myo.Pose)validationVal == e.Pose && startSending)
                {
                     validationGesture = true;
                
                      var gestureVibrationVal = (int)3;
                       //use invoke to read the comboBox value
                      this.Invoke(new MethodInvoker(delegate() { gestureVibrationVal = vibrationValidation.SelectedIndex; }));
                      this._myo.Vibrate((VibrationType)gestureVibrationVal);

                     logStatus("Validation gesture detected (" + e.Pose + "), ready to send key.");
                     return;
                }

                //if the validation gesture is set OR the validation pose is None
                if(validationGesture || (Thalmic.Myo.Pose)validationVal == 0 && startSending)
                {

                     // Detect the pose for the first time there is a validation gesture
                    //Use invoke to read the validationGestureBox value (threading problem...)
              
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
                                     if (tmptb.Text == " ") t = " ";

                                     try {
                                         SendKeys.SendWait(t);
                                         logStatus("Pose detected : " + e.Pose.ToString() + " | Send key : " + tmptb.Text);

                                     } catch (Exception ex){
                                         logStatus("Error : Keycode not detected");
                                         return;
                                     }

                                     //Reset the validation Gesture
                                     validationGesture = false;

                                     //Get all Combo box in the scene (get vibration type)
                                     var combo = GetAll(this, typeof(ComboBox));
                                     foreach (ComboBox tmpcombo in combo)
                                     {
                                         if (tmpcombo.Tag.ToString() == e.Pose.ToString())
                                         {
                                            //!\ Threading problems !
                                           var val = (int)3;
                                             //use invoke to read the comboBox value
                                           this.Invoke(new MethodInvoker(delegate() { val = tmpcombo.SelectedIndex; }));
                                           this._myo.Vibrate((VibrationType)val);
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
                else if (!validationGesture && startSending)
                {
                    logStatus("Do the validation gesture first. (Detected " + e.Pose + ")");
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
                ActiveControl = btnStart;
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
                //MessageBox.Show("Please ensure the dongle is connected and not in use by another application. If you continue to receive this message, unplug the dongle and plug it back in.", "Unable to connect to Bluetooth dongle");
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
                logStatus("Myo device connected. Ready to send keys.");
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
                else if (k == "CONTROLKEY")
                {
                    k = "^";
                }
                else if (k == "SHIFTKEY")
                {
                    k = "+";
                }
                else if (k == "MENU")
                {
                    k = "%";
                }
                else if (k == "PAGEUP")
                {
                    k = "PGUP";
                }
                else if (k == "PAGEDOWN")
                {
                    k = "PDDW";
                }
                else if (k == "ESCAPE")
                {
                    k = "ESC";
                }
            }
            else
            {
                k = k.ToLower();
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

        private void validatioGestureBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("IndexChanged");
            validationVal = validatioGestureBox.SelectedIndex;
            validationGesture = false;
            logStatus("New Validation gesture : " + (Thalmic.Myo.Pose)validationVal );
        }

        private void Main_Closing(object sender, FormClosingEventArgs e)
        {
            //two methods : Kill current process or  Environment.Exit(0);
            Process.GetCurrentProcess().Kill();;
            // Environment.Exit(0);
        }

        private void ExitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

    }




}
