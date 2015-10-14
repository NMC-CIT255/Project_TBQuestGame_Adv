using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedQuestGame.Solution.Models
{
    public class MapPosition
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public MapPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
