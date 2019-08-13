namespace MusicBeePlugin
{
    partial class Settings
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
            this.entriesBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.outputPathBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // entriesBox
            // 
            this.entriesBox.Location = new System.Drawing.Point(28, 61);
            this.entriesBox.Name = "entriesBox";
            this.entriesBox.Size = new System.Drawing.Size(63, 22);
            this.entriesBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Maximum Entries (0 = Unlimited)";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(110, 197);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(141, 39);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output Path";
            // 
            // outputPathBox
            // 
            this.outputPathBox.Location = new System.Drawing.Point(26, 151);
            this.outputPathBox.Name = "outputPathBox";
            this.outputPathBox.Size = new System.Drawing.Size(313, 22);
            this.outputPathBox.TabIndex = 4;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 256);
            this.Controls.Add(this.outputPathBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.entriesBox);
            this.Name = "Settings";
            this.Text = "mb_SongHistory Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox entriesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outputPathBox;
    }
}