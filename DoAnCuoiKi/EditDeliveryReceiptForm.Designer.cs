namespace DoAnCuoiKi
{
    partial class EditDeliveryReceiptForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.payBox = new System.Windows.Forms.ComboBox();
            this.payLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.shipBox = new System.Windows.Forms.ComboBox();
            this.shipLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toBox = new System.Windows.Forms.TextBox();
            this.toLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.byBox = new System.Windows.Forms.TextBox();
            this.byLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.idBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.updateButton);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(432, 233);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delivery receipt information";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(96, 196);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(74, 33);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(3, 197);
            this.updateButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(90, 32);
            this.updateButton.TabIndex = 7;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.payBox);
            this.panel6.Controls.Add(this.payLabel);
            this.panel6.Location = new System.Drawing.Point(3, 168);
            this.panel6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(426, 26);
            this.panel6.TabIndex = 6;
            // 
            // payBox
            // 
            this.payBox.FormattingEnabled = true;
            this.payBox.Items.AddRange(new object[] {
            "Paid",
            "Not pay yet"});
            this.payBox.Location = new System.Drawing.Point(128, 2);
            this.payBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.payBox.Name = "payBox";
            this.payBox.Size = new System.Drawing.Size(298, 28);
            this.payBox.TabIndex = 3;
            // 
            // payLabel
            // 
            this.payLabel.AutoSize = true;
            this.payLabel.Location = new System.Drawing.Point(2, 3);
            this.payLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.payLabel.Name = "payLabel";
            this.payLabel.Size = new System.Drawing.Size(119, 20);
            this.payLabel.TabIndex = 0;
            this.payLabel.Text = "Payment status";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.shipBox);
            this.panel5.Controls.Add(this.shipLabel);
            this.panel5.Location = new System.Drawing.Point(3, 139);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(426, 26);
            this.panel5.TabIndex = 5;
            // 
            // shipBox
            // 
            this.shipBox.FormattingEnabled = true;
            this.shipBox.Items.AddRange(new object[] {
            "Shipping",
            "Shiped"});
            this.shipBox.Location = new System.Drawing.Point(128, 2);
            this.shipBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.shipBox.Name = "shipBox";
            this.shipBox.Size = new System.Drawing.Size(298, 28);
            this.shipBox.TabIndex = 2;
            // 
            // shipLabel
            // 
            this.shipLabel.AutoSize = true;
            this.shipLabel.Location = new System.Drawing.Point(2, 3);
            this.shipLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.shipLabel.Name = "shipLabel";
            this.shipLabel.Size = new System.Drawing.Size(125, 20);
            this.shipLabel.TabIndex = 0;
            this.shipLabel.Text = "Shipment status";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.datePicker);
            this.panel4.Controls.Add(this.dateLabel);
            this.panel4.Location = new System.Drawing.Point(3, 110);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(426, 26);
            this.panel4.TabIndex = 4;
            // 
            // datePicker
            // 
            this.datePicker.Enabled = false;
            this.datePicker.Location = new System.Drawing.Point(128, 0);
            this.datePicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(298, 26);
            this.datePicker.TabIndex = 1;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(2, 3);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(102, 20);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Date created";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toBox);
            this.panel3.Controls.Add(this.toLabel);
            this.panel3.Location = new System.Drawing.Point(3, 81);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(426, 26);
            this.panel3.TabIndex = 3;
            // 
            // toBox
            // 
            this.toBox.Enabled = false;
            this.toBox.Location = new System.Drawing.Point(128, 2);
            this.toBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toBox.Name = "toBox";
            this.toBox.Size = new System.Drawing.Size(298, 26);
            this.toBox.TabIndex = 1;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(2, 3);
            this.toLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(82, 20);
            this.toLabel.TabIndex = 0;
            this.toLabel.Text = "Delivery to";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.byBox);
            this.panel2.Controls.Add(this.byLabel);
            this.panel2.Location = new System.Drawing.Point(3, 51);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 26);
            this.panel2.TabIndex = 2;
            // 
            // byBox
            // 
            this.byBox.Enabled = false;
            this.byBox.Location = new System.Drawing.Point(128, 2);
            this.byBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.byBox.Name = "byBox";
            this.byBox.Size = new System.Drawing.Size(298, 26);
            this.byBox.TabIndex = 1;
            // 
            // byLabel
            // 
            this.byLabel.AutoSize = true;
            this.byLabel.Location = new System.Drawing.Point(2, 3);
            this.byLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.byLabel.Name = "byLabel";
            this.byLabel.Size = new System.Drawing.Size(86, 20);
            this.byLabel.TabIndex = 0;
            this.byLabel.Text = "Created by";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.idBox);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 26);
            this.panel1.TabIndex = 1;
            // 
            // idBox
            // 
            this.idBox.Enabled = false;
            this.idBox.Location = new System.Drawing.Point(128, 2);
            this.idBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(298, 26);
            this.idBox.TabIndex = 1;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(2, 3);
            this.idLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(26, 20);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // EditDeliveryReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 248);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "EditDeliveryReceiptForm";
            this.Text = "Edit delivery receipt - Warehouse Management";
            this.groupBox1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label shipLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox toBox;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox byBox;
        private System.Windows.Forms.Label byLabel;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label payLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.ComboBox payBox;
        private System.Windows.Forms.ComboBox shipBox;
    }
}