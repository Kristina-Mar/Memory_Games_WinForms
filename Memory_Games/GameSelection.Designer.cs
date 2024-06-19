namespace Memory_Games
{
    partial class GameSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSelection));
            buttonGame1 = new Button();
            buttonGame2 = new Button();
            buttonGame3 = new Button();
            gameDescription1 = new RichTextBox();
            panel1 = new Panel();
            panel5 = new Panel();
            gameDescription2 = new RichTextBox();
            panel6 = new Panel();
            gameDescription3 = new RichTextBox();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // buttonGame1
            // 
            buttonGame1.Location = new Point(72, 273);
            buttonGame1.Name = "buttonGame1";
            buttonGame1.Size = new Size(96, 57);
            buttonGame1.TabIndex = 0;
            buttonGame1.Text = "Play Order, order!";
            buttonGame1.UseVisualStyleBackColor = true;
            buttonGame1.Click += buttonGame1_Click;
            // 
            // buttonGame2
            // 
            buttonGame2.Location = new Point(70, 270);
            buttonGame2.Name = "buttonGame2";
            buttonGame2.Size = new Size(96, 57);
            buttonGame2.TabIndex = 1;
            buttonGame2.Text = "Play Find the imposters";
            buttonGame2.UseVisualStyleBackColor = true;
            buttonGame2.Click += buttonGame2_Click;
            // 
            // buttonGame3
            // 
            buttonGame3.Location = new Point(71, 270);
            buttonGame3.Name = "buttonGame3";
            buttonGame3.Size = new Size(96, 57);
            buttonGame3.TabIndex = 2;
            buttonGame3.Text = "Play Seeing double?";
            buttonGame3.UseVisualStyleBackColor = true;
            buttonGame3.Click += buttonGame3_Click;
            // 
            // gameDescription1
            // 
            gameDescription1.BackColor = SystemColors.Control;
            gameDescription1.BorderStyle = BorderStyle.None;
            gameDescription1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            gameDescription1.Location = new Point(18, 14);
            gameDescription1.Name = "gameDescription1";
            gameDescription1.ScrollBars = RichTextBoxScrollBars.None;
            gameDescription1.Size = new Size(204, 206);
            gameDescription1.TabIndex = 5;
            gameDescription1.Text = "Order, order!\n\nYou will see 10 pictures one by one.\n\nAfter that, you will get all the pictures at once and your task will be to put them in the same order they appeared in at the start of the game.";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(gameDescription1);
            panel1.Controls.Add(buttonGame1);
            panel1.Location = new Point(33, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(244, 356);
            panel1.TabIndex = 6;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(gameDescription2);
            panel5.Controls.Add(buttonGame2);
            panel5.Location = new Point(321, 76);
            panel5.Name = "panel5";
            panel5.Size = new Size(244, 356);
            panel5.TabIndex = 9;
            // 
            // gameDescription2
            // 
            gameDescription2.BackColor = SystemColors.Control;
            gameDescription2.BorderStyle = BorderStyle.None;
            gameDescription2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            gameDescription2.Location = new Point(20, 14);
            gameDescription2.Name = "gameDescription2";
            gameDescription2.ScrollBars = RichTextBoxScrollBars.None;
            gameDescription2.Size = new Size(204, 230);
            gameDescription2.TabIndex = 5;
            gameDescription2.Text = resources.GetString("gameDescription2.Text");
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(gameDescription3);
            panel6.Controls.Add(buttonGame3);
            panel6.Location = new Point(609, 76);
            panel6.Name = "panel6";
            panel6.Size = new Size(244, 356);
            panel6.TabIndex = 10;
            // 
            // gameDescription3
            // 
            gameDescription3.BackColor = SystemColors.Control;
            gameDescription3.BorderStyle = BorderStyle.None;
            gameDescription3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            gameDescription3.Location = new Point(18, 14);
            gameDescription3.Name = "gameDescription3";
            gameDescription3.ScrollBars = RichTextBoxScrollBars.None;
            gameDescription3.Size = new Size(204, 182);
            gameDescription3.TabIndex = 5;
            gameDescription3.Text = "Seeing double?\n\n31 pictures will appear on the screen one by one. One of them will only be shown once.\n\nYour task will be to correctly identify the one lone picture.";
            // 
            // GameSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 514);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel1);
            Name = "GameSelection";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Memory games";
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonGame1;
        private Button buttonGame2;
        private Button buttonGame3;
        private RichTextBox gameDescription1;
        private Panel panel1;
        private Panel panel5;
        private RichTextBox gameDescription2;
        private Panel panel6;
        private RichTextBox gameDescription3;
    }
}
