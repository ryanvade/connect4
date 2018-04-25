using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4
{
    class GridChecker
    {
        private char[][] grid = null;
        private char winner;
        private Bitmap red;
        private Bitmap black;
        private Bitmap blank;
        int rowCount;
        int columnCount;
        public GridChecker(DataGridView GameGrid, Bitmap red, Bitmap black, Bitmap blank)
        {
            rowCount = GameGrid.Rows.Count;
            columnCount = GameGrid.Columns.Count;
            grid = new char[rowCount][];
            this.red = red;
            this.black = black;
            this.blank = blank;

            winner = ' ';

            for (int i = 0; i < rowCount; i++)
            {
                grid[i] = new char[columnCount];
                for (int j = 0; j < columnCount; j++)
                {
                    Bitmap cell = (Bitmap)GameGrid.Rows[i].Cells[j].Value;

                    if(cell == red)
                    {
                        grid[i][j] = 'R';
                    }else if(cell == black)
                    {
                        grid[i][j] = 'B';
                    }else
                    {
                        grid[i][j] = '0';
                    }
                }
            }
        }

        public char getWinner()
        {
            return this.winner;
        }

        public bool CheckRows()
        {
            for (int i = 0; i < rowCount; i++)
            {
                int j = 0;
                while (j <= columnCount - 5)
                {
                    char current = grid[i][j];
                    if(current != '0')
                    {
                        int currentCheck = j + 1;
                        int concurrent = 1;
                        while(currentCheck < columnCount)
                        {
                            if(grid[i][currentCheck] == current)
                            {
                                concurrent++;
                            }else
                            {
                                break;
                            }
                            currentCheck++;
                        }
                        if (concurrent >= 5)
                        {
                            winner = current;
                            return true;
                        }
                    }
                    j++;
                }
            }
            return false;
        }

        public bool CheckColumns()
        {
            for (int i = 0; i < columnCount; i++)
            {
                int j = 0;
                while(j <= rowCount - 5)
                {
                    char current = grid[j][i];
                    if (current != '0')
                    {
                        int currentCheck = j + 1;
                        int concurrent = 1;
                        while (currentCheck < rowCount)
                        {
                            if (grid[currentCheck][i] == current)
                            {
                                concurrent++;
                            }
                            else
                            {
                                break;
                            }
                            currentCheck++;
                        }
                        if (concurrent >= 5)
                        {
                            winner = current;
                            return true;
                        }
                    }
                    j++;
                }
            }

            return false;
        }

        public bool CheckUpperDiagonals()
        {
            for (int i = columnCount - 1; i >= 0; i--)
            {
                int j = 0;
                while (j < rowCount)
                {
                    char current = grid[j][i];
                    if (current != '0')
                    {
                        int currentColumn = i - 1;
                        int currentRow = j + 1;
                        int concurrent = 1;
                        while (currentRow < rowCount && currentColumn < columnCount && currentRow >= 0 && currentColumn >= 0)
                        {
                            if (grid[currentRow][currentColumn] == current)
                            {
                                concurrent++;
                            }
                            else
                            {
                                break;
                            }
                            currentRow++;
                            currentColumn--;
                        }
                        if (concurrent >= 5)
                        {
                            winner = current;
                            return true;
                        }
                    }
                    j++;
                }
            }
            return false;
        }

        public bool CheckLowerDiagonals()
        {
            for (int i = columnCount - 1; i >= 0; i--)
            {
                int j = rowCount - 1;
                while (j >= 4)
                {
                    char current = grid[j][i];
                    if (current != '0')
                    {
                        int currentColumn = j - 1;
                        int currentRow = i - 1;
                        int concurrent = 1;
                        while (currentRow < rowCount && currentColumn < columnCount && currentRow >= 0 && currentColumn >= 0)
                        {
                            if (grid[currentRow][currentColumn] == current)
                            {
                                concurrent++;
                            }
                            else
                            {
                                break;
                            }
                            currentRow--;
                            currentColumn--;
                        }
                        if (concurrent >= 5)
                        {
                            winner = current;
                            return true;
                        }
                    }
                    j--;
                }
            }
            return false;
        }
    }
}
