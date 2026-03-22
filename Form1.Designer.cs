namespace SamsungDebloater
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtLog = new RichTextBox();
            button1 = new Button();
            imageList1 = new ImageList(components);
            lblStatus = new Label();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // txtLog
            // 
            txtLog.Location = new Point(449, 41);
            txtLog.Margin = new Padding(4);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.Size = new Size(276, 318);
            txtLog.TabIndex = 0;
            txtLog.Text = "";
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 20F);
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.ImageIndex = 0;
            button1.ImageList = imageList1;
            button1.Location = new Point(140, 304);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(185, 55);
            button1.TabIndex = 1;
            button1.Text = "حذف";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Full_Glass_blue_folder_delete.png");
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.Location = new Point(55, 41);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(354, 188);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "حالة الاتصال";
            lblStatus.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.Location = new Point(449, 363);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(276, 52);
            label1.TabIndex = 3;
            label1.Text = "صمم خصيصا للسيد: عماد قاسمي";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 437);
            Controls.Add(label1);
            Controls.Add(lblStatus);
            Controls.Add(button1);
            Controls.Add(txtLog);
            Font = new Font("Times New Roman", 13F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Form1";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "حذف برامج التجسس لاجهزة سامسونغ";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox txtLog;
        private Button button1;
        private Label lblStatus;
        private Label label1;
        private ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
    }
}
