﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private Bitmap blank, red, black;

        public Connect4()
        {
            InitializeImages();
            InitializeComponent();
            InitializeNewGame();
        }

        private void InitializeImages()
        {
            blank = new Bitmap(Properties.Resources.blank);
            red = new Bitmap(Properties.Resources.red);
            black = new Bitmap(Properties.Resources.black);
        }

        private void InitializeNewGame()
        {
            this.AutoSize = true;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GameDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
