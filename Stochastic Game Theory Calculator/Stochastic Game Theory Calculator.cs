using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stochastic_Game_Theory_Calculator.Models;

namespace Stochastic_Game_Theory_Calculator
{


    public partial class mainWindow : Form
    {
        private Models.Matrix currentMatrix;
        private Graph currentGraph;
        private int currentSimulations;
        public Models.Matrix[] savedMaticies;
        public int matrixID = 0;
        private int graphID = 0;
        private Graph[] savedGraphs;
        public mainWindow()
        {
            InitializeComponent();
        }

        class CanvasManager
        {
            private float zoomLevel = 1.0f;
            private float panX = 0.0f;
            private float panY = 0.0f;

        }
        class CanvasRenderer
        {


        }

        

        class Algorithms
        {
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            savedMaticies = new Models.Matrix[100];
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MatrixInitialise_Click(object sender, EventArgs e)
        {
            currentMatrix = new Models.Matrix();
            currentMatrix = currentMatrix.defaultMatrix();
            currentMatrix.setMatrixID(matrixID);
            MatrixModification MM = new MatrixModification();
            MM.recieveMatrix(currentMatrix);
            MM.ShowDialog();
            savedMaticies[currentMatrix.MatrixID] = MM.currentMatrix;
            matrixID++;
        }


        private void tutorialButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=rA57mAI6cKc");
        }

        private void Canvas_Click(object sender, EventArgs e)
        {

        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            float X = Pixel_to_Mm(e.X);
            float Y = Pixel_to_Mm(Canvas.Height - e.Y);
            CoordinatesLabel.Text = $"{X:F2}, {Y:F2}";
        
        }
        private float Pixel_to_Mm(float pixel)
        {
            return (pixel / DPI) * 25.4f;
        }

        private float DPI
        {
            get
            {
                using (Graphics g = this.CreateGraphics())
                {
                    return g.DpiX;
                }

            }

        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void SimulationInitialise_Click(object sender, EventArgs e)
        {
            StochasticModification SM = new StochasticModification();
            SM.ShowDialog();
            currentSimulations = SM.itterations;
        }

    }
}