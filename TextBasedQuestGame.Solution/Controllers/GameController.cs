using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedQuestGame.Solution.Models;
using TextBasedQuestGame.Solution.Views;

namespace TextBasedQuestGame.Solution.Controllers
{
    class GameController
    {
        #region FIELDS

        private Map _gameMap = new Map();
        private Player _myPlayer;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        public GameController()
        {
            _myPlayer = AddPlayer();

            ConsoleView userConsoleView = new ConsoleView(_gameMap);

            userConsoleView.InitializeConsoleWindow();
            userConsoleView.DisplayMap();
            userConsoleView.DisplayPlayer(_myPlayer);

            userConsoleView.DisplayCellInfo(_myPlayer.Location);

            Console.ReadLine();

        }

        #endregion

        #region METHODS

        private Player AddPlayer()
        {
            MapPosition playerLocation = new MapPosition(0, 0);
            Player myPlayer = new Player(
                "Bonzo",
                Player.GenderNames.Male,
                Player.RaceNames.Human,
                playerLocation
                );
            return myPlayer;
        }

        #endregion




    }
}
