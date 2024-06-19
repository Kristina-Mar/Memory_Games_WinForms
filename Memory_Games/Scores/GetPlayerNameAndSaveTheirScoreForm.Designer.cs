namespace Memory_Games
{
    partial class GetPlayerNameAndSaveTheirScoreForm
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
            labelCongratulations = new Label();
            labelCommand = new Label();
            textBoxPlayerName = new TextBox();
            buttonSubmitName = new Button();
            labelWarning = new Label();
            SuspendLayout();
            // 
            // labelCongratulations
            // 
            labelCongratulations.AutoSize = true;
            labelCongratulations.Font = new Font("Arial", 9.75F);
            labelCongratulations.Location = new Point(23, 33);
            labelCongratulations.Name = "labelCongratulations";
            labelCongratulations.Size = new Size(337, 16);
            labelCongratulations.TabIndex = 0;
            labelCongratulations.Text = "Congratulations! You made it onto the list of best players!";
            // 
            // labelCommand
            // 
            labelCommand.AutoSize = true;
            labelCommand.Font = new Font("Arial", 9.75F);
            labelCommand.Location = new Point(23, 75);
            labelCommand.Name = "labelCommand";
            labelCommand.Size = new Size(159, 16);
            labelCommand.TabIndex = 1;
            labelCommand.Text = "Please type in your name:";
            // 
            // textBoxPlayerName
            // 
            textBoxPlayerName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxPlayerName.Location = new Point(23, 118);
            textBoxPlayerName.MaxLength = 12;
            textBoxPlayerName.Name = "textBoxPlayerName";
            textBoxPlayerName.Size = new Size(219, 26);
            textBoxPlayerName.TabIndex = 2;
            textBoxPlayerName.KeyDown += textBoxPlayerName_KeyDown;
            // 
            // buttonSubmitName
            // 
            buttonSubmitName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonSubmitName.Location = new Point(149, 162);
            buttonSubmitName.Name = "buttonSubmitName";
            buttonSubmitName.Size = new Size(83, 34);
            buttonSubmitName.TabIndex = 3;
            buttonSubmitName.Text = "Submit";
            buttonSubmitName.UseVisualStyleBackColor = true;
            buttonSubmitName.Click += SubmitNameAndAddScoreToBestScores;
            // 
            // labelWarning
            // 
            labelWarning.AutoSize = true;
            labelWarning.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelWarning.ForeColor = Color.Red;
            labelWarning.Location = new Point(252, 123);
            labelWarning.Name = "labelWarning";
            labelWarning.Size = new Size(108, 16);
            labelWarning.TabIndex = 4;
            labelWarning.Text = "Name is required!";
            // 
            // GetPlayerNameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 225);
            Controls.Add(labelWarning);
            Controls.Add(buttonSubmitName);
            Controls.Add(textBoxPlayerName);
            Controls.Add(labelCommand);
            Controls.Add(labelCongratulations);
            Name = "GetPlayerNameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Congratulations!";
            FormClosed += ShowTopScoresAfterClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCongratulations;
        private Label labelCommand;
        private TextBox textBoxPlayerName;
        private Button buttonSubmitName;
        private Label labelWarning;
    }
}