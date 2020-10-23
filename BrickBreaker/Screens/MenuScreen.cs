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

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {
        #region variable declarations

        //booleans for key press
        Boolean upArrowDown, downArrowDown, spaceDown;

        //rectangles for menu buttons
        Rectangle playRec, highscoresRec, settingsRec, exitRec;

        //rectangle for player ball
        Rectangle playerRec;

        //images for button sprites and title
        Image playButtonSprite, highscoreButtonSprite, settingsButtonSprite, exitButtonSprite, playerSprite;

        #endregion variable declarations

        #region component initialization and general setup
        public MenuScreen()
        {
            InitializeComponent();
            OnStart();

            //setup sprites for the menu
            playButtonSprite = Properties.Resources.playButtonSprite;
            highscoreButtonSprite = Properties.Resources.highscoresButtonSprite;
            settingsButtonSprite = Properties.Resources.settingsButtonSprite;
            exitButtonSprite = Properties.Resources.exitButtonSprite;
            playerSprite = Properties.Resources.ballSprite;
        }
        #endregion component initialization and general setup

        #region menu setup
        public void OnStart()
        {
            //set menu button sizes and positions
            playRec = new Rectangle(50, 100, 150, 50);
            highscoresRec = new Rectangle(50, 200, 150, 50);
            settingsRec = new Rectangle(50, 300, 150, 50);
            exitRec = new Rectangle(50, 400, 150, 50);

            //set player location
            playerRec = new Rectangle(playRec.X + 20, playRec.Y + 15, 10, 10);
        }
        #endregion menu setup

        #region key down and up
        private void MenuScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void MenuScreen_KeyUp(object sender, KeyEventArgs e)
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

        #region menu timer
        private void menuTimer_Tick(object sender, EventArgs e)
        {
            ButtonMenu();
            Refresh();
        }

        #endregion menu timer

        #region paint graphics
        private void MenuScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw menu buttons and player
            e.Graphics.DrawImage(playButtonSprite, playRec.X, playRec.Y);
            e.Graphics.DrawImage(highscoreButtonSprite, highscoresRec.X, highscoresRec.Y);
            e.Graphics.DrawImage(settingsButtonSprite, settingsRec.X, settingsRec.Y);
            e.Graphics.DrawImage(exitButtonSprite, exitRec.X, exitRec.Y);
            //draw player
            e.Graphics.DrawImage(playerSprite, playerRec.X, playerRec.Y);
        }
        #endregion paint graphics

        #region button menu method
        private void ButtonMenu()
        {
            #region play
            if (playerRec.IntersectsWith(playRec))
            {
                if (spaceDown == true)
                {
                    //stop menu timer
                    menuTimer.Enabled = false;

                    // Goes to the game screen
                    GameScreen gs = new GameScreen();
                    Form form = this.FindForm();

                    form.Controls.Add(gs);
                    form.Controls.Remove(this);

                    gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
                }
                if (downArrowDown == true)
                {
                    playerRec = new Rectangle(highscoresRec.X + 20, highscoresRec.Y + 15, 10, 10);
                    downArrowDown = false;

                    Thread.Sleep(150);
                }
            }
            #endregion play

            #region highscores
            if (playerRec.IntersectsWith(highscoresRec))
            {
                //go into the highscores menu
                if (spaceDown == true)
                {
                    //stop menu timer
                    menuTimer.Enabled = false;

                    // Goes to the highscores screen
                    HighscoresScreen hs = new HighscoresScreen();
                    Form form = this.FindForm();

                    form.Controls.Add(hs);
                    form.Controls.Remove(this);

                    hs.Location = new Point((form.Width - hs.Width) / 2, (form.Height - hs.Height) / 2);
                }
                if (upArrowDown == true)
                {
                    playerRec = new Rectangle(playRec.X + 20, playRec.Y + 15, 10, 10);

                    Thread.Sleep(150);
                }
                if (downArrowDown == true)
                {
                    playerRec = new Rectangle(settingsRec.X + 20, settingsRec.Y + 15, 10, 10);
                    downArrowDown = false;

                    Thread.Sleep(150);
                }
            }
            #endregion highscores

            #region settings
            if (playerRec.IntersectsWith(settingsRec))
            {
                //go into the settings menu
                if (spaceDown == true)
                {
                    //stop menu timer
                    menuTimer.Enabled = false;

                    // Goes to the settings screen
                    SettingsScreen ss = new SettingsScreen();
                    Form form = this.FindForm();

                    form.Controls.Add(ss);
                    form.Controls.Remove(this);

                    ss.Location = new Point((form.Width - ss.Width) / 2, (form.Height - ss.Height) / 2);
                }
                if (upArrowDown == true)
                {
                    playerRec = new Rectangle(highscoresRec.X + 20, highscoresRec.Y + 15, 10, 10);

                    Thread.Sleep(150);
                }
                if (downArrowDown == true)
                {
                    playerRec = new Rectangle(exitRec.X + 20, exitRec.Y + 15, 10, 10);
                    downArrowDown = false;

                    Thread.Sleep(150);
                }
            }
            #endregion settings

            #region exit
            if (playerRec.IntersectsWith(exitRec))
            {
                //exit the game
                if (spaceDown == true)
                {
                    Application.Exit();
                }
                if (upArrowDown == true)
                {
                    playerRec = new Rectangle(settingsRec.X + 20, settingsRec.Y + 15, 10, 10);

                    Thread.Sleep(150);
                }
            }
            #endregion exit
        }
        #endregion button menu method

    }
}
