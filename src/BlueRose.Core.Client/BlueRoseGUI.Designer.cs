
namespace BlueRose.Core.Client
{
    partial class BlueRoseGUI
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
            this.launchBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.updateSelf = new System.Windows.Forms.Button();
            this.updateApp = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // launchBtn
            // 
            this.launchBtn.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.launchBtn.Location = new System.Drawing.Point(345, 12);
            this.launchBtn.Margin = new System.Windows.Forms.Padding(4);
            this.launchBtn.Name = "launchBtn";
            this.launchBtn.Size = new System.Drawing.Size(139, 67);
            this.launchBtn.TabIndex = 0;
            this.launchBtn.Text = "Launch";
            this.launchBtn.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 85);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(472, 27);
            this.progressBar1.TabIndex = 1;
            // 
            // updateSelf
            // 
            this.updateSelf.Location = new System.Drawing.Point(12, 12);
            this.updateSelf.Name = "updateSelf";
            this.updateSelf.Size = new System.Drawing.Size(127, 29);
            this.updateSelf.TabIndex = 2;
            this.updateSelf.Text = "Update Self";
            this.updateSelf.UseVisualStyleBackColor = true;
            // 
            // updateApp
            // 
            this.updateApp.Location = new System.Drawing.Point(12, 47);
            this.updateApp.Name = "updateApp";
            this.updateApp.Size = new System.Drawing.Size(127, 29);
            this.updateApp.TabIndex = 3;
            this.updateApp.Text = "Update App";
            this.updateApp.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(145, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.richTextBox1.Size = new System.Drawing.Size(193, 64);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // BlueRoseGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 124);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.updateApp);
            this.Controls.Add(this.updateSelf);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.launchBtn);
            this.MaximizeBox = false;
            this.Name = "BlueRoseGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blue Rose Core";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button launchBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button updateSelf;
        private System.Windows.Forms.Button updateApp;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
