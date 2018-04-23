using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private Bitmap blank, red, black;
        private PlayerState PlayerA;
        private PlayerState PlayerB;
        private String PlayerAFilePath;
        private String PlayerBFilePath;
        private GameState CurrentState;
        private PlayerColor CurrentPlayer;
        private TimeLimit CurrentTimeLimit;
        private enum PlayerState { Human = 0x01, Computer = 0x02 }
        private enum GameState { Running = 0x03, Stopped = 0x04 }
        private enum PlayerColor { Red = 0x05, Black = 0x06 }
        private enum TimeLimit { Five = 5000, Ten = 10000, Twenty = 20000, OneMinute = 60000, No_Limit = -1}

        public Connect4()
        {
            InitializeComponent();
            InitializeImages();
            InitializeNewGame();
            CurrentState = GameState.Stopped;
            RED_CURRENT_STATE_LABEL.Text = "Current: Human";
            RED_CONSOLE_CHECKBOX.Visible = false;
            BLACK_CURRENT_STATE_LABEL.Text = "Current: Human";
            BLACK_CONSOLE_CHECKBOX.Visible = false;
            toolStripComboBox1.SelectedIndex = 0;
            CurrentTimeLimit = TimeLimit.Five;
            toolStripComboBox2.SelectedIndex = 0;
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
            PlayerA = PlayerState.Human;
            PlayerB = PlayerState.Human;
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
                if (CurrentPlayer == PlayerColor.Red)
                {
                    cell.Value = red;
                }
                else
                {
                    cell.Value = black;
                }
                markedCells++;
                SwitchPlayers();
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
            RED_CURRENT_STATE_LABEL.Text = "Current: Human";
            RED_CONSOLE_CHECKBOX.Visible = false;
            BLACK_CURRENT_STATE_LABEL.Text = "Current: Human";
            BLACK_CONSOLE_CHECKBOX.Visible = false;
            toolStripComboBox1.Enabled = true;
            toolStripComboBox2.Enabled = true;
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
                toolStripComboBox1.Enabled = false;
                toolStripComboBox2.Enabled = false;
            }
            else
            {
                CurrentState = GameState.Stopped;
                CURRENT_TURN_PICTURE_BOX.Image = blank;
                START_BUTTON.Text = "Start";
                toolStripComboBox1.Enabled = true;
                toolStripComboBox2.Enabled = true;
            }
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

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(toolStripComboBox1.SelectedIndex == 0)
            {
                rowCount = 5;
                columnCount = 5;
                ResetBoard(true);
            }else if(toolStripComboBox1.SelectedIndex == 1)
            {
                rowCount = 11;
                columnCount = 11;
                ResetBoard(true);
            }else
            {
                rowCount = 13;
                columnCount = 13;
                ResetBoard(true);
            }
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

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = toolStripComboBox2.SelectedIndex;
            switch (index)
            {
                case 0:
                    CurrentTimeLimit = TimeLimit.Five;
                    break;
                case 1:
                    CurrentTimeLimit = TimeLimit.Ten;
                    break;
                case 2:
                    CurrentTimeLimit = TimeLimit.Twenty;
                    break;
                case 3:
                    CurrentTimeLimit = TimeLimit.OneMinute;
                    break;
                case 4:
                    CurrentTimeLimit = TimeLimit.No_Limit;
                    break;
                default:
                    CurrentTimeLimit = TimeLimit.Five;
                    toolStripComboBox2.SelectedIndex = 0;
                    break;
            }
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
