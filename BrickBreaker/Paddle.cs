using System.Drawing;

namespace BrickBreaker
{
    public class Paddle
    {
        public int x, y, width, height, speed, unclaimedScore;
        public Color colour;
        public bool frozen = false, shielded = false, firey = false, speedy = false, longer = false, doubled = false;
        public int frozenTimer;
        public int fireyTimer;
        public int speedyTimer;
        public int longerTimer;
        public int doubledTimer;

        public Paddle(int _x, int _y, int _width, int _height, int _speed, Color _colour)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            speed = _speed;
            colour = _colour;
        }

        public void Move(string direction)
        {
            if (direction == "left")
            {
                x -= speed;
            }
            if (direction == "right")
            {
                x += speed;
            }
        }
        public void stop()
        {
            speed = 0;
        }
        public void go()
        {
           speed = 8;
        }

        public void PoweredUp(int type)
        {
            // 1 is Freeze, 2 is Shield, 3 is Fire, 4 is Multi, 5 is Length, and 6 is Double

            if (type == 1) // For period of time, paddle speed is reduced
            {
                if (frozen == true)
                {
                    unclaimedScore += 50;
                }
                else
                {
                    frozen = true;
                    frozenTimer = 250;
                }
            }
            else if (type == 2) // Next hit to shield, run code to bounce instead of kill
            {
                if (shielded == true)
                {
                    unclaimedScore += 50;
                }
                shielded = true;
            }
            else if (type == 3)
            {
                if (firey == true)
                {
                    unclaimedScore += 50;
                }
                else
                {
                    firey = true;
                    fireyTimer = 500;
                }
            }
            else if (type == 4)
            {
                if (speedy == true)
                {
                    unclaimedScore += 50;
                }
                else
                {
                    speedy = true;
                    speedyTimer = 500;
                }
            }
            else if (type == 5)
            {
                if (longer == true)
                {
                    unclaimedScore += 50;
                }
                else
                {
                    longer = true;
                    longerTimer = 500;
                }
            }
            else if (type == 6)
            {
                if (doubled == true)
                {
                    unclaimedScore += 50;
                }
                else
                {
                    doubled = true;
                    doubledTimer = 500;
                }
            }
        }
    }
}
