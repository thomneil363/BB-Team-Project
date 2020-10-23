using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace BrickBreaker
{
    public partial class NameInputScreen : UserControl
    {
        #region variable declarations

        //player name global string
        public static string playerName;

        //booleans for key presses
        Boolean upArrowDown, downArrowDown, leftArrowDown, rightArrowDown;

        //booleans for checking which label the user is on
        Boolean char1Selected, char2Selected, char3Selected;

        //soundplayer for menu sound
        SoundPlayer menuSound = new SoundPlayer(Properties.Resources.menuSound);

        //integers corresponding to each label's letter
        int i1 = 0;
        int i2 = 0;
        int i3 = 0;

        //create a list with for letters A-Z
        List<string> letters = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "Y", "X", "Z", };

        #endregion variable declarations

        #region component initialization and general setup
        public NameInputScreen()
        {
            InitializeComponent();
            OnStart();
        }
        #endregion component initialization and general setup

        #region initial setup
        public void OnStart()
        {
            //set char1 to true and the others to false
            char1Selected = true;
            char2Selected = false;
            char3Selected = false;
        }
        #endregion initial setup

        #region key down and up
        private void NameInputScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Space:
                    // Goes to the game screen
                    GameScreen gs = new GameScreen();
                    Form form = this.FindForm();

                    form.Controls.Add(gs);
                    form.Controls.Remove(this);

                    gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);

                    //set the player name
                    playerName = nameInput1.Text + nameInput2.Text + nameInput3.Text;
                    break;
            }
        }

        private void NameInputScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player button releases
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }
        #endregion key down and up

        #region name timer
        private void nameTimer_Tick(object sender, EventArgs e)
        {
            #region char1
            if (char1Selected == true)
            {
                //highlight the letter selected
                nameInput1.BackColor = Color.DarkGoldenrod;
                nameInput2.BackColor = Color.Black;
                nameInput3.BackColor = Color.Black;

                #region letter selection
                //if up is pressed, go to the next letter in the alphabet
                if (upArrowDown == true)
                {
                    i1++;
                    LetterLoop();
                    nameInput1.Text = letters[i1];

                    Thread.Sleep(150);
                }
                //if down is pressed, go to the previous letter in the alphabet
                if (downArrowDown == true)
                {
                    i1--;
                    LetterLoop();
                    nameInput1.Text = letters[i1];

                    Thread.Sleep(150);
                }
                //if right is pressed, go to the next letter
                if (rightArrowDown == true)
                {
                    char1Selected = false;
                    char2Selected = true;
                    char3Selected = false;

                    menuSound.Play();

                    Thread.Sleep(150);
                    return;
                }
                #endregion letter selection
            }
            #endregion char1

            #region char2
            if (char2Selected == true)
            {
                //highlight the letter selected
                nameInput1.BackColor = Color.Black;
                nameInput2.BackColor = Color.DarkGoldenrod;
                nameInput3.BackColor = Color.Black;

                #region letter selection
                //if up is pressed, go to the next letter in the alphabet
                if (upArrowDown == true)
                {
                    i2++;
                    LetterLoop();
                    nameInput2.Text = letters[i2];

                    Thread.Sleep(150);
                }
                //if down is pressed, go to the previous letter in the alphabet
                if (downArrowDown == true)
                {
                    i2--;
                    LetterLoop();
                    nameInput2.Text = letters[i2];

                    Thread.Sleep(150);
                }
                //if left is pressed, go to the previous letter
                if (leftArrowDown == true)
                {
                    char1Selected = true;
                    char2Selected = false;
                    char3Selected = false;

                    menuSound.Play();

                    Thread.Sleep(150);
                    return;
                }
                //if right is pressed, go to the next letter
                if (rightArrowDown == true)
                {
                    char1Selected = false;
                    char2Selected = false;
                    char3Selected = true;

                    menuSound.Play();

                    Thread.Sleep(150);
                    return;
                }
                #endregion letter selection
            }
            #endregion char2

            #region char3
            if (char3Selected == true)
            {
                //highlight the letter selected
                nameInput1.BackColor = Color.Black;
                nameInput2.BackColor = Color.Black;
                nameInput3.BackColor = Color.DarkGoldenrod;

                #region letter selection
                //if up is pressed, go to the next letter in the alphabet
                if (upArrowDown == true)
                {
                    i3++;
                    LetterLoop();
                    nameInput3.Text = letters[i3];

                    Thread.Sleep(150);
                }
                //if down is pressed, go to the previous letter in the alphabet
                if (downArrowDown == true)
                {
                    i3--;
                    LetterLoop();
                    nameInput3.Text = letters[i3];

                    Thread.Sleep(150);
                }
                //if left is pressed, go to the previous letter
                if (leftArrowDown == true)
                {
                    char1Selected = false;
                    char2Selected = true;
                    char3Selected = false;

                    menuSound.Play();

                    Thread.Sleep(150);
                    return;
                }
                #endregion letter selection
            }
            #endregion char3
        }
        #endregion name timer

        #region letter loop method
        private void LetterLoop()
        {
            //if i1, i2, or i3 get to the beginning or the end of the alphabet, set it to the opposite
            //(aka if one more than "Z", go to "A" and vise versa)
            if (i1 == 26) { i1 = 0; }
            if (i1 == -1) { i1 = 25; }

            if (i2 == 26) { i2 = 0; }
            if (i2 == -1) { i2 = 25; }

            if (i3 == 26) { i3 = 0; }
            if (i3 == -1) { i3 = 25; }
        }
        #endregion letter loop method

    }
}
