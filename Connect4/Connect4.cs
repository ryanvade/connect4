using System;
using System.Drawing;
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
        private GameState CurrentState;
        private PlayerColor CurrentPlayer;
        private enum PlayerState { Human = 0x01, Computer = 0x02 }
        private enum GameState { Running = 0x03, Stopped = 0x04}
        private enum PlayerColor { Red = 0x05, Black = 0x06}

        public Connect4()
        {
            InitializeImages();
            InitializeComponent();
            InitializeNewGame();
            CurrentState = GameState.Stopped;
            CurrentPlayer = PlayerColor.Red;
            PlayerA = PlayerState.Human;
            Player_A_Label.Visible = true;
            Player_A_Label.Text = "Current: Human";
            PlayerB = PlayerState.Human;
            Player_B_Label.Visible = true;
            Player_B_Label.Text = "Current: Human";
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
            this.AutoSize = true;
            splitContainer1.SuspendLayout();
            SuspendLayout();
            GameDataGridView.AllowUserToAddRows = false;
            GameDataGridView.CellClick += new DataGridViewCellEventHandler(game_cell_click);
            GameDataGridView.CellMouseEnter += new DataGridViewCellEventHandler(game_cell_mouse_enter);
            GameDataGridView.CellMouseLeave += new DataGridViewCellEventHandler(game_cell_mouse_leave);

            GameDataGridView.ColumnHeadersVisible = false;
            GameDataGridView.RowHeadersVisible = false;
            GameDataGridView.AllowUserToResizeColumns = false;
            GameDataGridView.AllowUserToResizeRows = false;
            GameDataGridView.RowTemplate.Height = imageHeight;
            GameDataGridView.AutoSize = true;

            DataGridViewImageColumn imageColumn;
            for (int i = 0; i < columnCount; i++)
            {
                Bitmap unMarked = blank;
                imageColumn = new DataGridViewImageColumn();
                imageColumn.Width = imageWidth;
                imageColumn.Image = unMarked;
                //imageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                GameDataGridView.Columns.Add(imageColumn);
            }

            for (int i = 0; i < rowCount; i++)
            {
                GameDataGridView.Rows.Add();
            }

            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void switch_players()
        {
            if(CurrentPlayer == PlayerColor.Red)
            {
                if(PlayerA == PlayerState.Computer)
                {
                    // Handle Computer Player
                }
                CurrentPlayer = PlayerColor.Black;
            }else
            {
                if(PlayerB == PlayerState.Computer)
                {
                    // Handle Computer Player
                }
                CurrentPlayer = PlayerColor.Red;
            }
        }

        private void check_for_end_condition()
        {
            if(markedCells == rowCount * columnCount)
            {
                // Game is over, reset
                GameDataGridView.Rows.Clear();
                GameDataGridView.Columns.Clear();
                InitializeNewGame();
            }
        }

        private void game_cell_click(object sender, DataGridViewCellEventArgs e)
        {
            if(CurrentState == GameState.Stopped)
            {
                return;
            }

            if(CurrentPlayer == PlayerColor.Red && PlayerA == PlayerState.Computer)
            {
                return;
            }

            if(CurrentPlayer == PlayerColor.Black && PlayerB == PlayerState.Computer)
            {
                return;
            }

            DataGridViewImageCell cell = (DataGridViewImageCell)GameDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if(cell.Value == blank)
            {
                if(CurrentPlayer == PlayerColor.Red)
                {
                    cell.Value = red;
                }else
                {
                    cell.Value = black;
                }
                markedCells++;
                switch_players();
            }
            check_for_end_condition();
        }

        private void game_cell_mouse_enter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void game_cell_mouse_leave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void initImages()
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayerA = PlayerState.Human;
            checkBox1.Enabled = false;
            checkBox1.Checked = false;
            Player_A_Label.Text = "Current: Human";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayerA = PlayerState.Computer;
            checkBox1.Enabled = true;
            Player_A_Label.Text = "Current: Computer";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlayerB = PlayerState.Human;
            checkBox2.Enabled = false;
            checkBox2.Checked = false;
            Player_B_Label.Text = "Current: Human";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PlayerB = PlayerState.Computer;
            checkBox2.Enabled = true;
            Player_B_Label.Text = "Current: Computer";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(CurrentState == GameState.Running)
            {
                Start_Button.Text = "Start";
                CurrentState = GameState.Stopped;
            }else
            {
                Start_Button.Text = "Stop";
                CurrentState = GameState.Running;
            }
        }

        private void OverPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            CurrentState = GameState.Stopped;
            Start_Button.Text = "Start";
            GameDataGridView.Rows.Clear();
            GameDataGridView.Columns.Clear();
            InitializeNewGame();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GameDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
