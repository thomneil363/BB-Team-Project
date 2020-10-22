using System.Drawing;

namespace BrickBreaker
{
    public class Paddle
    {
        public int x, y, width, height, speed;
        public Color colour;
        public bool frozen = false, shielded = false, firey = false, multi = false, longer = false, doubled = false;

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
                frozen = true;
            }
            else if (type == 2) // Next hit to shield, run code to bounce instead of kill
            {
                shielded = true;
            }
            else if (type == 3)
            {
                firey = true;
            }
            else if (type == 4)
            {
                multi = true;
            }
            else if (type == 5)
            {
                longer = true;
            }
            else if (type == 6)
            {
                doubled = true;
            }
        }
    }
}
