namespace ElevatorPriorityDemo
{
    partial class ElevatorRoom
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnGo = new My_Own_Custom_Controls_library.CircularButton();
            this.B0 = new My_Own_Custom_Controls_library.CircularButton();
            this.BtnDemand = new My_Own_Custom_Controls_library.CircularButton();
            this.B8 = new My_Own_Custom_Controls_library.CircularButton();
            this.B4 = new My_Own_Custom_Controls_library.CircularButton();
            this.B5 = new My_Own_Custom_Controls_library.CircularButton();
            this.B1 = new My_Own_Custom_Controls_library.CircularButton();
            this.B9 = new My_Own_Custom_Controls_library.CircularButton();
            this.B6 = new My_Own_Custom_Controls_library.CircularButton();
            this.B2 = new My_Own_Custom_Controls_library.CircularButton();
            this.B3 = new My_Own_Custom_Controls_library.CircularButton();
            this.B7 = new My_Own_Custom_Controls_library.CircularButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbtnDestReached = new My_Own_Custom_Controls_library.CircularButton();
            this.lblNextFloor = new System.Windows.Forms.Label();
            this.cbtnDestReached2 = new My_Own_Custom_Controls_library.CircularButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rchTxt = new System.Windows.Forms.RichTextBox();
            this.pbUpDown = new System.Windows.Forms.PictureBox();
            this.txtFloors = new System.Windows.Forms.TextBox();
            this.FloorTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnGo);
            this.panel1.Controls.Add(this.B0);
            this.panel1.Controls.Add(this.BtnDemand);
            this.panel1.Controls.Add(this.B8);
            this.panel1.Controls.Add(this.B4);
            this.panel1.Controls.Add(this.B5);
            this.panel1.Controls.Add(this.B1);
            this.panel1.Controls.Add(this.B9);
            this.panel1.Controls.Add(this.B6);
            this.panel1.Controls.Add(this.B2);
            this.panel1.Controls.Add(this.B3);
            this.panel1.Controls.Add(this.B7);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 559);
            this.panel1.TabIndex = 0;
            // 
            // BtnGo
            // 
            this.BtnGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnGo.FlatAppearance.BorderSize = 0;
            this.BtnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGo.Location = new System.Drawing.Point(262, 375);
            this.BtnGo.Name = "BtnGo";
            this.BtnGo.Size = new System.Drawing.Size(53, 55);
            this.BtnGo.TabIndex = 11;
            this.BtnGo.Text = "Go";
            this.BtnGo.UseVisualStyleBackColor = false;
            this.BtnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // B0
            // 
            this.B0.BackColor = System.Drawing.Color.Coral;
            this.B0.Enabled = false;
            this.B0.FlatAppearance.BorderSize = 0;
            this.B0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B0.Location = new System.Drawing.Point(179, 375);
            this.B0.Name = "B0";
            this.B0.Size = new System.Drawing.Size(53, 55);
            this.B0.TabIndex = 10;
            this.B0.Tag = "Ground Floor";
            this.B0.Text = "0";
            this.B0.UseVisualStyleBackColor = false;
            this.B0.Click += new System.EventHandler(this.PerformButtonClick);
            // 
            // BtnDemand
            // 
            this.BtnDemand.BackColor = System.Drawing.Color.Transparent;
            this.BtnDemand.BackgroundImage = global::ElevatorPriorityDemo.Properties.Resources.bell;
            this.BtnDemand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnDemand.FlatAppearance.BorderSize = 0;
            this.BtnDemand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDemand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDemand.Location = new System.Drawing.Point(96, 375);
            this.BtnDemand.Name = "BtnDemand";
            this.BtnDemand.Size = new System.Drawing.Size(53, 55);
            this.BtnDemand.TabIndex = 9;
            this.BtnDemand.UseVisualStyleBackColor = false;
            this.BtnDemand.Click += new System.EventHandler(this.BtnDemand_Click);
            // 
            // B8
            // 
            this.B8.BackColor = System.Drawing.Color.Coral;
            this.B8.FlatAppearance.BorderSize = 0;
            this.B8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B8.Location = new System.Drawing.Point(179, 297);
            this.B8.Name = "B8";
            this.B8.Size = new System.Drawing.Size(53, 55);
            this.B8.TabIndex = 8;
            this.B8.Tag = "8th floor";
            this.B8.Text = "8";
            this.B8.UseVisualStyleBackColor = false;
            this.B8.Click += new System.EventHandler(this.PerformButtonClick);
            // 
            // B4
            // 
            this.B4.BackColor = System.Drawing.Color.Coral;
            this.B4.FlatAppearance.BorderSize = 0;
            this.B4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B4.Location = new System.Drawing.Point(96, 221);
            this.B4.Name = "B4";
            this.B4.Size = new System.Drawing.Size(53, 55);
            this.B4.TabIndex = 7;
            this.B4.Tag = "Fourth floor";
            this.B4.Text = "4";
            this.B4.UseVisualStyleBackColor = false;
            this.B4.Click += new System.EventHandler(this.PerformButtonClick);
            // 
            // B5
            // 
            this.B5.BackColor = System.Drawing.Color.Coral;
            this.B5.FlatAppearance.BorderSize = 0;
            this.B5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B5.Location = new System.Drawing.Point(179, 218);
            this.B5.Name = "B5";
            this.B5.Size = new System.Drawing.Size(53, 55);
            this.B5.TabIndex = 6;
            this.B5.Tag = "Fifth floor";
            this.B5.Text = "5";
            this.B5.UseVisualStyleBackColor = false;
            this.B5.Click += new System.EventHandler(this.PerformButtonClick);
            // 
            // B1
            // 
            this.B1.BackColor = System.Drawing.Color.Coral;
            this.B1.FlatAppearance.BorderSize = 0;
            this.B1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B1.Location = new System.Drawing.Point(96, 145);
            this.B1.Name = "B1";
            this.B1.Size = new System.Drawing.Size(53, 55);
            this.B1.TabIndex = 5;
            this.B1.Tag = "First floor";
            this.B1.Text = "1";
            this.B1.UseVisualStyleBackColor = false;
            this.B1.Click += new System.EventHandler(this.PerformButtonClick);
            // 
            // B9
            // 
            this.B9.BackColor = System.Drawing.Color.Coral;
            this.B9.FlatAppearance.BorderSize = 0;
            this.B9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B9.Location = new System.Drawing.Point(262, 297);
            this.B9.Name = "B9";
            this.B9.Size = new System.Drawing.Size(53, 55);
            this.B9.TabIndex = 4;
            this.B9.Tag = "9th floor";
            this.B9.Text = "9";
            this.B9.UseVisualStyleBackColor = false;
            this.B9.Click += new System.EventHandler(this.PerformButtonClick);
            // 
            // B6
            // 
            this.B6.BackColor = System.Drawing.Color.Coral;
            this.B6.FlatAppearance.BorderSize = 0;
            this.B6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B6.Location = new System.Drawing.Point(262, 221);
            this.B6.Name = "B6";
            this.B6.Size = new System.Drawing.Size(53, 55);
            this.B6.TabIndex = 3;
            this.B6.Tag = "Sixth floor";
            this.B6.Text = "6";
            this.B6.UseVisualStyleBackColor = false;
            this.B6.Click += new System.EventHandler(this.PerformButtonClick);
            // 
            // B2
            // 
            this.B2.BackColor = System.Drawing.Color.Coral;
            this.B2.FlatAppearance.BorderSize = 0;
            this.B2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B2.Location = new System.Drawing.Point(179, 145);
            this.B2.Name = "B2";
            this.B2.Size = new System.Drawing.Size(53, 55);
            this.B2.TabIndex = 2;
            this.B2.Tag = "Second floor";
            this.B2.Text = "2";
            this.B2.UseVisualStyleBackColor = false;
            this.B2.Click += new System.EventHandler(this.PerformButtonClick);
            // 
            // B3
            // 
            this.B3.BackColor = System.Drawing.Color.Coral;
            this.B3.FlatAppearance.BorderSize = 0;
            this.B3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B3.Location = new System.Drawing.Point(262, 145);
            this.B3.Name = "B3";
            this.B3.Size = new System.Drawing.Size(53, 55);
            this.B3.TabIndex = 1;
            this.B3.Tag = "Third floor";
            this.B3.Text = "3";
            this.B3.UseVisualStyleBackColor = false;
            this.B3.Click += new System.EventHandler(this.PerformButtonClick);
            // 
            // B7
            // 
            this.B7.BackColor = System.Drawing.Color.Coral;
            this.B7.FlatAppearance.BorderSize = 0;
            this.B7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B7.Location = new System.Drawing.Point(96, 297);
            this.B7.Name = "B7";
            this.B7.Size = new System.Drawing.Size(53, 55);
            this.B7.TabIndex = 0;
            this.B7.Tag = "Seventh floor";
            this.B7.Text = "7";
            this.B7.UseVisualStyleBackColor = false;
            this.B7.Click += new System.EventHandler(this.PerformButtonClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbtnDestReached);
            this.panel2.Controls.Add(this.lblNextFloor);
            this.panel2.Controls.Add(this.cbtnDestReached2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rchTxt);
            this.panel2.Controls.Add(this.pbUpDown);
            this.panel2.Controls.Add(this.txtFloors);
            this.panel2.Location = new System.Drawing.Point(433, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 559);
            this.panel2.TabIndex = 1;
            // 
            // cbtnDestReached
            // 
            this.cbtnDestReached.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbtnDestReached.FlatAppearance.BorderSize = 0;
            this.cbtnDestReached.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbtnDestReached.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtnDestReached.Location = new System.Drawing.Point(293, 257);
            this.cbtnDestReached.Name = "cbtnDestReached";
            this.cbtnDestReached.Size = new System.Drawing.Size(35, 37);
            this.cbtnDestReached.TabIndex = 13;
            this.cbtnDestReached.Tag = "Second floor";
            this.cbtnDestReached.UseVisualStyleBackColor = false;
            // 
            // lblNextFloor
            // 
            this.lblNextFloor.AutoSize = true;
            this.lblNextFloor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblNextFloor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextFloor.Location = new System.Drawing.Point(255, 452);
            this.lblNextFloor.Name = "lblNextFloor";
            this.lblNextFloor.Size = new System.Drawing.Size(181, 32);
            this.lblNextFloor.TabIndex = 16;
            this.lblNextFloor.Text = "Ground Floor";
            // 
            // cbtnDestReached2
            // 
            this.cbtnDestReached2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbtnDestReached2.FlatAppearance.BorderSize = 0;
            this.cbtnDestReached2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbtnDestReached2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtnDestReached2.Location = new System.Drawing.Point(334, 257);
            this.cbtnDestReached2.Name = "cbtnDestReached2";
            this.cbtnDestReached2.Size = new System.Drawing.Size(35, 37);
            this.cbtnDestReached2.TabIndex = 12;
            this.cbtnDestReached2.Tag = "Third floor";
            this.cbtnDestReached2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "We have reached :";
            // 
            // rchTxt
            // 
            this.rchTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchTxt.Location = new System.Drawing.Point(198, 146);
            this.rchTxt.Name = "rchTxt";
            this.rchTxt.ReadOnly = true;
            this.rchTxt.Size = new System.Drawing.Size(255, 82);
            this.rchTxt.TabIndex = 14;
            this.rchTxt.Text = "";
            // 
            // pbUpDown
            // 
            this.pbUpDown.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbUpDown.Image = global::ElevatorPriorityDemo.Properties.Resources.up_2;
            this.pbUpDown.Location = new System.Drawing.Point(212, 306);
            this.pbUpDown.Name = "pbUpDown";
            this.pbUpDown.Size = new System.Drawing.Size(42, 35);
            this.pbUpDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUpDown.TabIndex = 1;
            this.pbUpDown.TabStop = false;
            // 
            // txtFloors
            // 
            this.txtFloors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFloors.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFloors.Location = new System.Drawing.Point(202, 302);
            this.txtFloors.Multiline = true;
            this.txtFloors.Name = "txtFloors";
            this.txtFloors.ReadOnly = true;
            this.txtFloors.Size = new System.Drawing.Size(251, 44);
            this.txtFloors.TabIndex = 0;
            this.txtFloors.Text = "0";
            this.txtFloors.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FloorTimer
            // 
            this.FloorTimer.Interval = 1000;
            this.FloorTimer.Tick += new System.EventHandler(this.FloorTimer_Tick);
            // 
            // ElevatorRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 556);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ElevatorRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ElevatorRoom";
            this.Load += new System.EventHandler(this.ElevatorRoom_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private My_Own_Custom_Controls_library.CircularButton B8;
        private My_Own_Custom_Controls_library.CircularButton B4;
        private My_Own_Custom_Controls_library.CircularButton B5;
        private My_Own_Custom_Controls_library.CircularButton B1;
        private My_Own_Custom_Controls_library.CircularButton B9;
        private My_Own_Custom_Controls_library.CircularButton B6;
        private My_Own_Custom_Controls_library.CircularButton B2;
        private My_Own_Custom_Controls_library.CircularButton B3;
        private My_Own_Custom_Controls_library.CircularButton B7;
        private My_Own_Custom_Controls_library.CircularButton BtnDemand;
        private System.Windows.Forms.TextBox txtFloors;
        private System.Windows.Forms.PictureBox pbUpDown;
        private My_Own_Custom_Controls_library.CircularButton BtnGo;
        private My_Own_Custom_Controls_library.CircularButton B0;
        private System.Windows.Forms.RichTextBox rchTxt;
        private System.Windows.Forms.Label lblNextFloor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer FloorTimer;
        private My_Own_Custom_Controls_library.CircularButton cbtnDestReached;
        private My_Own_Custom_Controls_library.CircularButton cbtnDestReached2;
    }
}

