/*  Created by: Jackson Rawes
 *  Project: Brick Breaker
 *  Date: October 20 2020
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Xml;

namespace BrickBreaker
{

    public partial class GameScreen : UserControl
    {
        
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown;

        // Game values
        int lives;

        // Paddle and Ball objects
        Paddle paddle;
        Ball ball;

        // list of all blocks for current level
        List<Block> blocks = new List<Block>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);


        // Fonts
        Font drawFont = new Font("Tahoma", 20);
        #endregion

        // Life Count Text Positions
        public int lifeCountX;
        public int lifeCountY;
        public int scoreCountX;
        public int scoreCountY;

        // Powerup Ints
        public int powerUpSize;
        public int powerUpEffect;


        //int boostSize, boostDraw, boostSpeed;
        List<powerUP> powerUpList = new List<powerUP>();

        //large paddle lot of balls faster shield bottom
        Random randGen = new Random();

        Random powerUpChance = new Random();
        Random powerUpGen = new Random();


        //List that will build highscores using a class to then commit them to a XML file
        List<Score> highScoreList = new List<Score>();
        int numericScore;


        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        public void HighScoreRead()
        {
            XmlReader reader = XmlReader.Create("Resources/HighScore.xml", null);

            reader.ReadToFollowing("HighScore");

            while (reader.Read())
            {
                //if (reader.NodeType == XmlNodeType.Text)
                //{
                    reader.ReadToFollowing("Score");

                    reader.ReadToNextSibling("numericScore");
                    string numericScore = reader.ReadString();

                    reader.ReadToNextSibling("name");
                    string name = reader.ReadString();

                    //reader.ReadToNextSibling("date");
                    //string date = reader.ReadString();

                    Score s = new Score(numericScore, name);
                    highScoreList.Add(s);
                //}

            }
            reader.Close();


            //Put in 3 more test scores then break point to ensure they're there

            if (Convert.ToInt32(highScoreList[highScoreList.Count - 1].numericScore) <= numericScore)
            {
                for (int i = 0; i <= highScoreList.Count; i++)
                {
                    if (Convert.ToInt32(highScoreList[i].numericScore) <= numericScore)
                    {
                        Score s = new Score(Convert.ToString(numericScore), "");
                        highScoreList.Insert(i, s);
                        break;
                    }
                }
            }
            if (highScoreList.Count > 3)
            {
                highScoreList.RemoveAt(3);
            }

        }

        public void HighScoreWrite()
        {
            XmlWriter writer = XmlWriter.Create("Resources/HighScore.xml", null);

            writer.WriteStartElement("HighScore");

            foreach (Score s in highScoreList)
            {
                writer.WriteStartElement("Score");

                writer.WriteElementString("numericScore", s.numericScore);
                writer.WriteElementString("name", s.name);
                //writer.WriteElementString("date", s.date);

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();      
        }
  

        public void OnStart()
        {
            //set life counter
            lives = 3;

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddleSpeed = 8;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = this.Height - paddle.height - 80;

            // Setting up powerup values
            powerUpSize = 35;

            // Creates a new ball
            int xSpeed = 6;
            int ySpeed = 6;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

            #region Creates blocks for generic level. Need to replace with code that loads levels.
            
            //TODO - replace all the code in this region eventually with code that loads levels from xml files
            
            blocks.Clear();
            int x = 10;

            while (blocks.Count < 12)
            {
                x += 57;
                Block b1 = new Block(x, 10, 1, Color.White);
                blocks.Add(b1);
            }

            #endregion

            // start the game engine loop
            gameTimer.Enabled = true;

            // Game Start Pause
            TPaddleReset();
            ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
            ball.y = (this.Height - paddle.height) - 85;
            TPause();

            lifeCountX = this.Width - this.Width / 8;
            lifeCountY = this.Height - this.Height / 8;
            scoreCountX = this.Width / 8;
            scoreCountY = this.Height - this.Height / 8;
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            // Move the paddle
            if (leftArrowDown && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width))
            {
                paddle.Move("right");
            }

            // Move ball
            ball.Move();

            // Move and collide with Powerups
            foreach (powerUP p in powerUpList)
            {
                p.Fall();
            }

            if (powerUpList.Count > 0)
            {
                if (powerUpList[0].y >= this.Height)
                {
                    powerUpList.RemoveAt(0);
                    numericScore = numericScore - 50;
                }
                foreach (powerUP p in powerUpList)
                {
                    if (p.powerUpCollide(paddle))
                    {
                        int i = powerUpList.IndexOf(p);
                        powerUpEffect = p.type;
                        powerUpList.RemoveAt(i);
                        paddle.PoweredUp(powerUpEffect);
                    }
                }

            }


            // Check for collision with top and side walls
            ball.WallCollision(this);

            // Check for ball hitting bottom of screen
            if (ball.BottomCollision(this))
            {
                lives--;

                // Moves the ball back to origin
                TPaddleReset();

                ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                ball.y = (this.Height - paddle.height) - 85;

                TPause();

                if (lives == 0)
                {
                    gameTimer.Enabled = false;
                    OnEnd();
                }
            }
            // Check for collision of ball with paddle, (incl. paddle movement)
            ball.PaddleCollision(paddle, leftArrowDown, rightArrowDown);

            // Check if ball has collided with any blocks
            foreach (Block b in blocks)
            {
                if (ball.BlockCollision(b))
                {
                    PowerUpGeneration();
                
                    numericScore = numericScore + 100;


                    blocks.Remove(b);

                    if (blocks.Count == 0)
                    {
                        gameTimer.Enabled = false;
                        OnEnd();
                    }

                    break;

                }
            }


            SolidBrush boostBrush = new SolidBrush(Color.OliveDrab);

            //redraw the screen
            Refresh();
        }


        public void OnEnd()
        {
            // Goes to the game over screen
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();
            
            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            form.Controls.Add(ps);
            form.Controls.Remove(this);

             HighScoreRead();
             HighScoreWrite();
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws powerups
            if (powerUpList.Count > 0)
            {
                foreach (powerUP b in powerUpList)
                {
                    e.Graphics.FillEllipse(blockBrush, b.x, b.y, b.size, b.size);
                }
            }

            // Draws paddle
            paddleBrush.Color = paddle.colour;
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            // Draws blocks
            foreach (Block b in blocks)
            {
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
            }

            // Draws ball
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);

            // Draws game screen text
            e.Graphics.DrawString(numericScore.ToString(), drawFont, ballBrush, scoreCountX, scoreCountY, null);
            e.Graphics.DrawString(lives.ToString(), drawFont, ballBrush, lifeCountX, lifeCountY, null);
        }

        public void TPause() // Breifly pauses the game at the start and after a death
        {
            ball.stop();
            paddle.stop();
            Form1.pause = 0;
            gameTimer.Enabled = false;
            pauseTimer.Enabled = true;
        }

        private void PauseTimer_Tick(object sender, EventArgs e)
        {
            Form1.pause++;

            if (Form1.pause >= 2)
            {
                ball.go();
                paddle.go();
                gameTimer.Enabled = true;
                pauseTimer.Enabled = false;
            }
        }

        public void TPaddleReset()
        {
            paddle.x = ((this.Width / 2) - (paddle.width / 2));
            paddle.y = (this.Height - paddle.height) - 60;

        }

        public void PowerUpGeneration()
        {
            int dropChance = powerUpChance.Next(1, 4);

            if (dropChance == 1)
            {
                int typeChance = powerUpGen.Next(1, 7);

                powerUP newPowerUp = new powerUP(ball.x, ball.y, typeChance, powerUpSize);
                powerUpList.Add(newPowerUp);
            }
        }
        public void FreezePowerup()
        {

        }

        public void ShieldPowerup()
        {

        }

        public void FirePowerup()
        {

        }

        public void MultiPowerup()
        {

        }

        public void LengthPowerup()
        {

        }
        public void DoublePowerup()
        {

        }
    }
}
