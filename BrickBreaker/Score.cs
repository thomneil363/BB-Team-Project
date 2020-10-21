using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class Score
    {
        public string numericScore, name, date;
          
      
        public Score(string _numericScore, string _name)
        {
            numericScore = _numericScore;
            name = _name;
            date = DateTime.Now.ToString("d");
        }
    }
}
