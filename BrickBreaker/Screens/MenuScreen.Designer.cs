namespace BrickBreaker
{
    partial class MenuScreen
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
            this.components = new System.ComponentModel.Container();
            this.menuTimer = new System.Windows.Forms.Timer(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.brick1 = new System.Windows.Forms.Label();
            this.brick2 = new System.Windows.Forms.Label();
            this.brick3 = new System.Windows.Forms.Label();
            this.brick4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // menuTimer
            // 
            this.menuTimer.Enabled = true;
            this.menuTimer.Interval = 20;
            this.menuTimer.Tick += new System.EventHandler(this.menuTimer_Tick);
            // 
            // titleLabel
            // 
            this.titleLabel.Image = global::BrickBreaker.Properties.Resources.titleSprite;
            this.titleLabel.Location = new System.Drawing.Point(350, 125);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(375, 250);
            this.titleLabel.TabIndex = 0;
            // 
            // brick1
            // 
            this.brick1.Image = global::BrickBreaker.Properties.Resources.yellowBrick;
            this.brick1.Location = new System.Drawing.Point(414, 22);
            this.brick1.Name = "brick1";
            this.brick1.Size = new System.Drawing.Size(59, 29);
            this.brick1.TabIndex = 1;
            // 
            // brick2
            // 
            this.brick2.Image = global::BrickBreaker.Properties.Resources.orangeBrick;
            this.brick2.Location = new System.Drawing.Point(587, 68);
            this.brick2.Name = "brick2";
            this.brick2.Size = new System.Drawing.Size(59, 29);
            this.brick2.TabIndex = 2;
            // 
            // brick3
            // 
            this.brick3.Image = global::BrickBreaker.Properties.Resources.greenBrick;
            this.brick3.Location = new System.Drawing.Point(393, 441);
            this.brick3.Name = "brick3";
            this.brick3.Size = new System.Drawing.Size(59, 29);
            this.brick3.TabIndex = 3;
            // 
            // brick4
            // 
            this.brick4.Image = global::BrickBreaker.Properties.Resources.blueBrick;
            this.brick4.Location = new System.Drawing.Point(666, 398);
            this.brick4.Name = "brick4";
            this.brick4.Size = new System.Drawing.Size(59, 29);
            this.brick4.TabIndex = 4;
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.Controls.Add(this.brick4);
            this.Controls.Add(this.brick3);
            this.Controls.Add(this.brick2);
            this.Controls.Add(this.brick1);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(850, 550);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MenuScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MenuScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer menuTimer;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label brick1;
        private System.Windows.Forms.Label brick2;
        private System.Windows.Forms.Label brick3;
        private System.Windows.Forms.Label brick4;
    }
}
