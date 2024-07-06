namespace Zborche
{
    partial class ModeSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModeSelectionForm));
            rbEasy = new RadioButton();
            rbMedium = new RadioButton();
            rbHard = new RadioButton();
            groupBox1 = new GroupBox();
            btnExit = new Button();
            btnStart = new Button();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // rbEasy
            // 
            rbEasy.AutoSize = true;
            rbEasy.Checked = true;
            rbEasy.Location = new Point(23, 24);
            rbEasy.Name = "rbEasy";
            rbEasy.Size = new Size(71, 24);
            rbEasy.TabIndex = 0;
            rbEasy.TabStop = true;
            rbEasy.Text = "лесно";
            rbEasy.UseVisualStyleBackColor = true;
            // 
            // rbMedium
            // 
            rbMedium.AutoSize = true;
            rbMedium.Location = new Point(23, 54);
            rbMedium.Name = "rbMedium";
            rbMedium.Size = new Size(80, 24);
            rbMedium.TabIndex = 1;
            rbMedium.Text = "средно";
            rbMedium.UseVisualStyleBackColor = true;
            // 
            // rbHard
            // 
            rbHard.AutoSize = true;
            rbHard.Location = new Point(23, 84);
            rbHard.Name = "rbHard";
            rbHard.Size = new Size(72, 24);
            rbHard.TabIndex = 2;
            rbHard.Text = "тешко";
            rbHard.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbHard);
            groupBox1.Controls.Add(rbMedium);
            groupBox1.Controls.Add(rbEasy);
            groupBox1.Location = new Point(33, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(156, 128);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(12, 159);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 4;
            btnExit.Text = "Излези";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(121, 159);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 5;
            btnStart.Text = "Почни";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 9);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 6;
            label1.Text = "Избери режим";
            // 
            // ModeSelectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(235, 208);
            Controls.Add(label1);
            Controls.Add(btnStart);
            Controls.Add(btnExit);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ModeSelectionForm";
            Text = "Добредојде!";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rbEasy;
        private RadioButton rbMedium;
        private RadioButton rbHard;
        private GroupBox groupBox1;
        private Button btnExit;
        private Button btnStart;
        private Label label1;
    }
}