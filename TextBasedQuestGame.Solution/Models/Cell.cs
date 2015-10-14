using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedQuestGame.Solution.Models
{
    public class Cell
    {
        #region ENUMERABLES
        public enum TypeName
        {
            Room,
            Corridor,
            Empty
        }

        /// <summary>
        /// code indicates cell access (NESW) with a O representing open and C representing closed
        /// </summary>
        public enum AccessCode
        {
            CCCC,
            OCCC,
            COCC,
            CCOC,
            CCCO,
            OOCC,
            OCOC,
            OCCO,
            COOC,
            COCO,
            CCOO,
            OOOC,
            OOCO,
            OCOO,
            COOO,
            OOOO
        }
        #endregion

        #region FIELDS
        private string _name;
        private TypeName _type;
        private AccessCode _access;

        private bool _isOccupied;
        private bool _isLighted;
        private bool _canEnter;

        

        private bool _northAccess = false;
        private bool _eastAccess = false;
        private bool _southAccess = false;
        private bool _westAccess = false;
        
        private string _description;
        private MapPosition _location;


        
        
        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public TypeName Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public AccessCode Access
        {
            get { return _access; }
            set { _access = value; }
        }
        public bool IsOccupied
        {
            get { return _isOccupied; }
            set { _isOccupied = value; }
        }
        
        public bool IsLighted
        {
            get { return _isLighted; }
            set { _isLighted = value; }
        }
        
        public bool CanEnter
        {
            get { return _canEnter; }
            set { _canEnter = value; }
        }

        public bool NorthAccess
        {
            get { return _northAccess; }
            set { _northAccess = value; }
        }

        public bool EastAccess
        {
            get { return _eastAccess; }
            set { _eastAccess = value; }
        }

        public bool SouthAccess
        {
            get { return _southAccess; }
            set { _southAccess = value; }
        }

        public bool WestAccess
        {
            get { return _westAccess; }
            set { _westAccess = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        // read only propertie
        public MapPosition Location
        {
            get { return _location; }
            set { _location = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Cell()
        {
            SetCellAccessFlags();
        }

        #endregion

        #region METHODS

        public void SetCellAccessFlags()
        {
            string accessString = _access.ToString();

            // north access open
            if (accessString.Substring(0, 1) == "O")
            {
                _northAccess = true;
            }

            // east access open
            if (accessString.Substring(1, 1) == "O")
            {
                _eastAccess = true;
            }

            // south access open
            if (accessString.Substring(2, 1) == "O")
            {
                _southAccess = true;
            }

            // west access open
            if (accessString.Substring(3, 1) == "O")
            {
                _westAccess = true;
            }
        }

        #endregion
    }
}
