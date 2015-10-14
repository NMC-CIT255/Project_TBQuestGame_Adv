using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedQuestGame.Solution.Models;

namespace TextBasedQuestGame.Solution.Models
{
    public class Player : Character
    {
        #region ENUMERABLES

        public enum Actions
        {
            WALK,
            TAKE
        }

        #endregion

        #region FIELDS

        private int _lives;
        
        #endregion

        #region PROPERTIES
        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }
        
        #endregion

        #region CONSTRUCTORS

        public Player(
            string name,
            GenderNames gender,
            RaceNames race,
            MapPosition startLocation)
            : base(name, gender, race, startLocation)
        {
            _lives = 1;
        }

        #endregion

        #region METHODS



        #endregion
    }
}
