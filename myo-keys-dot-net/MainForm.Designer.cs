namespace myo_keys_dot_net
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.logLabel = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.keyTwistIn = new System.Windows.Forms.TextBox();
            this.keyFingersSpread = new System.Windows.Forms.TextBox();
            this.keyWaveOut = new System.Windows.Forms.TextBox();
            this.keyWaveIn = new System.Windows.Forms.TextBox();
            this.keyFist = new System.Windows.Forms.TextBox();
            this.vibrationTwistIn = new System.Windows.Forms.ComboBox();
            this.vibrationFingersSpread = new System.Windows.Forms.ComboBox();
            this.vibrationWaveOut = new System.Windows.Forms.ComboBox();
            this.vibrationWaveIn = new System.Windows.Forms.ComboBox();
            this.vibrationFist = new System.Windows.Forms.ComboBox();
            this.vibrationValidation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.poseTwistIn = new System.Windows.Forms.CheckBox();
            this.poseFingersSpread = new System.Windows.Forms.CheckBox();
            this.poseWaveOut = new System.Windows.Forms.CheckBox();
            this.poseWaveIn = new System.Windows.Forms.CheckBox();
            this.poseFist = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.validatioGestureBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(7, 226);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(95, 13);
            this.logLabel.TabIndex = 2;
            this.logLabel.Text = "Ready to connect.";
            this.logLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(161, 202);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(110, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect Myo";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.validatioGestureBox);
            this.groupBox1.Controls.Add(this.keyTwistIn);
            this.groupBox1.Controls.Add(this.keyFingersSpread);
            this.groupBox1.Controls.Add(this.keyWaveOut);
            this.groupBox1.Controls.Add(this.keyWaveIn);
            this.groupBox1.Controls.Add(this.keyFist);
            this.groupBox1.Controls.Add(this.vibrationTwistIn);
            this.groupBox1.Controls.Add(this.vibrationFingersSpread);
            this.groupBox1.Controls.Add(this.vibrationWaveOut);
            this.groupBox1.Controls.Add(this.vibrationWaveIn);
            this.groupBox1.Controls.Add(this.vibrationFist);
            this.groupBox1.Controls.Add(this.vibrationValidation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.poseTwistIn);
            this.groupBox1.Controls.Add(this.poseFingersSpread);
            this.groupBox1.Controls.Add(this.poseWaveOut);
            this.groupBox1.Controls.Add(this.poseWaveIn);
            this.groupBox1.Controls.Add(this.poseFist);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 184);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // keyTwistIn
            // 
            this.keyTwistIn.Location = new System.Drawing.Point(113, 129);
            this.keyTwistIn.Name = "keyTwistIn";
            this.keyTwistIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.keyTwistIn.Size = new System.Drawing.Size(67, 20);
            this.keyTwistIn.TabIndex = 26;
            this.keyTwistIn.Tag = "TwistIn";
            this.keyTwistIn.Text = "type...";
            this.keyTwistIn.Click += new System.EventHandler(this.textBox_Clear);
            this.keyTwistIn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.assignKey);
            // 
            // keyFingersSpread
            // 
            this.keyFingersSpread.Location = new System.Drawing.Point(113, 103);
            this.keyFingersSpread.Name = "keyFingersSpread";
            this.keyFingersSpread.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.keyFingersSpread.Size = new System.Drawing.Size(67, 20);
            this.keyFingersSpread.TabIndex = 25;
            this.keyFingersSpread.Tag = "FingersSpread";
            this.keyFingersSpread.Text = "type...";
            this.keyFingersSpread.Click += new System.EventHandler(this.textBox_Clear);
            this.keyFingersSpread.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.assignKey);
            // 
            // keyWaveOut
            // 
            this.keyWaveOut.Location = new System.Drawing.Point(113, 76);
            this.keyWaveOut.Name = "keyWaveOut";
            this.keyWaveOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.keyWaveOut.Size = new System.Drawing.Size(67, 20);
            this.keyWaveOut.TabIndex = 24;
            this.keyWaveOut.Tag = "WaveOut";
            this.keyWaveOut.Text = "type...";
            this.keyWaveOut.Click += new System.EventHandler(this.textBox_Clear);
            this.keyWaveOut.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.assignKey);
            // 
            // keyWaveIn
            // 
            this.keyWaveIn.Location = new System.Drawing.Point(113, 49);
            this.keyWaveIn.Name = "keyWaveIn";
            this.keyWaveIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.keyWaveIn.Size = new System.Drawing.Size(67, 20);
            this.keyWaveIn.TabIndex = 23;
            this.keyWaveIn.Tag = "WaveIn";
            this.keyWaveIn.Text = "type...";
            this.keyWaveIn.Click += new System.EventHandler(this.textBox_Clear);
            this.keyWaveIn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.assignKey);
            // 
            // keyFist
            // 
            this.keyFist.Location = new System.Drawing.Point(113, 21);
            this.keyFist.Name = "keyFist";
            this.keyFist.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.keyFist.Size = new System.Drawing.Size(67, 20);
            this.keyFist.TabIndex = 5;
            this.keyFist.Tag = "Fist";
            this.keyFist.Text = "type...";
            this.keyFist.Click += new System.EventHandler(this.textBox_Clear);
            this.keyFist.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.assignKey);
            // 
            // vibrationTwistIn
            // 
            this.vibrationTwistIn.Cursor = System.Windows.Forms.Cursors.Default;
            this.vibrationTwistIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vibrationTwistIn.FormattingEnabled = true;
            this.vibrationTwistIn.Location = new System.Drawing.Point(186, 129);
            this.vibrationTwistIn.Name = "vibrationTwistIn";
            this.vibrationTwistIn.Size = new System.Drawing.Size(67, 21);
            this.vibrationTwistIn.TabIndex = 22;
            this.vibrationTwistIn.Tag = "TwistIn";
            //this.vibrationTwistIn.Enabled = false;
            this.vibrationTwistIn.DataSource = System.Enum.GetValues(typeof(Thalmic.Myo.VibrationType));

            // 
            // vibrationFingersSpread
            // 
            this.vibrationFingersSpread.Cursor = System.Windows.Forms.Cursors.Default;
            this.vibrationFingersSpread.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vibrationFingersSpread.FormattingEnabled = true;
            this.vibrationFingersSpread.Location = new System.Drawing.Point(186, 102);
            this.vibrationFingersSpread.Name = "vibrationFingersSpread";
            this.vibrationFingersSpread.Size = new System.Drawing.Size(67, 21);
            this.vibrationFingersSpread.TabIndex = 21;
            this.vibrationFingersSpread.Tag = "FingersSpread";
            //this.vibrationFingersSpread.Enabled = false;
            this.vibrationFingersSpread.DataSource = System.Enum.GetValues(typeof(Thalmic.Myo.VibrationType));

            // 
            // vibrationWaveOut
            // 
            this.vibrationWaveOut.Cursor = System.Windows.Forms.Cursors.Default;
            this.vibrationWaveOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vibrationWaveOut.FormattingEnabled = true;
            this.vibrationWaveOut.Location = new System.Drawing.Point(186, 75);
            this.vibrationWaveOut.Name = "vibrationWaveOut";
            this.vibrationWaveOut.Size = new System.Drawing.Size(67, 21);
            this.vibrationWaveOut.TabIndex = 20;
            this.vibrationWaveOut.Tag = "WaveOut";
            //this.vibrationWaveOut.Enabled = false;
            this.vibrationWaveOut.DataSource = System.Enum.GetValues(typeof(Thalmic.Myo.VibrationType));

            // 
            // vibrationWaveIn
            // 
            this.vibrationWaveIn.Cursor = System.Windows.Forms.Cursors.Default;
            this.vibrationWaveIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vibrationWaveIn.FormattingEnabled = true;
            this.vibrationWaveIn.Location = new System.Drawing.Point(186, 48);
            this.vibrationWaveIn.Name = "vibrationWaveIn";
            this.vibrationWaveIn.Size = new System.Drawing.Size(67, 21);
            this.vibrationWaveIn.TabIndex = 19;
            this.vibrationWaveIn.Tag = "WaveIn";
            //this.vibrationWaveIn.Enabled = false;
            this.vibrationWaveIn.DataSource = System.Enum.GetValues(typeof(Thalmic.Myo.VibrationType));

            // 
            // vibrationFist
            // 
            this.vibrationFist.Cursor = System.Windows.Forms.Cursors.Default;
            this.vibrationFist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vibrationFist.FormattingEnabled = true;
            this.vibrationFist.Location = new System.Drawing.Point(186, 21);
            this.vibrationFist.Name = "vibrationFist";
            this.vibrationFist.Size = new System.Drawing.Size(67, 21);
            this.vibrationFist.TabIndex = 18;
            this.vibrationFist.Tag = "Fist";
            //this.vibrationFist.Enabled = false;
            this.vibrationFist.DataSource = System.Enum.GetValues(typeof(Thalmic.Myo.VibrationType));

            // 
            // vibrationValidation
            // 
            this.vibrationValidation.Cursor = System.Windows.Forms.Cursors.Default;
            this.vibrationValidation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vibrationValidation.FormattingEnabled = false;//
            this.vibrationValidation.Location = new System.Drawing.Point(186, 156);
            this.vibrationValidation.Name = "vibrationValidation";
            this.vibrationValidation.Size = new System.Drawing.Size(67, 21);
            this.vibrationValidation.TabIndex = 19;
            this.vibrationValidation.Tag = "Validation";
            //this.vibrationValidation.Enabled = false;
            this.vibrationValidation.DataSource = System.Enum.GetValues(typeof(Thalmic.Myo.VibrationType));

            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(195, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Vibration";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Keys";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Pose list";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // poseTwistIn
            // 
            this.poseTwistIn.AutoSize = true;
            this.poseTwistIn.Location = new System.Drawing.Point(6, 133);
            this.poseTwistIn.Name = "poseTwistIn";
            this.poseTwistIn.Size = new System.Drawing.Size(63, 17);
            this.poseTwistIn.TabIndex = 14;
            this.poseTwistIn.Tag = "TwistIn";
            this.poseTwistIn.Text = "Twist In";
            this.poseTwistIn.UseVisualStyleBackColor = true;
            this.poseTwistIn.CheckedChanged += new System.EventHandler(this.checkKeyValue);
            // 
            // poseFingersSpread
            // 
            this.poseFingersSpread.AutoSize = true;
            this.poseFingersSpread.Location = new System.Drawing.Point(6, 106);
            this.poseFingersSpread.Name = "poseFingersSpread";
            this.poseFingersSpread.Size = new System.Drawing.Size(97, 17);
            this.poseFingersSpread.TabIndex = 12;
            this.poseFingersSpread.Tag = "FingersSpread";
            this.poseFingersSpread.Text = "Fingers Spread";
            this.poseFingersSpread.UseVisualStyleBackColor = true;
            this.poseFingersSpread.CheckedChanged += new System.EventHandler(this.checkKeyValue);
            // 
            // poseWaveOut
            // 
            this.poseWaveOut.AutoSize = true;
            this.poseWaveOut.Location = new System.Drawing.Point(6, 79);
            this.poseWaveOut.Name = "poseWaveOut";
            this.poseWaveOut.Size = new System.Drawing.Size(75, 17);
            this.poseWaveOut.TabIndex = 10;
            this.poseWaveOut.Tag = "WaveOut";
            this.poseWaveOut.Text = "Wave Out";
            this.poseWaveOut.UseVisualStyleBackColor = true;
            this.poseWaveOut.CheckedChanged += new System.EventHandler(this.checkKeyValue);
            // 
            // poseWaveIn
            // 
            this.poseWaveIn.AutoSize = true;
            this.poseWaveIn.Location = new System.Drawing.Point(6, 52);
            this.poseWaveIn.Name = "poseWaveIn";
            this.poseWaveIn.Size = new System.Drawing.Size(66, 17);
            this.poseWaveIn.TabIndex = 8;
            this.poseWaveIn.Tag = "WaveIn";
            this.poseWaveIn.Text = "Wave in";
            this.poseWaveIn.UseVisualStyleBackColor = true;
            this.poseWaveIn.CheckedChanged += new System.EventHandler(this.checkKeyValue);
            // 
            // poseFist
            // 
            this.poseFist.AutoSize = true;
            this.poseFist.Location = new System.Drawing.Point(6, 25);
            this.poseFist.Name = "poseFist";
            this.poseFist.Size = new System.Drawing.Size(42, 17);
            this.poseFist.TabIndex = 6;
            this.poseFist.Tag = "Fist";
            this.poseFist.Text = "Fist";
            this.poseFist.UseVisualStyleBackColor = true;
            this.poseFist.CheckedChanged += new System.EventHandler(this.checkKeyValue);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(80, 202);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.startSend);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Validation gesture";
            // 
            // validationGestureBox
            // 
            this.validatioGestureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.validatioGestureBox.DataSource = System.Enum.GetValues(typeof(Thalmic.Myo.Pose));
            this.validatioGestureBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.validatioGestureBox.FormattingEnabled = true;
            this.validatioGestureBox.Location = new System.Drawing.Point(113, 156);
            this.validatioGestureBox.Name = "validatioGestureBox";
            this.validatioGestureBox.Size = new System.Drawing.Size(67, 21);
            this.validatioGestureBox.TabIndex = 27;
            this.validatioGestureBox.Tag = "ValidationGestureBox";
            this.validatioGestureBox.SelectedIndexChanged += new System.EventHandler(this.validatioGestureBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 245);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Myo Keys";
            //this.MaximumSize = this.MinimumSize = this.Size;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Closing);

        }

        #endregion

        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox poseFist;
        private System.Windows.Forms.CheckBox poseTwistIn;
        private System.Windows.Forms.CheckBox poseFingersSpread;
        private System.Windows.Forms.CheckBox poseWaveOut;
        private System.Windows.Forms.CheckBox poseWaveIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox keyFist;
        private System.Windows.Forms.ComboBox vibrationFist;
        private System.Windows.Forms.ComboBox vibrationTwistIn;
        private System.Windows.Forms.ComboBox vibrationFingersSpread;
        private System.Windows.Forms.ComboBox vibrationWaveOut;
        private System.Windows.Forms.ComboBox vibrationWaveIn;
        private System.Windows.Forms.ComboBox vibrationValidation;
        private System.Windows.Forms.TextBox keyTwistIn;
        private System.Windows.Forms.TextBox keyFingersSpread;
        private System.Windows.Forms.TextBox keyWaveOut;
        private System.Windows.Forms.TextBox keyWaveIn;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox validatioGestureBox;
    }
}

