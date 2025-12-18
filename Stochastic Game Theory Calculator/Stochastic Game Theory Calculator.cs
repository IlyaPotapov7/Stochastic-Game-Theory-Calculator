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
using Stochastic_Game_Theory_Calculator.Entities;
using Stochastic_Game_Theory_Calculator.Models;
using Stochastic_Game_Theory_Calculator.GraphicsExtension;

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

        
        class Graph
        {
            public class Node
            {
                public string NodeID { get; set; }
                public bool isTerminal { get; set; }

                public float[] payoffs = new float[2];

                public Player owner { get; set; }
                public List<string> connectedNodes { get; set; }
            }
            public class Player
            {
                public string name { get; set; }
                public List<string> Nodes { get; set; }
            }

            public static Node[] currentGraph;

            public float X { get; set; } = 50;
            public float Y { get; set; } = 50;

            public static Node[] defaultGraph()
            {
                Player player1 = new Player();
                player1.name = "Player 1";
                Player player2 = new Player();
                player2.name = "Player 2";
                Node nodeA = new Node();
                nodeA.NodeID = "1";
                nodeA.isTerminal = false;
                nodeA.owner = player1;
                Node nodeB = new Node();
                nodeB.NodeID = "2";
                nodeB.isTerminal = true;
                nodeB.payoffs = new float[] { 3, 2 };
                nodeA.connectedNodes = new List<string> { nodeB.NodeID };
                Node nodeC = new Node();
                nodeC.NodeID = "3";
                nodeC.isTerminal = false;
                nodeC.owner = player2;
                nodeC.connectedNodes = new List<string> { nodeA.NodeID };
                Node nodeD = new Node();
                nodeD.NodeID = "4";
                nodeD.isTerminal = true;
                nodeD.payoffs = new float[] { 1, 4 };
                nodeD.connectedNodes = new List<string> { nodeC.NodeID };
                Node nodeE = new Node();
                nodeE.NodeID = "5";
                nodeE.isTerminal = true;
                nodeE.payoffs = new float[] { 0, 0 };
                nodeE.connectedNodes = new List<string> { nodeC.NodeID };
                return (currentGraph = new Node[] { nodeA, nodeB, nodeC, nodeD, nodeE });
            }

            public void EditGraph(Node[] nodes)
            {
                //add
            }
        }

        class Algorithms
        {
            
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
            currentMatrix = new Models.Matrix();
            currentMatrix = currentMatrix.defaultMatrix();
            MatrixModification MM = new MatrixModification();
            //MM.MatrixBlueprint = 
            MM.ShowDialog();
            saveMatrix(currentMatrix, matrixID);

        }
        public void saveMatrix(Models.Matrix matrix, int matrixID)
        {
            savedMaticies[matrixID] = matrix;
        }


        private void tutorialButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=rA57mAI6cKc");
        }

        private void Canvas_Click(object sender, EventArgs e)
        {

        }

        private Vector currentPosition;
        private List<Entities.Point> points = new List<Entities.Point>();
        private int DrawIndex = -1;
        private bool active_drawing = false;
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //currentPosition = PointToCartesian(e.Location));
            CoordinatesLabel.Text = $"{currentPosition.X:F2}, {currentPosition.Y:F2}";
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
        //private Vector PointToCartesian(Entities.Point point)
       // {
          //  return new Vector(Pixel_to_Mm(point.X), Pixel_to_Mm(Canvas.Height - point.Y));
        //}
        private float Pixel_to_Mm(float pixel)
        {
            return (pixel / DPI) * 25.4f;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (active_drawing)
                {
                    switch (DrawIndex)
                    {
                        case 0:
                            points.Add(new Entities.Point(currentPosition));
                            break;
                    }
                    Canvas.Refresh();
                }
            }

        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParameters(Pixel_to_Mm(Canvas.Height));
            if (points.Count > 0)
            {
                foreach (Entities.Point p in points)
                {
                    e.Graphics.DrawPoint(new Pen(Color.Red,0),p);
                }
            }
        }

        private void SimulationInitialise_Click(object sender, EventArgs e)
        {
            StochasticModification SM = new StochasticModification();
            SM.ShowDialog();
            currentSimulations = SM.itterations;
        }
    }
}