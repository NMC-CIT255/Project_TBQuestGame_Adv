using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedQuestGame.Solution.Models
{
    public class Map
    {
        #region ENUMERABLES

        public enum Direction
        {
            NORTH,
            EAST,
            SOUTH,
            WEST
        }

        #endregion

        #region FIELDS

        public const int NUM_ROWS = 4;
        public const int NUM_COLUMNS = 4;

        private Cell[,] _mapSet = new Cell[NUM_ROWS, NUM_COLUMNS];

        #endregion

        #region PROPERTIES

        public Cell[,] MapSet
        {
            get { return _mapSet; }
        }


        #endregion

        #region CONSTRUCTORS

        public Map()
        {
            InitializeMap();
        }

        #endregion

        #region METHODS

        private void InitializeMap()
        {

            #region MAP DATA

            //
            // intialize cell types in array
            //
            _mapSet[0, 0] = new Cell
            {
                Name = "The Grand Room",
                Type = Cell.TypeName.Room,
                Access = Cell.AccessCode.COCC,
                Location = new MapPosition(0, 0),
                Description = "You are in the Grand Room and at the beginning of your journey." +
                                "From here you must proceed to your east as this is the only exit."
            };
            _mapSet[0, 1] = new Cell
            {
                Name = "Corridor",
                Type = Cell.TypeName.Corridor,
                Access = Cell.AccessCode.COCO,
                Location = new MapPosition(0, 1),
                Description = "You are in a long dark corridor."
            };
            _mapSet[0, 2] = new Cell
            {
                Name = "The Blue Room",
                Type = Cell.TypeName.Room,
                Access = Cell.AccessCode.CCOO,
                Location = new MapPosition(0, 2),
                Description = "You are in the Blue Room."
            };
            _mapSet[0, 3] = new Cell
            {
                Name = "The Round Room",
                Type = Cell.TypeName.Room,
                Access = Cell.AccessCode.CCOC,
                Location = new MapPosition(0, 3),
                Description = "You are in the Round Room."
            };

            _mapSet[1, 0] = new Cell
            {
                Name = "Empty Space",
                Type = Cell.TypeName.Empty,
                Access = Cell.AccessCode.CCCC,
                Location = new MapPosition(1, 0),
                Description = ""
            };
            _mapSet[1, 1] = new Cell
            {
                Name = "Empty Space",
                Type = Cell.TypeName.Empty,
                Access = Cell.AccessCode.CCCC,
                Location = new MapPosition(1, 1),
                Description = ""
            };
            _mapSet[1, 2] = new Cell
            {
                Name = "Corridor",
                Type = Cell.TypeName.Corridor,
                Access = Cell.AccessCode.OCOC,
                Location = new MapPosition(1, 2),
                Description = "You are in the Goat Room."
            };
            _mapSet[1, 3] = new Cell
            {
                Name = "Corridor",
                Type = Cell.TypeName.Corridor,
                Access = Cell.AccessCode.OCOC,
                Location = new MapPosition(1, 3),
                Description = "You are in the Tool Room."
            };

            _mapSet[2, 0] = new Cell
            {
                Name = "The Storage Room",
                Type = Cell.TypeName.Room,
                Access = Cell.AccessCode.CCOC,
                Location = new MapPosition(2, 0),
                Description = "You are in the Storage Room."
            };
            _mapSet[2, 1] = new Cell
            {
                Name = "Corridor",
                Type = Cell.TypeName.Corridor,
                Access = Cell.AccessCode.COOC,
                Location = new MapPosition(2, 1),
                Description = "You are in a corridor."
            };
            _mapSet[2, 2] = new Cell
            {
                Name = "Corridor",
                Type = Cell.TypeName.Corridor,
                Access = Cell.AccessCode.OOOO,
                Location = new MapPosition(2, 2),
                Description = "You are in a corridor."
            };
            _mapSet[2, 3] = new Cell
            {
                Name = "The Rose Room",
                Type = Cell.TypeName.Room,
                Access = Cell.AccessCode.OCCO,
                Location = new MapPosition(2, 3),
                Description = "You are in the Rose Room."
            };

            _mapSet[3, 0] = new Cell
            {
                Name = "Corridorm",
                Type = Cell.TypeName.Corridor,
                Access = Cell.AccessCode.OOCC,
                Location = new MapPosition(3, 0),
                Description = "You are in the Storage Room."
            };
            _mapSet[3, 1] = new Cell
            {
                Name = "Corridor",
                Type = Cell.TypeName.Room,
                Access = Cell.AccessCode.OOCO,
                Location = new MapPosition(3, 1),
                Description = "You are in a corridor."
            };
            _mapSet[3, 2] = new Cell
            {
                Name = "Corridor",
                Type = Cell.TypeName.Corridor,
                Access = Cell.AccessCode.OOCO,
                Location = new MapPosition(3, 2),
                Description = "You are in a corridor."
            };
            _mapSet[3, 3] = new Cell
            {
                Name = "The Rose Room",
                Type = Cell.TypeName.Room,
                Access = Cell.AccessCode.CCCO,
                Location = new MapPosition(3, 3),
                Description = "You are in the Rose Room."
            };

            InitializeAccessFlags();
        }

            #endregion

        private void InitializeAccessFlags()
        {
            for (int row = 0; row < NUM_ROWS; row++)
            {
                for (int column = 0; column < NUM_COLUMNS; column++)
                {
                    _mapSet[row, column].SetCellAccessFlags();

                    //
                    // temporarily allow access to all cells 
                    //
                    _mapSet[row, column].CanEnter = true;
                }
            }
        }

        public Cell GetCellAtLocation(MapPosition location)
        {
            Cell currentCell = _mapSet[location.Row, location.Column];

            return currentCell;
        }

        public bool GoodMove(MapPosition currentLocation, Direction direction)
        {
            Cell currentCell = GetCellAtLocation(currentLocation);

            bool access = false;

            switch (direction)
            {
                case Direction.NORTH:
                    if (currentCell.NorthAccess)
                    {
                        access = true;
                    }
                    break;
                case Direction.EAST:
                    if (currentCell.EastAccess)
                    {
                        access = true;
                    }
                    break;
                case Direction.SOUTH:
                    if (currentCell.SouthAccess)
                    {
                        access = true;
                    }
                    break;
                case Direction.WEST:
                    if (currentCell.WestAccess)
                    {
                        access = true;
                    }
                    break;
                default:
                    break;
            }

            return access;
        }

        #endregion
    }
}
