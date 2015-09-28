namespace ledStripController
{
    partial class animationEditor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.animationSlider = new System.Windows.Forms.TrackBar();
            this.frameBox = new System.Windows.Forms.TextBox();
            this.durationBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.lastKeyButton = new System.Windows.Forms.Button();
            this.reverseButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.endButton = new System.Windows.Forms.Button();
            this.nextKeyButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.animationSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1420, 43);
            this.panel1.TabIndex = 5;
            // 
            // animationSlider
            // 
            this.animationSlider.Location = new System.Drawing.Point(70, 246);
            this.animationSlider.Maximum = 0;
            this.animationSlider.Name = "animationSlider";
            this.animationSlider.Size = new System.Drawing.Size(1076, 45);
            this.animationSlider.TabIndex = 6;
            this.animationSlider.ValueChanged += new System.EventHandler(this.animationSlider_ValueChanged);
            // 
            // frameBox
            // 
            this.frameBox.Location = new System.Drawing.Point(13, 246);
            this.frameBox.Name = "frameBox";
            this.frameBox.Size = new System.Drawing.Size(51, 20);
            this.frameBox.TabIndex = 7;
            this.frameBox.Text = "1";
            this.frameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.frameBox.TextChanged += new System.EventHandler(this.frameBox_TextChanged);
            this.frameBox.Enter += new System.EventHandler(this.frameBox_Enter);
            this.frameBox.Leave += new System.EventHandler(this.frameBox_Leave);
            // 
            // durationBox
            // 
            this.durationBox.Location = new System.Drawing.Point(1152, 246);
            this.durationBox.Name = "durationBox";
            this.durationBox.Size = new System.Drawing.Size(51, 20);
            this.durationBox.TabIndex = 8;
            this.durationBox.Text = "1";
            this.durationBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.durationBox.TextChanged += new System.EventHandler(this.durationBox_TextChanged);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(1219, 244);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(23, 23);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "<<";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // lastKeyButton
            // 
            this.lastKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastKeyButton.Location = new System.Drawing.Point(1248, 244);
            this.lastKeyButton.Name = "lastKeyButton";
            this.lastKeyButton.Size = new System.Drawing.Size(23, 23);
            this.lastKeyButton.TabIndex = 10;
            this.lastKeyButton.Text = "|<";
            this.lastKeyButton.UseVisualStyleBackColor = true;
            // 
            // reverseButton
            // 
            this.reverseButton.Location = new System.Drawing.Point(1277, 244);
            this.reverseButton.Name = "reverseButton";
            this.reverseButton.Size = new System.Drawing.Size(23, 23);
            this.reverseButton.TabIndex = 11;
            this.reverseButton.Text = "<";
            this.reverseButton.UseVisualStyleBackColor = true;
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(1306, 244);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(23, 23);
            this.pauseButton.TabIndex = 12;
            this.pauseButton.Text = "| |";
            this.pauseButton.UseVisualStyleBackColor = true;
            // 
            // endButton
            // 
            this.endButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endButton.Location = new System.Drawing.Point(1393, 244);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(23, 23);
            this.endButton.TabIndex = 15;
            this.endButton.Text = ">>";
            this.endButton.UseVisualStyleBackColor = true;
            // 
            // nextKeyButton
            // 
            this.nextKeyButton.Location = new System.Drawing.Point(1364, 244);
            this.nextKeyButton.Name = "nextKeyButton";
            this.nextKeyButton.Size = new System.Drawing.Size(23, 23);
            this.nextKeyButton.TabIndex = 14;
            this.nextKeyButton.Text = ">|";
            this.nextKeyButton.UseVisualStyleBackColor = true;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(1335, 244);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(23, 23);
            this.playButton.TabIndex = 13;
            this.playButton.Text = ">";
            this.playButton.UseVisualStyleBackColor = true;
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.Location = new System.Drawing.Point(1260, 206);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 17;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1341, 206);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // animationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(1424, 281);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.nextKeyButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.reverseButton);
            this.Controls.Add(this.lastKeyButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.durationBox);
            this.Controls.Add(this.frameBox);
            this.Controls.Add(this.animationSlider);
            this.Controls.Add(this.panel1);
            this.Name = "animationEditor";
            this.Text = "Animation Editor";
            ((System.ComponentModel.ISupportInitialize)(this.animationSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar animationSlider;
        private System.Windows.Forms.TextBox frameBox;
        private System.Windows.Forms.TextBox durationBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button lastKeyButton;
        private System.Windows.Forms.Button reverseButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Button nextKeyButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}