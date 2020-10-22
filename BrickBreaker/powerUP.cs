using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    class powerUP//james
    {
        // 
        public int x, y, type, size;

        public powerUP(int _x, int _y, int _type, int _size)
        {
            x = _x;
            y = _y;
            type = _type;
            size = _size;
        }
        public void Fall()
        {
            y += 3;
        }

        public bool powerUpCollide(Paddle p)
        {
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);
            Rectangle powerupRec = new Rectangle(x, y, size, size);
            Boolean powerUpCollide = false;

            if (powerupRec.IntersectsWith(paddleRec))
            {
                powerUpCollide = true;
            }

            return powerUpCollide;

        }
    }
}
