using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using WMPLib;

namespace BrickBreaker
{
    //Test
    public partial class SettingsScreen : UserControl
    {
        #region variable declarations

        //booleans for key presses
        Boolean upArrowDown, downArrowDown, spaceDown;

        //booleans for fullscreen and mute toggles
        Boolean fullscreen, mute;

        //rectangles for menu buttons
        Rectangle muteRec, fullscreenRec, exitRec;

        //rectangle for player ball
        Rectangle playerRec;

        //images for button sprites and title
        Image muteButtonSprite, fullscreenButtonSprite, exitSettingsButtonSprite, playerSprite;

        #endregion variable declarations

        #region component initialization and general setup
        public SettingsScreen()
        {
            InitializeComponent();
            OnStart();

            //setup sprites for the menu
            muteButtonSprite = Properties.Resources.muteButtonSprite;
            fullscreenButtonSprite = Properties.Resources.fullscreenButtonSprite;
            exitSettingsButtonSprite = Properties.Resources.exitSettingsButtonSprite;
            playerSprite = Properties.Resources.ballSprite;
        }
        #endregion component initialization and general setup

        #region menu setup
        public void OnStart()
        {
            //set menu button sizes and positions
            muteRec = new Rectangle(75, 200, 150, 50);
            fullscreenRec = new Rectangle(75, 300, 150, 50);
            exitRec = new Rectangle(75, 400, 150, 50);

            //set player location
            playerRec = new Rectangle(muteRec.X + 20, muteRec.Y + 15, 10, 10);
        }
        #endregion menu setup

        #region key down and up
        private void SettingsScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player button presses
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
            }
        }

        private void SettingsScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player button presses
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
            }
        }
        #endregion key down and up

        #region settings timer
        private void settingsTimer_Tick(object sender, EventArgs e)
        {
            ButtonMenu();
            Refresh();
        }
        #endregion settings timer

        #region paint graphics
        private void SettingsScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw menu buttons and player
            e.Graphics.DrawImage(muteButtonSprite, muteRec.X, muteRec.Y);
            e.Graphics.DrawImage(fullscreenButtonSprite, fullscreenRec.X, fullscreenRec.Y);
            e.Graphics.DrawImage(exitSettingsButtonSprite, exitRec.X, exitRec.Y);

            //draw player
            e.Graphics.DrawImage(playerSprite, playerRec.X, playerRec.Y);
        }
        #endregion paint graphics

        #region button menu method
        private void ButtonMenu()
        {
            #region mute
            if (playerRec.IntersectsWith(muteRec))
            {
                if (spaceDown == true)
                {
                    //used for volume toggle
                    WindowsMediaPlayer wmp = new WindowsMediaPlayer();

                    //toggle program mute
                    if (mute == true)
                    { 
                        wmp.settings.volume = 100;

                        mute = false;
                    }
                    if (mute == false)
                    {
                        wmp.settings.volume = 0;

                        mute = true;
                    }
                }
                if (downArrowDown == true)
                {
                    playerRec = new Rectangle(fullscreenRec.X + 20, fullscreenRec.Y + 15, 10, 10);
                    downArrowDown = false;

                    Thread.Sleep(150);
                }
            }
            #endregion play

            #region fullscreen
            if (playerRec.IntersectsWith(fullscreenRec))
            {
                //go into the highscores menu
                if (spaceDown == true)
                {
                    //toggle fullscreen
                    if (fullscreen == true)
                    {
                        Form f = this.FindForm();
                        f.WindowState = FormWindowState.Normal;
                        this.Location = new Point((f.Width - this.Width) / 2, (f.Height - this.Height) / 2); //center the screen
                        fullscreen = false;
                    }
                    else
                    {
                        Form f = this.FindForm();
                        f.WindowState = FormWindowState.Maximized;
                        this.Location = new Point((f.Width - this.Width) / 2, (f.Height - this.Height) / 2); //center the screen
                        fullscreen = true;
                    }

                    Thread.Sleep(150);
                }
                if (upArrowDown == true)
                {
                    playerRec = new Rectangle(muteRec.X + 20, muteRec.Y + 15, 10, 10);

                    Thread.Sleep(150);
                }
                if (downArrowDown == true)
                {
                    playerRec = new Rectangle(exitRec.X + 20, exitRec.Y + 15, 10, 10);
                    downArrowDown = false;

                    Thread.Sleep(150);
                }
            }
            #endregion highscores

            #region exit settings
            if (playerRec.IntersectsWith(exitRec))
            {
                //exit the settings screen
                if (spaceDown == true)
                {
                    //stop menu timer
                    settingsTimer.Enabled = false;

                    // Goes to the menu screen
                    MenuScreen ms = new MenuScreen();
                    Form form = this.FindForm();

                    form.Controls.Add(ms);
                    form.Controls.Remove(this);

                    ms.Location = new Point((form.Width - ms.Width) / 2, (form.Height - ms.Height) / 2);
                }
                if (upArrowDown == true)
                {
                    playerRec = new Rectangle(fullscreenRec.X + 20, fullscreenRec.Y + 15, 10, 10);

                    Thread.Sleep(150);
                }
            }
            #endregion exit settings
        }
        #endregion button menu method
    }
}
