namespace BrickBreaker
{
    partial class HighscoresScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.highScoreLabel = new System.Windows.Forms.Label();
            this.highscoreBox = new System.Windows.Forms.Label();
            this.highscoreTitle = new System.Windows.Forms.Label();
            this.brick1 = new System.Windows.Forms.Label();
            this.brick3 = new System.Windows.Forms.Label();
            this.brick2 = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.highScoreLabel.Location = new System.Drawing.Point(460, 65);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(320, 420);
            this.highScoreLabel.TabIndex = 1;
            this.highScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // highscoreBox
            // 
            this.highscoreBox.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoreBox.ForeColor = System.Drawing.Color.White;
        //    this.highscoreBox.Image = global::BrickBreaker.Properties.Resources.highscoreBox;
            this.highscoreBox.Location = new System.Drawing.Point(420, 25);
            this.highscoreBox.Name = "highscoreBox";
            this.highscoreBox.Size = new System.Drawing.Size(400, 500);
            this.highscoreBox.TabIndex = 0;
            this.highscoreBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // highscoreTitle
            // 
            this.highscoreTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoreTitle.ForeColor = System.Drawing.Color.White;
//            this.highscoreTitle.Image = global::BrickBreaker.Properties.Resources.highscoreTitleSprite;
            this.highscoreTitle.Location = new System.Drawing.Point(71, 85);
            this.highscoreTitle.Name = "highscoreTitle";
            this.highscoreTitle.Size = new System.Drawing.Size(255, 180);
            this.highscoreTitle.TabIndex = 2;
            this.highscoreTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // brick1
            // 
            this.brick1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brick1.ForeColor = System.Drawing.Color.White;
//            this.brick1.Image = global::BrickBreaker.Properties.Resources.greenBrick;
            this.brick1.Location = new System.Drawing.Point(321, 104);
            this.brick1.Name = "brick1";
            this.brick1.Size = new System.Drawing.Size(58, 32);
            this.brick1.TabIndex = 3;
            this.brick1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // brick3
            // 
            this.brick3.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brick3.ForeColor = System.Drawing.Color.White;
  //          this.brick3.Image = global::BrickBreaker.Properties.Resources.greenBrick;
            this.brick3.Location = new System.Drawing.Point(40, 25);
            this.brick3.Name = "brick3";
            this.brick3.Size = new System.Drawing.Size(58, 32);
            this.brick3.TabIndex = 4;
            this.brick3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // brick2
            // 
            this.brick2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brick2.ForeColor = System.Drawing.Color.White;
   //         this.brick2.Image = global::BrickBreaker.Properties.Resources.greenBrick;
            this.brick2.Location = new System.Drawing.Point(144, 309);
            this.brick2.Name = "brick2";
            this.brick2.Size = new System.Drawing.Size(58, 32);
            this.brick2.TabIndex = 5;
            this.brick2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitLabel.ForeColor = System.Drawing.Color.Lime;
            this.exitLabel.Location = new System.Drawing.Point(72, 435);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(259, 50);
            this.exitLabel.TabIndex = 6;
            this.exitLabel.Text = "Press SPACE to go back\r\nto the title screen. . .";
            this.exitLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HighscoresScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.brick2);
            this.Controls.Add(this.brick3);
            this.Controls.Add(this.brick1);
            this.Controls.Add(this.highscoreTitle);
            this.Controls.Add(this.highScoreLabel);
            this.Controls.Add(this.highscoreBox);
            this.DoubleBuffered = true;
            this.Name = "HighscoresScreen";
            this.Size = new System.Drawing.Size(850, 550);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HighscoresScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label highscoreBox;
        private System.Windows.Forms.Label highScoreLabel;
        private System.Windows.Forms.Label highscoreTitle;
        private System.Windows.Forms.Label brick1;
        private System.Windows.Forms.Label brick3;
        private System.Windows.Forms.Label brick2;
        private System.Windows.Forms.Label exitLabel;
    }
}
