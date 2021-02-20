namespace BlueRose
{
    partial class BlueRoseGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlueRoseGUI));
            this.playBtn = new System.Windows.Forms.Button();
            this.devBtn = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnUpdateLauncher = new System.Windows.Forms.Button();
            this.localBuild = new System.Windows.Forms.Label();
            this.versionIS = new System.Windows.Forms.Label();
            this.latestBuild = new System.Windows.Forms.Label();
            this.onlineBuildLabel = new System.Windows.Forms.Label();
            this.parmaBox = new System.Windows.Forms.TextBox();
            this.idleProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // playBtn
            // 
            this.playBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.Location = new System.Drawing.Point(262, 12);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(107, 47);
            this.playBtn.TabIndex = 0;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // devBtn
            // 
            this.devBtn.Location = new System.Drawing.Point(138, 12);
            this.devBtn.Name = "devBtn";
            this.devBtn.Size = new System.Drawing.Size(116, 21);
            this.devBtn.TabIndex = 1;
            this.devBtn.Text = "Develop";
            this.devBtn.UseVisualStyleBackColor = true;
            this.devBtn.Click += new System.EventHandler(this.devBtn_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(10, 39);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(116, 21);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update FreeSO";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnUpdateLauncher
            // 
            this.btnUpdateLauncher.Location = new System.Drawing.Point(10, 12);
            this.btnUpdateLauncher.Name = "btnUpdateLauncher";
            this.btnUpdateLauncher.Size = new System.Drawing.Size(116, 21);
            this.btnUpdateLauncher.TabIndex = 10;
            this.btnUpdateLauncher.Text = "Update Launcher";
            this.btnUpdateLauncher.UseVisualStyleBackColor = true;
            this.btnUpdateLauncher.Click += new System.EventHandler(this.btnUpdateLauncher_Click);
            // 
            // localBuild
            // 
            this.localBuild.AutoSize = true;
            this.localBuild.BackColor = System.Drawing.Color.Transparent;
            this.localBuild.ForeColor = System.Drawing.Color.Black;
            this.localBuild.Location = new System.Drawing.Point(274, 93);
            this.localBuild.Name = "localBuild";
            this.localBuild.Size = new System.Drawing.Size(35, 13);
            this.localBuild.TabIndex = 11;
            this.localBuild.Text = "label1";
            // 
            // versionIS
            // 
            this.versionIS.AutoSize = true;
            this.versionIS.BackColor = System.Drawing.Color.Transparent;
            this.versionIS.ForeColor = System.Drawing.Color.Black;
            this.versionIS.Location = new System.Drawing.Point(194, 93);
            this.versionIS.Name = "versionIS";
            this.versionIS.Size = new System.Drawing.Size(74, 13);
            this.versionIS.TabIndex = 12;
            this.versionIS.Text = "Installed build:";
            // 
            // latestBuild
            // 
            this.latestBuild.AutoSize = true;
            this.latestBuild.BackColor = System.Drawing.Color.Transparent;
            this.latestBuild.ForeColor = System.Drawing.Color.Black;
            this.latestBuild.Location = new System.Drawing.Point(60, 93);
            this.latestBuild.Name = "latestBuild";
            this.latestBuild.Size = new System.Drawing.Size(64, 13);
            this.latestBuild.TabIndex = 13;
            this.latestBuild.Text = "Latest build:";
            // 
            // onlineBuildLabel
            // 
            this.onlineBuildLabel.AutoSize = true;
            this.onlineBuildLabel.BackColor = System.Drawing.Color.Transparent;
            this.onlineBuildLabel.ForeColor = System.Drawing.Color.Black;
            this.onlineBuildLabel.Location = new System.Drawing.Point(140, 93);
            this.onlineBuildLabel.Name = "onlineBuildLabel";
            this.onlineBuildLabel.Size = new System.Drawing.Size(35, 13);
            this.onlineBuildLabel.TabIndex = 14;
            this.onlineBuildLabel.Text = "label1";
            this.onlineBuildLabel.Click += new System.EventHandler(this.onlineBuildLabel_Click);
            // 
            // parmaBox
            // 
            this.parmaBox.Location = new System.Drawing.Point(138, 39);
            this.parmaBox.Name = "parmaBox";
            this.parmaBox.Size = new System.Drawing.Size(117, 20);
            this.parmaBox.TabIndex = 19;
            // 
            // idleProgressBar
            // 
            this.idleProgressBar.Location = new System.Drawing.Point(10, 66);
            this.idleProgressBar.Name = "idleProgressBar";
            this.idleProgressBar.Size = new System.Drawing.Size(359, 20);
            this.idleProgressBar.TabIndex = 21;
            // 
            // BlueRoseGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(380, 117);
            this.Controls.Add(this.idleProgressBar);
            this.Controls.Add(this.parmaBox);
            this.Controls.Add(this.onlineBuildLabel);
            this.Controls.Add(this.latestBuild);
            this.Controls.Add(this.versionIS);
            this.Controls.Add(this.localBuild);
            this.Controls.Add(this.btnUpdateLauncher);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.devBtn);
            this.Controls.Add(this.playBtn);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BlueRoseGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blue Rose";
            this.Load += new System.EventHandler(this.BlueRoseGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button devBtn;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnUpdateLauncher;
        private System.Windows.Forms.Label localBuild;
        private System.Windows.Forms.Label versionIS;
        private System.Windows.Forms.Label latestBuild;
        private System.Windows.Forms.Label onlineBuildLabel;
        private System.Windows.Forms.TextBox parmaBox;
        private System.Windows.Forms.ProgressBar idleProgressBar;
    }
}
