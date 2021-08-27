namespace USBMonitor
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
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonOn = new System.Windows.Forms.Button();
            this.buttonOff = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.comboBoxUd = new System.Windows.Forms.ComboBox();
            this.checkBoxWrite = new System.Windows.Forms.CheckBox();
            this.checkBoxMode1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(79, 47);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(306, 33);
            this.comboBoxPorts.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(420, 47);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(113, 33);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(558, 29);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(164, 51);
            this.buttonOpen.TabIndex = 2;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonOn
            // 
            this.buttonOn.Location = new System.Drawing.Point(810, 29);
            this.buttonOn.Name = "buttonOn";
            this.buttonOn.Size = new System.Drawing.Size(103, 51);
            this.buttonOn.TabIndex = 3;
            this.buttonOn.Text = "On";
            this.buttonOn.UseVisualStyleBackColor = true;
            this.buttonOn.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonOff
            // 
            this.buttonOff.Location = new System.Drawing.Point(956, 29);
            this.buttonOff.Name = "buttonOff";
            this.buttonOff.Size = new System.Drawing.Size(107, 51);
            this.buttonOff.TabIndex = 4;
            this.buttonOff.Text = "Off";
            this.buttonOff.UseVisualStyleBackColor = true;
            this.buttonOff.Click += new System.EventHandler(this.buttonOff_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 196);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1072, 450);
            this.textBox1.TabIndex = 5;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(558, 113);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(164, 46);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBoxUd
            // 
            this.comboBoxUd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUd.FormattingEnabled = true;
            this.comboBoxUd.Location = new System.Drawing.Point(79, 125);
            this.comboBoxUd.Name = "comboBoxUd";
            this.comboBoxUd.Size = new System.Drawing.Size(454, 33);
            this.comboBoxUd.TabIndex = 7;
            // 
            // checkBoxWrite
            // 
            this.checkBoxWrite.AutoSize = true;
            this.checkBoxWrite.Location = new System.Drawing.Point(761, 142);
            this.checkBoxWrite.Name = "checkBoxWrite";
            this.checkBoxWrite.Size = new System.Drawing.Size(379, 29);
            this.checkBoxWrite.TabIndex = 8;
            this.checkBoxWrite.Text = "Mode2: Power Failure During Write";
            this.checkBoxWrite.UseVisualStyleBackColor = true;
            // 
            // checkBoxMode1
            // 
            this.checkBoxMode1.AutoSize = true;
            this.checkBoxMode1.Location = new System.Drawing.Point(761, 107);
            this.checkBoxMode1.Name = "checkBoxMode1";
            this.checkBoxMode1.Size = new System.Drawing.Size(242, 29);
            this.checkBoxMode1.TabIndex = 9;
            this.checkBoxMode1.Text = "Mode1: On-Write-Off";
            this.checkBoxMode1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 685);
            this.Controls.Add(this.checkBoxMode1);
            this.Controls.Add(this.checkBoxWrite);
            this.Controls.Add(this.comboBoxUd);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonOff);
            this.Controls.Add(this.buttonOn);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.comboBoxPorts);
            this.Name = "Form1";
            this.Text = "PowerFailTester";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonOn;
        private System.Windows.Forms.Button buttonOff;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ComboBox comboBoxUd;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBoxWrite;
        private System.Windows.Forms.CheckBox checkBoxMode1;
    }
}

