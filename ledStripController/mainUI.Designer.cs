namespace ledStripController
{
    partial class mainUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainUI));
            this.label1 = new System.Windows.Forms.Label();
            this.onButton = new System.Windows.Forms.RadioButton();
            this.offButton = new System.Windows.Forms.RadioButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorPickButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.framerateBox = new System.Windows.Forms.TextBox();
            this.animationButton = new System.Windows.Forms.Button();
            this.sync = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // onButton
            // 
            resources.ApplyResources(this.onButton, "onButton");
            this.onButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.onButton.Name = "onButton";
            this.onButton.UseVisualStyleBackColor = true;
            this.onButton.Click += new System.EventHandler(this.onButton_Click);
            // 
            // offButton
            // 
            resources.ApplyResources(this.offButton, "offButton");
            this.offButton.Checked = true;
            this.offButton.ForeColor = System.Drawing.Color.Red;
            this.offButton.Name = "offButton";
            this.offButton.TabStop = true;
            this.offButton.UseVisualStyleBackColor = true;
            this.offButton.Click += new System.EventHandler(this.offButton_Click);
            // 
            // listBox1
            // 
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // colorPickButton
            // 
            resources.ApplyResources(this.colorPickButton, "colorPickButton");
            this.colorPickButton.Name = "colorPickButton";
            this.colorPickButton.UseVisualStyleBackColor = true;
            this.colorPickButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            resources.ApplyResources(this.trackBar1, "trackBar1");
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Value = 100;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            this.trackBar1.DragOver += new System.Windows.Forms.DragEventHandler(this.trackBar1_DragOver);
            // 
            // framerateBox
            // 
            resources.ApplyResources(this.framerateBox, "framerateBox");
            this.framerateBox.Name = "framerateBox";
            this.framerateBox.TextChanged += new System.EventHandler(this.framerateBox_TextChanged);
            // 
            // animationButton
            // 
            resources.ApplyResources(this.animationButton, "animationButton");
            this.animationButton.Name = "animationButton";
            this.animationButton.UseVisualStyleBackColor = true;
            this.animationButton.Click += new System.EventHandler(this.animationButton_Click);
            // 
            // sync
            // 
            this.sync.Tick += new System.EventHandler(this.sync_Tick);
            // 
            // mainUI
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Controls.Add(this.animationButton);
            this.Controls.Add(this.framerateBox);
            this.Controls.Add(this.colorPickButton);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.offButton);
            this.Controls.Add(this.onButton);
            this.Controls.Add(this.label1);
            this.Name = "mainUI";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton onButton;
        private System.Windows.Forms.RadioButton offButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button colorPickButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox framerateBox;
        private System.Windows.Forms.Button animationButton;
        private System.Windows.Forms.Timer sync;
    }
}

