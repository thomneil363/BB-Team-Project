using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class HighscoresScreen : UserControl
    {
        public HighscoresScreen()
        {
            InitializeComponent();
        }

        #region if space is pressed go back to the menu
        private void HighscoresScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player button presses
            switch (e.KeyCode)
            {
                case Keys.Space:
                    // Goes to the menu screen
                    MenuScreen ms = new MenuScreen();
                    Form form = this.FindForm();

                    form.Controls.Add(ms);
                    form.Controls.Remove(this);

                    ms.Location = new Point((form.Width - ms.Width) / 2, (form.Height - ms.Height) / 2);
                    break;
            }
        }
        #endregion if space is pressed go back to the menu
    }
}
