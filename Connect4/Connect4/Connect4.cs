﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4
{
    public partial class Connect4 : Form
    {
        int rowCount = 5;
        int columnCount = 5;
        int imageWidth;
        int imageHeight;
        int markedCells = 0;
        int redCells = 0;
        int blackCells = 0;
        private Bitmap blank, red, black;
        private PlayerState PlayerA;
        private PlayerState PlayerB;
        private String PlayerAFilePath;
        private String PlayerBFilePath;
        private GameState CurrentState;
        private PlayerColor CurrentPlayer;
        private TimeLimit CurrentTimeLimit;
        private string InputFileName = "\\result.txt";
        private string OutputFileName = "\\output.txt";
        private enum PlayerState { Human = 0x01, Computer = 0x02 }
        private enum GameState { Running = 0x03, Stopped = 0x04 }
        private enum PlayerColor { Red = 0x05, Black = 0x06 }
        private enum TimeLimit { Five = 5000, Ten = 10000, Twenty = 20000, OneMinute = 60000, No_Limit = -1}

        public Connect4()
        {
            InitializeComponent();
            InitializeImages();
            InitializeNewGame();
            PlayerA = PlayerState.Human;
            PlayerB = PlayerState.Human;
            CurrentState = GameState.Stopped;
            RED_CURRENT_STATE_LABEL.Text = "Current: Human";
            RED_CONSOLE_CHECKBOX.Visible = false;
            BLACK_CURRENT_STATE_LABEL.Text = "Current: Human";
            BLACK_CONSOLE_CHECKBOX.Visible = false;
            CurrentTimeLimit = TimeLimit.Five;
            secondsToolStripMenuItem.Checked = true;
            x5ToolStripMenuItem.Checked = true;
        }

        private void InitializeImages()
        {
            blank = new Bitmap(Properties.Resources.blank);
            red = new Bitmap(Properties.Resources.red);
            black = new Bitmap(Properties.Resources.black);
            imageHeight = blank.Height;
            imageWidth = blank.Width;
        }

        private void InitializeNewGame()
        {
            markedCells = 0;
            AutoSize = true;
            CURRENT_TURN_PICTURE_BOX.Image = blank;
            CurrentPlayer = PlayerColor.Red;
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            this.splitContainer1.Panel2.SuspendLayout();
            this.SuspendLayout();
            GameGrid.Rows.Clear();
            GameGrid.AllowUserToAddRows = false;
            GameGrid.ColumnHeadersVisible = false;
            GameGrid.RowHeadersVisible = false;
            GameGrid.AllowUserToResizeColumns = false;
            GameGrid.AllowUserToResizeRows = false;
            GameGrid.BorderStyle = BorderStyle.Fixed3D;
            GameGrid.RowTemplate.Height = imageHeight;
            GameGrid.AutoSize = true;
            CreateColumns();
            CreateRows();
            //this.splitContainer1.Width = this.splitContainer1.Panel1.Width + (columnCount * imageWidth);
            //this.Width = this.splitContainer1.Panel1.Width + (columnCount * imageWidth);
            //this.Height = GameGrid.Height;
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void CreateColumns()
        {
            Console.Out.WriteLine("Inside Create Columns");
            DataGridViewImageColumn imageColumn;
            for (int i = 0; i < columnCount; i++)
            {
                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();
                imageColumn.Width = imageWidth;
                imageColumn.Image = unMarked;
                GameGrid.Columns.Add(imageColumn);
            }
        }

        private void CreateRows()
        {
            Console.Out.WriteLine("Inside Create Rows");
            for (int i = 0; i < rowCount; i++)
            {
                GameGrid.Rows.Add();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SwitchPlayers()
        {
            if(CurrentPlayer == PlayerColor.Red)
            {
                CurrentPlayer = PlayerColor.Black;
                CURRENT_TURN_PICTURE_BOX.Image = black;
            }else
            {
                CurrentPlayer = PlayerColor.Red;
                CURRENT_TURN_PICTURE_BOX.Image = red;
            }
        }

        private void GameGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CurrentState == GameState.Stopped)
            {
                return;
            }

            if (CurrentPlayer == PlayerColor.Red && PlayerA == PlayerState.Computer)
            {
                return;
            }

            if (CurrentPlayer == PlayerColor.Black && PlayerB == PlayerState.Computer)
            {
                return;
            }

            DataGridViewImageCell cell = (DataGridViewImageCell)GameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value == blank)
            {
                Console.Out.WriteLine("Row: " + e.RowIndex + " Column: " + e.ColumnIndex);
                if (CurrentPlayer == PlayerColor.Red)
                {
                    cell.Value = red;
                }
                else
                {
                    cell.Value = black;
                }
                markedCells++;
                if(CurrentPlayer == PlayerColor.Red)
                {
                    redCells++;
                    RED_PIECE_COUNT.Text = "Pieces: " + redCells;
                }else
                {
                    blackCells++;
                    BLACK_PIECES_COUNT.Text = "Pieces: " + blackCells;
                }
                SwitchPlayers();
                HandlePlayerTurn();
                CheckForEnding();
            }
        }

        private void ResetBoard(bool flipStartButton)
        {
            CurrentState = GameState.Stopped;
            GameGrid.Rows.Clear();
            GameGrid.Columns.Clear();
            if(flipStartButton)
            {
                START_BUTTON.Text = "Start";

            }
            //toolStripComboBox1.Enabled = true;
            //toolStripComboBox2.Enabled = true;
            timeLimitToolStripMenuItem.Enabled = true;
            boardSizeToolStripMenuItem.Enabled = true;
            redCells = 0;
            blackCells = 0;
            RED_PIECE_COUNT.Text = "Pieces: " + redCells;
            BLACK_PIECES_COUNT.Text = "Pieces: " + blackCells;
            InitializeNewGame();
        }

        private void START_BUTTON_Click(object sender, EventArgs e)
        {
            if(CurrentState == GameState.Stopped)
            {
                CurrentState = GameState.Running;
                CURRENT_TURN_PICTURE_BOX.Image = red;
                START_BUTTON.Text = "Stop";
                if(markedCells > 0)
                {
                    ResetBoard(false);
                }
                //toolStripComboBox1.Enabled = false;
                ///toolStripComboBox2.Enabled = false;
                timeLimitToolStripMenuItem.Enabled = false;
                boardSizeToolStripMenuItem.Enabled = false;
                HandlePlayerTurn();
            }
            else
            {
                CurrentState = GameState.Stopped;
                CURRENT_TURN_PICTURE_BOX.Image = blank;
                START_BUTTON.Text = "Start";
                //toolStripComboBox1.Enabled = true;
                //toolStripComboBox2.Enabled = true;
                timeLimitToolStripMenuItem.Enabled = false;
                boardSizeToolStripMenuItem.Enabled = false;
            }
        }

        private void HandlePlayerTurn()
        {
            if(CurrentState == GameState.Stopped)
            {
                return;
            }

            WriteBoardToFile();
            if(CurrentPlayer == PlayerColor.Red && PlayerA == PlayerState.Human)
            {
                return;
            }

            if(CurrentPlayer == PlayerColor.Black && PlayerB == PlayerState.Human)
            {
                return;
            }

            if (CurrentTimeLimit != TimeLimit.No_Limit)
            {
                try
                {
                    long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    long end = now + (long)CurrentTimeLimit;
                    Process process = new Process();
                    if (CurrentPlayer == PlayerColor.Red)
                    {
                        process.StartInfo.FileName = PlayerAFilePath;
                        process.StartInfo.UseShellExecute = RED_CONSOLE_CHECKBOX.Checked;
                    }
                    else
                    {
                        process.StartInfo.FileName = PlayerBFilePath;
                        process.StartInfo.UseShellExecute = BLACK_CONSOLE_CHECKBOX.Checked;
                    }
                    process.Start();
                    while (!process.HasExited && end > now )
                    {
                        now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                        Console.Out.WriteLine("END: " + end + " Now: " + now);
                    }
                    now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    if (now >= end && !process.HasExited)
                    {
                        process.Kill();
                        process.Close();
                        DisplayOutOfTimeMessage();
                    }
                }
                catch (Exception e)
                {
                    DisplayBadExecutable();
                }
                GetComputerMove();
            }
            else
            {
                try
                {
                    long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    Process process = new Process();
                    if (CurrentPlayer == PlayerColor.Red)
                    {
                        process.StartInfo.FileName = PlayerAFilePath;
                        process.StartInfo.UseShellExecute = RED_CONSOLE_CHECKBOX.Checked;
                    }
                    else
                    {
                        process.StartInfo.FileName = PlayerBFilePath;
                        process.StartInfo.UseShellExecute = BLACK_CONSOLE_CHECKBOX.Checked;
                    }
                    process.Start();
                    while (!process.HasExited)
                    {
                        now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    }
                }
                catch (Exception e)
                {
                    DisplayBadExecutable();
                }
                GetComputerMove();
            }
            SwitchPlayers();
            HandlePlayerTurn();
        }

        private void GetComputerMove()
        {
            try
            {
                string AppPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                string[] lines = System.IO.File.ReadAllLines(AppPath + InputFileName);
                if (lines.Length < 1)
                {
                    DisplayInvalidMove();
                }
                string board = lines[0];
                if(ValidMove(board))
                {
                    SetBoard(board);
                    
                }else
                {
                    DisplayInvalidMove();
                }
            }
            catch (Exception e)
            {
                DisplayInvalidMove();
            }
        }

        private void SetBoard(string board)
        {
            redCells = 0;
            blackCells = 0;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    char curr = board[i * rowCount + j];
                    switch (curr)
                    {
                        case '0':
                            GameGrid.Rows[i].Cells[j].Value = blank;
                            break;
                        case 'R':
                            GameGrid.Rows[i].Cells[j].Value = red;
                            redCells++;
                            break;
                        case 'B':
                            GameGrid.Rows[i].Cells[j].Value = black;
                            blackCells++;
                            break;
                        default:
                            break;
                    }
                }
            }
            RED_PIECE_COUNT.Text = "Pieces: " + redCells;
            BLACK_PIECES_COUNT.Text = "Pieces: " + blackCells;
        }

        private void CheckForEnding()
        {
            if(markedCells < 5)
            {
                return;
            }
            GridChecker checker = new GridChecker(GameGrid, red, black, blank);

            if(checker.CheckRows())
            {
                Console.Out.WriteLine("Winner By Rows");
                char winner = checker.getWinner();
                switch (winner)
                {
                    case 'R':
                        DisplayWinner(PlayerColor.Red);
                        //ResetBoard(true);
                        START_BUTTON.Text = "Start";
                        CURRENT_TURN_PICTURE_BOX.Image = blank;
                        return;
                    case 'B':
                        DisplayWinner(PlayerColor.Black);
                        START_BUTTON.Text = "Start";
                        CURRENT_TURN_PICTURE_BOX.Image = blank;

                        //ResetBoard(true);
                        return;
                    default:
                        break;
                }
                return;
            }

            if (checker.CheckColumns())
            {
                Console.Out.WriteLine("Winner By Columns");
                char winner = checker.getWinner();
                switch (winner)
                {
                    case 'R':
                        DisplayWinner(PlayerColor.Red);
                        START_BUTTON.Text = "Start";
                        CURRENT_TURN_PICTURE_BOX.Image = blank;

                        //ResetBoard(true);
                        return;
                    case 'B':
                        DisplayWinner(PlayerColor.Black);
                        START_BUTTON.Text = "Start";
                        CURRENT_TURN_PICTURE_BOX.Image = blank;

                        //ResetBoard(true);
                        return;
                    default:
                        break;
                }
                return;
            }

            if (checker.CheckUpperDiagonals())
            {
                Console.Out.WriteLine("Winner By Upper Diagonals");
                char winner = checker.getWinner();
                switch (winner)
                {
                    case 'R':
                        DisplayWinner(PlayerColor.Red);
                        START_BUTTON.Text = "Start";
                        CURRENT_TURN_PICTURE_BOX.Image = blank;

                        //ResetBoard(true);
                        return;
                    case 'B':
                        DisplayWinner(PlayerColor.Black);
                        START_BUTTON.Text = "Start";
                        CURRENT_TURN_PICTURE_BOX.Image = blank;

                        //ResetBoard(true);
                        return;
                    default:
                        break;
                }
                return;
            }

            if (checker.CheckLowerDiagonals())
            {
                Console.Out.WriteLine("Winner By Lower Diagonals");
                char winner = checker.getWinner();
                switch (winner)
                {
                    case 'R':
                        DisplayWinner(PlayerColor.Red);
                        START_BUTTON.Text = "Start";
                        CURRENT_TURN_PICTURE_BOX.Image = blank;

                        //ResetBoard(true);
                        return;
                    case 'B':
                        DisplayWinner(PlayerColor.Black);
                        START_BUTTON.Text = "Start";
                        CURRENT_TURN_PICTURE_BOX.Image = blank;

                        //ResetBoard(true);
                        return;
                    default:
                        break;
                }
                return;
            }

            if(markedCells == rowCount * columnCount)
            {
                DisplayNoWinner();
                START_BUTTON.Text = "Start";
                CURRENT_TURN_PICTURE_BOX.Image = blank;

                //ResetBoard(true);
            }

        }

        private bool ValidMove(string board)
        {
            bool valid = true;
            string currentBoard = GetBoardAsString();
            if(board.Length != currentBoard.Length)
            {
                DisplayInvalidMove();
            }

            for (int i = 0; i < board.Length; i++)
            {
                if(currentBoard[i] != board[i])
                {
                    if(currentBoard[i] != '0')
                    {
                        valid = false;
                    }
                }

                if(board[i] != '0' && board[i] != 'R' && board[i] != 'B')
                {
                    valid = false;
                }
            }
            return valid;
        }

        private string GetBoardAsString()
        {
            string board = "";
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    DataGridViewImageCell cell = (DataGridViewImageCell)GameGrid.Rows[i].Cells[j];

                    if (cell.Value == blank)
                    {
                        board = board + "0";
                    }else if(cell.Value == red)
                    {
                        board = board + "R";
                    }else
                    {
                        board = board + "B";
                    }
                }
            }
            return board;
        }

        private void WriteBoardToFile()
        {
            try
            {
                string board = GetBoardAsString();
                string AppPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                Console.Out.WriteLine(@AppPath + OutputFileName);
                StreamWriter outputFile = new StreamWriter(@AppPath + OutputFileName);
                if (CurrentPlayer == PlayerColor.Black)
                    board = "B" + board;
                else
                    board = "R" + board;
                outputFile.WriteLine(board);
                outputFile.Close();
            }
            catch (Exception e)
            {
                DisplayOutputError();
            }

        }

        private void DisplayOutputError()
        {
            Status status = new Status("Unable to write data to file.");
            status.StartPosition = FormStartPosition.CenterParent;
            status.ShowDialog();
            status.Dispose();
            CurrentState = GameState.Stopped;
            START_BUTTON.Text = "Start";
            CURRENT_TURN_PICTURE_BOX.Image = blank;

            //ResetBoard(true);
        }

        private void DisplayNoWinner()
        {
            Status status = new Status("All moves are taken, no winner.");
            status.StartPosition = FormStartPosition.CenterParent;
            status.ShowDialog();
            status.Dispose();
            CurrentState = GameState.Stopped;
            START_BUTTON.Text = "Start";
            CURRENT_TURN_PICTURE_BOX.Image = blank;

            //ResetBoard(true);
        }

        private void DisplayInvalidMove()
        {
            Status status = new Status("Program made an invalid move.");
            status.StartPosition = FormStartPosition.CenterParent;
            status.ShowDialog();
            status.Dispose();
            CurrentState = GameState.Stopped;
            START_BUTTON.Text = "Start";
            CURRENT_TURN_PICTURE_BOX.Image = blank;

            //ResetBoard(true);
        }

        private void DisplayOutOfTimeMessage()
        {
            Status status = new Status("Process ran out of time.");
            status.StartPosition = FormStartPosition.CenterParent;
            status.ShowDialog();
            status.Dispose();
            CurrentState = GameState.Stopped;
            START_BUTTON.Text = "Start";
            CURRENT_TURN_PICTURE_BOX.Image = blank;

            //ResetBoard(true);
        }

        private void DisplayBadExecutable()
        {
            Status status = new Status("Unable to run executable.");
            status.StartPosition = FormStartPosition.CenterParent;
            status.ShowDialog();
            status.Dispose();
            CurrentState = GameState.Stopped;
            START_BUTTON.Text = "Start";
            CURRENT_TURN_PICTURE_BOX.Image = blank;

            //ResetBoard(true);
        }

        private void DisplayWinner(PlayerColor player)
        {
            string message = "Winner is ";
            if(player == PlayerColor.Red)
            {
                message = message + " Red!";
            }else
            {
                message = message + " Black!";
            }
            Status status = new Status(message);
            status.StartPosition = FormStartPosition.CenterParent;
            status.ShowDialog();
            status.Dispose();
            CurrentState = GameState.Stopped;
            START_BUTTON.Text = "Start";
            CURRENT_TURN_PICTURE_BOX.Image = blank;

            //ResetBoard(true);
        }

        private void RESET_BUTTON_Click(object sender, EventArgs e)
        {
            ResetBoard(true);
        }

        private void RED_HUMAN_BUTTON_Click(object sender, EventArgs e)
        {
            PlayerA = PlayerState.Human;
            RED_CONSOLE_CHECKBOX.Visible = false;
            RED_CURRENT_STATE_LABEL.Text = "Current: Human";
            PlayerAFilePath = "";
        }

        private void RED_COMPUTER_BUTTON_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "executable files (*.exe)|*.exe";

            if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
            {
                PlayerAFilePath = dialog.FileName;
                PlayerA = PlayerState.Computer;
                RED_CURRENT_STATE_LABEL.Text = "Current: " + Path.GetFileName(dialog.FileName);
                RED_CONSOLE_CHECKBOX.Visible = true;
            }
        }

        private void BLACK_COMPUTER_BUTTON_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "executable files (*.exe)|*.exe";

            if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
            {
                PlayerBFilePath = dialog.FileName;
                PlayerB = PlayerState.Computer;
                BLACK_CURRENT_STATE_LABEL.Text = "Current: " + Path.GetFileName(dialog.FileName);
                BLACK_CONSOLE_CHECKBOX.Visible = true;
            }
        }

        private void BLACK_HUMAN_BUTTON_Click(object sender, EventArgs e)
        {
            PlayerB = PlayerState.Human;
            BLACK_CONSOLE_CHECKBOX.Visible = false;
            BLACK_CURRENT_STATE_LABEL.Text = "Current: Human";
            PlayerBFilePath = "";
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetBoard(true);
        }

        private void secondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTimeLimit = TimeLimit.Five;
            secondsToolStripMenuItem.Checked = true;
            secondsToolStripMenuItem1.Checked = false;
            secondsToolStripMenuItem2.Checked = false;
            minuteToolStripMenuItem.Checked = false;
            noLimitToolStripMenuItem.Checked = false;
        }

        private void secondsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CurrentTimeLimit = TimeLimit.Ten;
            secondsToolStripMenuItem.Checked = false;
            secondsToolStripMenuItem1.Checked = true;
            secondsToolStripMenuItem2.Checked = false;
            minuteToolStripMenuItem.Checked = false;
            noLimitToolStripMenuItem.Checked = false;
        }

        private void secondsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CurrentTimeLimit = TimeLimit.Twenty;
            secondsToolStripMenuItem.Checked = false;
            secondsToolStripMenuItem1.Checked = false;
            secondsToolStripMenuItem2.Checked = true;
            minuteToolStripMenuItem.Checked = false;
            noLimitToolStripMenuItem.Checked = false;
        }

        private void minuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTimeLimit = TimeLimit.OneMinute;
            secondsToolStripMenuItem.Checked = false;
            secondsToolStripMenuItem1.Checked = false;
            secondsToolStripMenuItem2.Checked = false;
            minuteToolStripMenuItem.Checked = true;
            noLimitToolStripMenuItem.Checked = false;
        }

        private void noLimitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTimeLimit = TimeLimit.No_Limit;
            secondsToolStripMenuItem.Checked = false;
            secondsToolStripMenuItem1.Checked = false;
            secondsToolStripMenuItem2.Checked = false;
            minuteToolStripMenuItem.Checked = false;
            noLimitToolStripMenuItem.Checked = true;
        }

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowCount = 5;
            columnCount = 5;
            ResetBoard(true);
            x5ToolStripMenuItem.Checked = true;
            x11ToolStripMenuItem.Checked = false;
            x13ToolStripMenuItem.Checked = false;
            x15ToolStripMenuItem.Checked = false;
            x17ToolStripMenuItem.Checked = false;
        }

        private void x11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowCount = 11;
            columnCount = 11;
            ResetBoard(true);
            x5ToolStripMenuItem.Checked = false;
            x11ToolStripMenuItem.Checked = true;
            x13ToolStripMenuItem.Checked = false;
            x15ToolStripMenuItem.Checked = false;
            x17ToolStripMenuItem.Checked = false;
        }

        private void x13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowCount = 13;
            columnCount = 13;
            ResetBoard(true);
            x5ToolStripMenuItem.Checked = false;
            x11ToolStripMenuItem.Checked = false;
            x13ToolStripMenuItem.Checked = true;
            x15ToolStripMenuItem.Checked = false;
            x17ToolStripMenuItem.Checked = false;
        }

        private void x15ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowCount = 15;
            columnCount = 15;
            ResetBoard(true);
            x5ToolStripMenuItem.Checked = false;
            x11ToolStripMenuItem.Checked = false;
            x13ToolStripMenuItem.Checked = false;
            x15ToolStripMenuItem.Checked = true;
            x17ToolStripMenuItem.Checked = false;
        }

        private void x17ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowCount = 17;
            columnCount = 17;
            ResetBoard(true);
            x5ToolStripMenuItem.Checked = false;
            x11ToolStripMenuItem.Checked = false;
            x13ToolStripMenuItem.Checked = false;
            x15ToolStripMenuItem.Checked = false;
            x17ToolStripMenuItem.Checked = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            //about.Parent = this;
            about.StartPosition = FormStartPosition.CenterParent;
            about.ShowDialog();
            about.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
