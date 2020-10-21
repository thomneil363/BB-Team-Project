namespace BrickBreaker
{
    partial class GameOverScreen
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
            this.gameoverTitleLabel = new System.Windows.Forms.Label();
            this.brick1 = new System.Windows.Forms.Label();
            this.brick2 = new System.Windows.Forms.Label();
            this.brick3 = new System.Windows.Forms.Label();
            this.brick4 = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameoverTitleLabel
            // 
            this.gameoverTitleLabel.Image = global::BrickBreaker.Properties.Resources.gameoverTitleSprite;
            this.gameoverTitleLabel.Location = new System.Drawing.Point(250, 75);
            this.gameoverTitleLabel.Name = "gameoverTitleLabel";
            this.gameoverTitleLabel.Size = new System.Drawing.Size(350, 330);
            this.gameoverTitleLabel.TabIndex = 1;
            // 
            // brick1
            // 
            this.brick1.Image = global::BrickBreaker.Properties.Resources.pinkBrick;
            this.brick1.Location = new System.Drawing.Point(62, 301);
            this.brick1.Name = "brick1";
            this.brick1.Size = new System.Drawing.Size(61, 33);
            this.brick1.TabIndex = 2;
            // 
            // brick2
            // 
            this.brick2.Image = global::BrickBreaker.Properties.Resources.pinkBrick;
            this.brick2.Location = new System.Drawing.Point(683, 233);
            this.brick2.Name = "brick2";
            this.brick2.Size = new System.Drawing.Size(61, 33);
            this.brick2.TabIndex = 3;
            // 
            // brick3
            // 
            this.brick3.Image = global::BrickBreaker.Properties.Resources.pinkBrick;
            this.brick3.Location = new System.Drawing.Point(167, 111);
            this.brick3.Name = "brick3";
            this.brick3.Size = new System.Drawing.Size(61, 33);
            this.brick3.TabIndex = 4;
            // 
            // brick4
            // 
            this.brick4.Image = global::BrickBreaker.Properties.Resources.pinkBrick;
            this.brick4.Location = new System.Drawing.Point(570, 26);
            this.brick4.Name = "brick4";
            this.brick4.Size = new System.Drawing.Size(61, 33);
            this.brick4.TabIndex = 5;
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.exitLabel.Location = new System.Drawing.Point(298, 454);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(259, 50);
            this.exitLabel.TabIndex = 7;
            this.exitLabel.Text = "Press SPACE to go back\r\nto the title screen. . .";
            this.exitLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GameOverScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.brick4);
            this.Controls.Add(this.brick3);
            this.Controls.Add(this.brick2);
            this.Controls.Add(this.brick1);
            this.Controls.Add(this.gameoverTitleLabel);
            this.DoubleBuffered = true;
            this.Name = "GameOverScreen";
            this.Size = new System.Drawing.Size(850, 550);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameOverScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gameoverTitleLabel;
        private System.Windows.Forms.Label brick1;
        private System.Windows.Forms.Label brick2;
        private System.Windows.Forms.Label brick3;
        private System.Windows.Forms.Label brick4;
        private System.Windows.Forms.Label exitLabel;
    }
}
