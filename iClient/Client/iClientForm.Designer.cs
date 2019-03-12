namespace Client
{
    partial class iClientForm
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
            this.IDBOX = new System.Windows.Forms.TextBox();
            this.FindButton = new System.Windows.Forms.Button();
            this.ipText = new System.Windows.Forms.TextBox();
            this.ipSubmit = new System.Windows.Forms.Button();
            this.IPLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.memberIDLabel = new System.Windows.Forms.Label();
            this.FirstNameBox = new System.Windows.Forms.TextBox();
            this.LastNameBox = new System.Windows.Forms.TextBox();
            this.dobBox = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.DOBLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IDBOX
            // 
            this.IDBOX.Location = new System.Drawing.Point(215, 209);
            this.IDBOX.Margin = new System.Windows.Forms.Padding(4);
            this.IDBOX.Name = "IDBOX";
            this.IDBOX.Size = new System.Drawing.Size(108, 22);
            this.IDBOX.TabIndex = 0;
            this.IDBOX.Visible = false;
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(331, 206);
            this.FindButton.Margin = new System.Windows.Forms.Padding(4);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(88, 29);
            this.FindButton.TabIndex = 1;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Visible = false;
            this.FindButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ipText
            // 
            this.ipText.Location = new System.Drawing.Point(249, 33);
            this.ipText.Margin = new System.Windows.Forms.Padding(4);
            this.ipText.Name = "ipText";
            this.ipText.Size = new System.Drawing.Size(364, 22);
            this.ipText.TabIndex = 2;
            // 
            // ipSubmit
            // 
            this.ipSubmit.Location = new System.Drawing.Point(131, 109);
            this.ipSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.ipSubmit.Name = "ipSubmit";
            this.ipSubmit.Size = new System.Drawing.Size(169, 36);
            this.ipSubmit.TabIndex = 3;
            this.ipSubmit.Text = "Connect";
            this.ipSubmit.UseVisualStyleBackColor = true;
            this.ipSubmit.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(724, 41);
            this.IPLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(24, 17);
            this.IPLabel.TabIndex = 4;
            this.IPLabel.Text = "IP:";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(724, 66);
            this.portLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(38, 17);
            this.portLabel.TabIndex = 6;
            this.portLabel.Text = "Port:";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(249, 63);
            this.portBox.Margin = new System.Windows.Forms.Padding(4);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(125, 22);
            this.portBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Enter IP Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Enter Port #";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(121, 371);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(4);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(88, 29);
            this.UpdateButton.TabIndex = 11;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Visible = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(235, 371);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(88, 29);
            this.DeleteButton.TabIndex = 12;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Visible = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // memberIDLabel
            // 
            this.memberIDLabel.AutoSize = true;
            this.memberIDLabel.Location = new System.Drawing.Point(128, 212);
            this.memberIDLabel.Name = "memberIDLabel";
            this.memberIDLabel.Size = new System.Drawing.Size(76, 17);
            this.memberIDLabel.TabIndex = 13;
            this.memberIDLabel.Text = "Member ID";
            this.memberIDLabel.Visible = false;
            // 
            // FirstNameBox
            // 
            this.FirstNameBox.Location = new System.Drawing.Point(215, 263);
            this.FirstNameBox.Margin = new System.Windows.Forms.Padding(4);
            this.FirstNameBox.Name = "FirstNameBox";
            this.FirstNameBox.Size = new System.Drawing.Size(108, 22);
            this.FirstNameBox.TabIndex = 14;
            this.FirstNameBox.Visible = false;
            // 
            // LastNameBox
            // 
            this.LastNameBox.Location = new System.Drawing.Point(215, 293);
            this.LastNameBox.Margin = new System.Windows.Forms.Padding(4);
            this.LastNameBox.Name = "LastNameBox";
            this.LastNameBox.Size = new System.Drawing.Size(108, 22);
            this.LastNameBox.TabIndex = 15;
            this.LastNameBox.Visible = false;
            // 
            // dobBox
            // 
            this.dobBox.Location = new System.Drawing.Point(215, 323);
            this.dobBox.Margin = new System.Windows.Forms.Padding(4);
            this.dobBox.Name = "dobBox";
            this.dobBox.Size = new System.Drawing.Size(108, 22);
            this.dobBox.TabIndex = 16;
            this.dobBox.Visible = false;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(118, 266);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(76, 17);
            this.FirstNameLabel.TabIndex = 17;
            this.FirstNameLabel.Text = "First Name";
            this.FirstNameLabel.Visible = false;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(118, 296);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(76, 17);
            this.LastNameLabel.TabIndex = 18;
            this.LastNameLabel.Text = "Last Name";
            this.LastNameLabel.Visible = false;
            // 
            // DOBLabel
            // 
            this.DOBLabel.AutoSize = true;
            this.DOBLabel.Location = new System.Drawing.Point(118, 326);
            this.DOBLabel.Name = "DOBLabel";
            this.DOBLabel.Size = new System.Drawing.Size(90, 17);
            this.DOBLabel.TabIndex = 19;
            this.DOBLabel.Text = "Date Of Birth";
            this.DOBLabel.Visible = false;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(902, 456);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(88, 29);
            this.exitButton.TabIndex = 20;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // iClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.DOBLabel);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.dobBox);
            this.Controls.Add(this.LastNameBox);
            this.Controls.Add(this.FirstNameBox);
            this.Controls.Add(this.memberIDLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.IPLabel);
            this.Controls.Add(this.ipSubmit);
            this.Controls.Add(this.ipText);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.IDBOX);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "iClientForm";
            this.Text = "iClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IDBOX;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.TextBox ipText;
        private System.Windows.Forms.Button ipSubmit;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label memberIDLabel;
        private System.Windows.Forms.TextBox FirstNameBox;
        private System.Windows.Forms.TextBox LastNameBox;
        private System.Windows.Forms.TextBox dobBox;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label DOBLabel;
        private System.Windows.Forms.Button exitButton;
    }
}

