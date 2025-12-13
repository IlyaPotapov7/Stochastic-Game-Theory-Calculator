using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stochastic_Game_Theory_Calculator
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        private Matrix currentMatrix; 

        class CanvasManager
        {
            private float zoomLevel = 1.0f;
            private float panX = 0.0f;
            private float panY = 0.0f;
            
        }
        class CanvasRenderer
        {


        }

        class Matrix
        {
            public int rows { get; set; }
            public int cols { get; set; }
            public float[,] payoffs { get; set; }
            public string[] RowStrategies { get; set; }
            public string[] ColStrategies { get; set; }

            //position of the matrix on the canvas
            public float X { get; set; } = 50;
            public float Y { get; set; } = 50;

            public void initialiseMatrix(int r, int c, string[] rowstrategies, string[] colstrategies)
            {
                rows = r;
                cols = c;
                RowStrategies = rowstrategies;
                ColStrategies = colstrategies;
            }

            public void setPayoffs(Matrix matrix, float[,] payoffs)
            {
                matrix.payoffs = payoffs;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MatrixInitialise_Click(object sender, EventArgs e)
        {
            currentMatrix = new Matrix();
          

        }

        private void tutorialButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=rA57mAI6cKc");
        }

        private void Canvas_Click(object sender, EventArgs e)
        {

        }
    }
}
