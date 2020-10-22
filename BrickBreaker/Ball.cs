using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker

{ // Designed by Thomas Neilson
    public class Ball
    {
        public int x, y, xSpeed, ySpeed, size; 
        public Color colour;
        public bool movingRight;

        public static Random rand = new Random();

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed, int _ballSize)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            size = _ballSize;
        }

        public void Move()
        {
            x = x + xSpeed;
            y = y + ySpeed;
        }

        public bool BlockCollision(Block b)
        {
            // Main block generation
            Rectangle blockRec = new Rectangle(b.x, b.y, b.width, b.height);
            // Generation for hitboxes for each side of the box
            Rectangle topRec = new Rectangle(b.x, b.y, b.width, 4);
            Rectangle bottomRec = new Rectangle(b.x, b.y + b.height - 4, b.width, 4);
            Rectangle rightRec = new Rectangle(b.x + b.width - 4, b.y, 4, b.height);
            Rectangle leftRec = new Rectangle(b.x, b.y, 4, b.height);
            // Ball hitbox generation
            Rectangle ballRec = new Rectangle(x, y, size, size);

            // Collision mechanics for blocks
            if (ballRec.IntersectsWith(topRec))
            {
                Up();
            }
            else if (ballRec.IntersectsWith(bottomRec))
            {
                Down();
            }
            if (ballRec.IntersectsWith(rightRec))
            {
                Right();
            }
            else if (ballRec.IntersectsWith(leftRec))
            {
                Left();
            }

            // return statement (don't touch)
            return blockRec.IntersectsWith(ballRec);
        }
        //Paddle Collision Code
        public void PaddleCollision(Paddle p, bool pMovingLeft, bool pMovingRight)
        {
            // Ball and paddle generation
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);
            // Paddle side generation
            Rectangle rightRec = new Rectangle(p.x + p.width - 4, p.y - 8, 4, p.height - 8);
            Rectangle leftRec = new Rectangle(p.x, p.y - 8, 4, p.height - 8);

            if (ballRec.IntersectsWith(paddleRec))
            {
                // Always set y movement to up when colliding with paddle.
                Up();

                // Checking if ball is hitting the paddle side
                if (ballRec.IntersectsWith(rightRec) || ballRec.IntersectsWith(leftRec))
                {
                    // When colliding with side of paddle, flip x direction
                    if (ballRec.IntersectsWith(rightRec))
                    {
                        Left(); // When the right side is hit, move left
                    }
                    else if (ballRec.IntersectsWith(leftRec))
                    {
                        Right(); // When the left side is hit, move right
                    }
                }
                else
                {
                    // Set direction to the currently moving direction
                    if (pMovingLeft)
                    {
                        // Changing ball speed
                        MovingBounceAngle(p.x, p.width);

                        // Changing ball direction
                        Left();
                    }
                    else if (pMovingRight)
                    {
                        // Changing ball speed
                        MovingBounceAngle(p.x, p.width);

                        // Changing ball Direction
                        Right();
                    }
                    else
                    {
                        // Noting the direction the ball is moving
                        int direction;

                        if (xSpeed < 0)
                        {
                            direction = -1;
                        }
                        else
                        {
                            direction = 1;
                        }

                        // Changing ball speed
                        StillBounceAngle(p.x, p.width);

                        // Changing ball Direction
                        xSpeed = xSpeed * direction;
                    }
                }
            }
        }

        public void WallCollision(UserControl UC)
        {
            // Collision with right wall
            if (x <= 0)
            {
                Right();
            }
            // Collision with left wall
            if (x >= (UC.Width - size))
            {
                Left();
            }
            // Collision with top wall
            if (y <= 2)
            {
                Down();
            }
        }

        public bool BottomCollision(UserControl UC)
        {
            Boolean didCollide = false;

            if (y >= UC.Height)
            {
                didCollide = true;
                ySpeed = -6;
                xSpeed = 6;
            }

            return didCollide;
        }


        private void MovingBounceAngle(int pX, int pWidth)
        {
            int collisionPoint = (x + (size / 2)) - pX;

            if (collisionPoint >= (pWidth * .80)) // Top 25%
            {
                xSpeed = 8;
                setY();
            }
            else if (collisionPoint >= (pWidth * .70))
            {
                xSpeed = 7;
                setY();
            }
            else if (collisionPoint >= (pWidth * .60))
            {
                xSpeed = 6;
                setY();
            }
            else if (collisionPoint >= (pWidth * .40)) // Middle Point
            {
                xSpeed = 5;
                setY();
            }
            else if (collisionPoint >= (pWidth * .30))
            {
                xSpeed = 6;
                setY();
            }
            else if (collisionPoint >= (pWidth * .20))
            {
                xSpeed = 7;
                setY();
            }
            else // Bottom 25%
            {
                xSpeed = 8;
                setY();
            }
        }

        private void StillBounceAngle(int pX, int pWidth)
        {
            int collisionPoint = (x + (size / 2)) - pX;

            if (collisionPoint >= (pWidth * .80)) // Top 20%
            {
                xSpeed = 6;
                setY();
            }
            else if (collisionPoint >= (pWidth * .70))
            {
                xSpeed = 4;
                setY();
            }
            else if (collisionPoint >= (pWidth * .60))
            {
                xSpeed = 3;
                setY();
            }
            else if (collisionPoint >= (pWidth * .40)) // Middle Point
            {
                xSpeed = 2;
                setY();
            }
            else if (collisionPoint >= (pWidth * .30))
            {
                xSpeed = 3;
                setY();
            }
            else if (collisionPoint >= (pWidth * .20))
            {
                xSpeed = 4;
                setY();
            }
            else // Bottom 20%
            {
                xSpeed = 6;
                setY();
            }
        }

        public void Left() // Convenience Method for making ball move left
        {
            xSpeed = -Math.Abs(xSpeed);
        }
        public void Right() // Convenience Method for making ball move right
        {
            xSpeed = Math.Abs(xSpeed);
        }
        public void Up() // Convenience Method for making ball move up
        {
            ySpeed = -Math.Abs(ySpeed);
        }
        public void Down() // Convenience Method for making ball move down
        {
            ySpeed = Math.Abs(ySpeed);
        }
        private void setY()
        {
            ySpeed = (12 - xSpeed) * -1;

        }
        public void stop()
        {
            xSpeed = 0;
            ySpeed = 0;
        }
        public void go()
        {
            xSpeed = -6;
            ySpeed = -6;
        }
    }
}

