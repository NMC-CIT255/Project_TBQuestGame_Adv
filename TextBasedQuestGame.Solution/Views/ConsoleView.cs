using System;
//using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedQuestGame.Solution.Models;


namespace TextBasedQuestGame.Solution.Views
{
    public class ConsoleView
    {
        #region FIELDS

        //
        // window size
        //
        private const int WINDOW_WIDTH = 40;
        private const int WINDOW_HEIGHT = 40;

        //
        // cell size in characters
        //
        private const int NUMBER_OF_CELL_ROWS = 5;
        private const int NUMBER_OF_CELL_COLOMNS = 5;

        //
        // map size in cells
        //
        private const int NUMBER_OF_MAP_ROWS = 4;
        private const int NUMBER_OF_MAP_COLUMNS = 4;

        //
        // horizontal and verical margins in console window for display
        //
        private const int DISPLAY_HORIZONTAL_MARGIN = 2;
        private const int DISPALY_VERITCAL_MARGIN = 1;

        private Map _gameMap;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public ConsoleView(Map gameMap)
        {
            _gameMap = gameMap;
        }
        #endregion

        #region METHODS

        public void InitializeConsoleWindow()
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        }

        public void DisplayMap()
        {
            for (int row = 0; row < NUMBER_OF_MAP_ROWS; row++)
            {
                for (int column = 0; column < NUMBER_OF_MAP_COLUMNS; column++)
                {
                    char[,] cellView = BuildCellView(_gameMap.MapSet[row, column]);

                    DisplayCellView(cellView, row, column);
                }
            }

        }

        public void DisplayCellInfo(MapPosition location)
        {
            Cell currentCell = _gameMap.GetCellAtLocation(location);
            DisplayMessage(currentCell.Description);
        }

        // TODO improve message box with expandable border
        /// <summary>
        /// display a message in the message area
        /// </summary>
        /// <param name="message">string to display</param>
        public void DisplayMessage(string message)
        {
            //
            // calculate the message area location on the console window
            //
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;
            const int MESSAGE_BOX_VERTICAL_OFFSET = DISPALY_VERITCAL_MARGIN + (NUMBER_OF_CELL_ROWS * NUMBER_OF_MAP_ROWS) + 1;

            //
            // set the curse at the message area location on the console window
            // Note: horizontal offset handle in Wrap utility method
            //
            Console.SetCursorPosition(0, MESSAGE_BOX_VERTICAL_OFFSET);

            //
            // create a list of strings to hold the wrapped text message
            //
            List<string> messageLines;

            //
            // call utility method to wrap text and loop through list of strings to display
            //
            messageLines = Util.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);
            foreach (var messageLine in messageLines)
            {
                Console.WriteLine(messageLine);
            }
        }

        public void DisplayPlayer(Player myPlayer)
        {
            int cursorRow = (myPlayer.Location.Row * NUMBER_OF_CELL_ROWS) + 2 + DISPALY_VERITCAL_MARGIN;
            int cursorColumn = (myPlayer.Location.Column * NUMBER_OF_CELL_COLOMNS) + 2 + DISPLAY_HORIZONTAL_MARGIN;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(cursorColumn, cursorRow);
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
        }

        /// <summary>
        /// display an individual cell in the console window
        /// </summary>
        /// <param name="cellView">the character array contain the cell view</param>
        private void DisplayCellView(char[,] cellView, int cellRow, int cellColumn)
        {
            for (int row = 0; row < NUMBER_OF_CELL_ROWS; row++)
            {
                for (int column = 0; column < NUMBER_OF_CELL_COLOMNS; column++)
                {
                    int cursorRow = (cellRow * NUMBER_OF_CELL_ROWS) + row + DISPALY_VERITCAL_MARGIN;
                    int cursorColumn = (cellColumn * NUMBER_OF_CELL_COLOMNS) + column + DISPLAY_HORIZONTAL_MARGIN;

                    Console.SetCursorPosition(cursorColumn, cursorRow);
                    Console.Write(cellView[row, column].ToString());
                }
            }
        }



        /// <summary>
        /// build out the console veiw for a given cell based on type and access
        /// </summary>
        /// <param name="cell">specify cell to build out</param>
        private char[,] BuildCellView(Cell cell)
        {

            //
            // a character array that represents a cell visually in the console window
            //
            char[,] _cellView = new char[5, 5];

            //
            // fill cell view matrix with '*'
            //
            for (int i = 0; i < NUMBER_OF_CELL_ROWS; i++)
            {
                for (int j = 0; j < NUMBER_OF_CELL_COLOMNS; j++)
                {
                    _cellView[i, j] = '*';
                }
            }

            //
            // fill non-wall area with spaces
            //
            // cell is a Room
            if (cell.Type == Cell.TypeName.Room)
            {
                for (int i = 1; i < NUMBER_OF_CELL_ROWS - 1; i++)
                {
                    for (int j = 1; j < NUMBER_OF_CELL_COLOMNS - 1; j++)
                    {
                        _cellView[i, j] = ' ';
                    }
                }
            }
            // cell is a Coridor
            else if (cell.Type == Cell.TypeName.Corridor)
            {
                _cellView[2, 2] = ' ';
            }

            //
            // fill access areas with spaces (note: "magic numbers" used for readability)
            //
            if (cell.NorthAccess == true)
            {
                _cellView[0, 2] = ' ';
                if (cell.Type == Cell.TypeName.Corridor)
                {
                    _cellView[1, 2] = ' ';
                }
            }
            if (cell.EastAccess == true)
            {
                _cellView[2, 4] = ' ';
                if (cell.Type == Cell.TypeName.Corridor)
                {
                    _cellView[2, 3] = ' ';
                }
            }
            if (cell.SouthAccess == true)
            {
                _cellView[4, 2] = ' ';
                if (cell.Type == Cell.TypeName.Corridor)
                {
                    _cellView[3, 2] = ' ';
                }
            }
            if (cell.WestAccess == true)
            {
                _cellView[2, 0] = ' ';
                if (cell.Type == Cell.TypeName.Corridor)
                {
                    _cellView[2, 1] = ' ';
                }
            }

            return _cellView;
        }
        #endregion
    }
}
