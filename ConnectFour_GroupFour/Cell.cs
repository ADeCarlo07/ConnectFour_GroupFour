using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_GroupFour
{
    internal class Cell
    {
        int row;
        int col;
        Button btn;
        bool containsPiece;

        //1 - red
        //2 - yellow
        int pieceColor;

        public Cell()
        {

        }

        public Cell(int r, int c, Button button)
        {
            row = r;
            col = c;
            btn = button;

            //make sure that empty cell starts with no player
            pieceColor = 0;
            containsPiece = false;
        }

        public int GetRow()
        {
            return row;
        }
        public int GetCol()
        {
            return col;
        }
        public Button GetButton()
        {
            return btn;
        }

        public bool GetCellContainPiece()
        {
            return containsPiece;
        }

        public int GetPieceColor()
        {
            return pieceColor;
        }

        public void SetRow(int r)
        {
            row = r;
        }

        public void SetCol(int c)
        {
            col = c;
        }

        public void SetBtn(Button b)
        {
            btn = b;
        }

        public void SetCellContainsPiece(bool p)
        {
            containsPiece = p;
        }

        public void SetPieceColor(int c)
        {
            pieceColor = c;
        }
    }
}