using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedQuestGame.Solution.Models
{
    public class Character
    {
        #region ENUMERABLES
        public enum GenderNames
        {
            Male,
            Female
        }

        public enum RaceNames
        {
            Human,
            Elf,
            Dwarf
        }
        #endregion

        #region FIELDS

        private string _name;

        private GenderNames _gender;
        private RaceNames _race;

        //private int _mapPositionRow;
        //private int _mapPositionColumn;

        private MapPosition _location;

        public MapPosition Location
        {
            get { return _location; }
            set { _location = value; }
        }
        

        #endregion

        #region PROPERTIES
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public GenderNames Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public RaceNames Race
        {
            get { return _race; }
            set { _race = value; }
        }

        //public int MapPositionRow
        //{
        //    get { return _mapPositionRow; }
        //    set { _mapPositionRow = value; }
        //}

        //public int MapPositionColumn
        //{
        //    get { return _mapPositionColumn; }
        //    set { _mapPositionColumn = value; }
        //}


        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        /// <summary>
        /// instantiate a character
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="race"></param>
        /// <param name="startLocation"></param>
        public Character(
            string name,
            GenderNames gender,
            RaceNames race,
            MapPosition startLocation)
        {
            _name = name;
            _gender = gender;
            _race = race;
            _location = startLocation;
        }

        #endregion

        #region METHODS

        #endregion
    }
}
