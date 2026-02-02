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
        // Here I will initialise variables for all subroutines to make them easier to organise and find

        private Models.Matrix currentMatrix;
        public List<Models.Matrix> savedMaticies;
        public Models.Matrix movingMatrix;

        private int currentSimulations;

        public Font text_font = new Font("Times New Roman", 11, FontStyle.Regular);
        public Font payoff_font = new Font("Times New Roman", 12, FontStyle.Regular);
        public Font player_font = new Font("Times New Roman", 12, FontStyle.Bold);
        public Font name_font = new Font("Times New Roman", 14, FontStyle.Italic);
        public Font origin_font = new Font("Times New Roman", 25, FontStyle.Bold);

        int CellBuffer = 5;

        public bool EditingMatrix;

        private float zoomDelta = 0.9f;
        private PointF zoomFocus = new PointF(0, 0);
        private PointF originPoint = new PointF(0,0);

        private PointF selectPoint = new PointF(0, 0);
        private PointF startingPosition = new PointF(0, 0);
        private bool isDragged = false;

        private bool panning = false;
        private PointF previousPoint;

        public bool matrixSelection = false;

        public mainWindow()
        {
            InitializeComponent();
            Canvas.MouseWheel += Canvas_MouseWheel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            savedMaticies = new List<Models.Matrix>();
            
        }

        // This subroutine will handle the initialisation of a new matrix
        private void MatrixInitialise_Click(object sender, EventArgs e)
        {
            if (!stopSelection())
            {
                currentMatrix = new Models.Matrix();
                currentMatrix = currentMatrix.defaultMatrix();
                editMatrix();
            }
        }

        public void localise_matrix(Models.Matrix matrix)
        {
            bool positionVerified = false;

            using (Graphics g = this.CreateGraphics())
            {
                //try different locaations until it is not taken
                while (!positionVerified)
                {
                    //assume true, and if not change back to false
                    positionVerified = true;


                    matrix.SetHitbox(MatrixBounds(matrix, g));


                    foreach(Models.Matrix m in savedMaticies)
                    { 
                           if(m == matrix)
                           {
                                     continue;
                           }
                            else if (matrix.GetHitbox().IntersectsWith(m.GetHitbox()))
                            {
                                positionVerified = false;
                                matrix.ChangeX(20);
                                matrix.ChangeY(20);
                                break;
                            }

                    }

                }

            }
        }

        public void editMatrix()
        {
            EditingMatrix = true;
            MatrixModification MM = new MatrixModification();
            MM.recieveMatrix(currentMatrix);
            MM.ShowDialog();

            while (EditingMatrix)
            {
                EditingMatrix = false;
                if (MM.deleted)
                {
                    savedMaticies.Remove(currentMatrix);
                }
                else if (MM.isSaved)
                {
                    if (MM.VerifyPayofsFloat())
                    {
                        savedMaticies.Remove(currentMatrix);
                        currentMatrix = MM.currentMatrix;
                        localise_matrix(currentMatrix);
                        savedMaticies.Add(MM.currentMatrix);
                    }
                    else
                    {
                        MM.ShowDialog();
                        EditingMatrix = true;
                    }
                }
            }
                Canvas.Invalidate();
        }
        private void tutorialButton_Click(object sender, EventArgs e)
        {
            if (!stopSelection())
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=rA57mAI6cKc");
            }
        }

        private void Canvas_Click(object sender, EventArgs e)
        {

        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragged && movingMatrix != null)
            {
                //get current world mouse position
                PointF worldMouseCoord = screenToWorldTranslate(e.Location);

                //new matrix position
                movingMatrix.SetX(worldMouseCoord.X - selectPoint.X);
                movingMatrix.SetY(worldMouseCoord.Y - selectPoint.Y);

                Canvas.Invalidate();
            }
            else if (panning)
            {
                zoomFocus.X += e.X - previousPoint.X;
                zoomFocus.Y += e.Y - previousPoint.Y;
                previousPoint = e.Location;
                Canvas.Invalidate();
            }

        }
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragged && movingMatrix != null)
            {
                bool collision = false;

                using (Graphics g = this.CreateGraphics())
                {
                    movingMatrix.SetHitbox(MatrixBounds(movingMatrix, g));

                    foreach (Models.Matrix savedMatrix in savedMaticies)
                    {
                        {
                            //avoid checking coordinates of the dragged matrix with it's old position
                            if (savedMatrix.IsMoving())
                            {
                                continue;
                            }

                            //get the dymentions of the matrix that is being compared with

                            savedMatrix.SetHitbox(MatrixBounds(savedMatrix, g));

                            if (savedMatrix.GetHitbox().IntersectsWith(movingMatrix.GetHitbox()))
                            {
                                collision = true;
                                break;
                            }

                        }
                    }
                    //if the collision happens, the moving matrix returns back to where it was before the movement

                    if (collision)
                    {
                        movingMatrix.SetX(startingPosition.X);
                        movingMatrix.SetY(startingPosition.Y);
                        MessageBox.Show("Matrices cannot overlap");
                    }

                    isDragged = false;
                    movingMatrix.SetIsMoving(false);
                    movingMatrix = null;

                    Canvas.Invalidate();
                }
            }
            panning = false;
        }


        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            PointF worldMouseLocation = screenToWorldTranslate(e.Location);

            using (Graphics g = this.CreateGraphics())
            {

                foreach(Models.Matrix matrix in savedMaticies)
                {
                    if (matrix != null)
                    {
                        matrix.SetHitbox(MatrixBounds(matrix, g));

                        //if matrix is clicked on with the right nouse button it is set as a current matrix.
                        //if its being selected for solving, it will skip editing and will finish selection
                        if (e.Button == MouseButtons.Right && matrix.GetHitbox().Contains(worldMouseLocation))
                        {
                            currentMatrix = matrix;
                            if (!matrixSelection)
                            {
                                editMatrix();
                            }
                            else
                            {
                                matrixSelection = false;
                                BestResponceEnumeration();
                            }
                            break;

                        }
                        else if (matrix.GetHitbox().Contains(worldMouseLocation))
                        {
                            movingMatrix = matrix;
                            movingMatrix.SetIsMoving(true);
                            isDragged = true;

                            selectPoint = new PointF(worldMouseLocation.X - matrix.GetX(), worldMouseLocation.Y - matrix.GetY());

                            startingPosition = new PointF(matrix.GetX(), matrix.GetY());

                            break;
                        }
                    }
                }
            }

            if (movingMatrix == null && e.Button == MouseButtons.Left)
            {
                panning = true;
                previousPoint = e.Location;
            }

        }
    

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(zoomFocus.X, zoomFocus.Y);
            e.Graphics.ScaleTransform(zoomDelta, zoomDelta);

            foreach (var matrix in savedMaticies)
            {
                if (matrix != null)
                {
                    DrawMatrix(e.Graphics, matrix);
                }
            }
        }
        //this loop will compare each strategy length in columns and will save the longest one, this is neccesary as it columns in the matrix are the same and are determined by the longest strategy name
        private float LongestCol(Models.Matrix matrix, Graphics g)
        {
            float maxWidth = 0;
            foreach (string s in matrix.GetColStrategies())
            {
                SizeF size = g.MeasureString(s, text_font);
                if (size.Width > maxWidth)
                {
                    maxWidth = size.Width;
                }
            }

            for (int r = 0; r < matrix.GetRows(); r++)
            {
                for (int c = 0; c < matrix.GetCols(); c++)
                {
                    string text = matrix.GetOnePayoff(r, c);

                    SizeF size = g.MeasureString(text, payoff_font);
                    if (size.Width > maxWidth)
                    {
                        maxWidth = size.Width;
                    }
                }
            }

            return maxWidth;

        }
        //this method will contain all drawing logic for the canvas
        
        //I was not familiar with drawing on bitmap images in C# so I asked Google Gemeni to teach me the basics and I also I asked it for help when I had bugs in my implementation
        private void DrawMatrix(Graphics g, Models.Matrix matrix)
        {
            //display the origin location for refference
            g.DrawString("*", origin_font, Brushes.Red, originPoint);

            //set default cell height
            float cellHight = 60;
            //find the max width column and compare it with default cell width of a 100
            float contentWidth = LongestCol(matrix, g);
            float cellWidth = Math.Max(100, contentWidth + (CellBuffer * 2));

            //find dimentions of the grid of the matrix
            float gridW = matrix.GetCols() * cellWidth;
            float gridH = matrix.GetRows() * cellHight;
            
            //initialise the matrix rectangle, fill it with white background and draw the external bounds
            RectangleF currentGrid = new RectangleF(matrix.GetX() + cellWidth, matrix.GetY() + cellHight, gridW, gridH);
            g.FillRectangle(Brushes.White, currentGrid);
            g.DrawRectangle(Pens.Black, currentGrid.X, currentGrid.Y, currentGrid.Width, currentGrid.Height);

            //initialise a pen to draw the contents of the matrix and the format of the strings that will be drawn
            using (Pen gridPen = new Pen(Color.Black, 1))
            using (StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                //Draw the player names and the name of the game
                g.DrawString(matrix.GetOnePlayer(0), player_font, Brushes.Black, new PointF(matrix.GetX() - (g.MeasureString(matrix.GetOnePlayer(0), player_font).Width / 2) - CellBuffer, matrix.GetY() + cellHight + (gridH / 2)), format); // I couldnt work out how to allign the name vertically as it cept on clashing with strategies so I asked Gemeni for a robust maths that ensures perfect allignment 
                g.DrawString(matrix.GetOnePlayer(1), player_font, Brushes.Black, new PointF(matrix.GetX() + cellWidth + (gridW / 2), matrix.GetY() - 10), format);
                g.DrawString(matrix.GetName(), name_font, Brushes.Black, new PointF(matrix.GetX(),matrix.GetY()), format);

                for (int r = 0; r < matrix.GetRows(); r++)
                {
                    float rowYcord = matrix.GetY() + cellHight + (r * cellHight);
                    RectangleF rowStrategies = new RectangleF((matrix.GetX())-CellBuffer, rowYcord, cellWidth, cellHight);
                    g.DrawString(matrix.GetOneRowStrategy(r), text_font, Brushes.Black, rowStrategies, format);

                    for (int c = 0; c < matrix.GetCols(); c++)
                    {
                        float colXcrd = matrix.GetX() + cellWidth + (c * cellWidth);

                        if (r == 0)
                        {
                            RectangleF colHeaderRect = new RectangleF(colXcrd, matrix.GetY(), cellWidth, cellHight);
                            g.DrawString(matrix.GetOneColStrategy(c), text_font, Brushes.Black, colHeaderRect, format);
                        }
                        g.DrawRectangle(gridPen, colXcrd, rowYcord, cellWidth, cellHight);

                        RectangleF cellPic = new RectangleF(colXcrd, rowYcord, cellWidth, cellHight);
                        g.DrawString(matrix.GetOnePayoff(r, c), payoff_font, Brushes.Black, cellPic, format);
                    }
                }
            }

        }

        //this method will handel the mousewheel input and in responce change the level of zoom on the canvas
        private void Canvas_MouseWheel(object sender, MouseEventArgs e)
        {
            //i need to convert the world coordinates into screen coordinates
            //first, handle the shift of the focus point X - ZoomFocus and account for the zoom by deviding the current difference by the change in zoom

            float canvasX = (e.X - zoomFocus.X) / zoomDelta;
            float canvasY = (e.Y - zoomFocus.Y) / zoomDelta;

            //if zoom is positive, increment by 10% ech time, if zoom is negative, fecrease by 10%
            if(e.Delta > 0)
            {
                zoomDelta = zoomDelta * 1.1f;
            }
            else
            {
                zoomDelta = zoomDelta * 0.9f;
            }

            // Set limits on how big or small zoom can be
            if (zoomDelta < 0.3f)
            {
                zoomDelta = 0.3f;
            }
            if (zoomDelta > 4.0f)
            {
                zoomDelta = 4.0f;
            }

            //make the actual change to how the image looks, e.X and e.Y are the centre or the focus - saceld world distance (as a reuslt the point of zoom is alligned with the location of the mouse
            zoomFocus.X = e.X - (canvasX * zoomDelta);
            zoomFocus.Y = e.Y - (canvasY * zoomDelta);

            //update the changes to the canvas
            Canvas.Invalidate();
        }

        //this subroutine will convert screen coordinates to world coordinates which is nessecary for selecting objects on a canvas by clicking on them 
        private PointF screenToWorldTranslate(Point screenCoord)
        {
            float worldX = (screenCoord.X - zoomFocus.X) / zoomDelta;
            float worldY = (screenCoord.Y - zoomFocus.Y) / zoomDelta;
            return new PointF(worldX, worldY);
        }


        //this subroutine will find the bounds of the matrix which I will later use to prevent the user from stacking matrices on top of each other, decreasing the probability of confusion
        private RectangleF MatrixBounds(Models.Matrix matrix, Graphics g)
        {
            float cellHight = 60;

            float cellWidth = Math.Max(cellHight, LongestCol(matrix, g) + CellBuffer);

            float totalWidth = (matrix.GetCols() * cellWidth) + cellWidth;

            float totalHeight = (matrix.GetRows() * cellHight) + cellHight;

            return new RectangleF(matrix.GetX(), matrix.GetY(), totalWidth + 30f, totalHeight+30f);
        }

        private void SimulationInitialise_Click(object sender, EventArgs e)
        {
            if (!stopSelection())
            {
                StochasticModification SM = new StochasticModification();
                SM.ShowDialog();
                currentSimulations = SM.itterations;
            }
        }


        //I will use this method as a safety boundariy so that is the user clicks anything else during matrix selection process, he will have to either terminate selection or be remined that he is selecting a m atrix
        private bool stopSelection()
        {
            if (matrixSelection)
            {
                DialogResult responce = MessageBox.Show("You have to finish matrix selection before proceeding. Would you like to cancel selection?", "Selection in Progress", MessageBoxButtons.YesNo);
                if (responce == DialogResult.Yes)
                {
                    matrixSelection = false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void select_Matrix()
        {
            //first i have to identify what matrix to solve, if there are more than 1, user will have to select which one
            currentMatrix = null;
            int matrixCount = savedMaticies.Count();

            if(matrixCount == 0)
            {
                MessageBox.Show("There are currently no existing matrix");
            }
            else
            {
                MessageBox.Show("Please select a matrix to solve"); 
                matrixSelection = true;
            }

        }
        private void solveButton_Click(object sender, EventArgs e)
        {
            select_Matrix();
            //now, the current matrix is the matrix that the user wants to solve, so we can implement the solving algorithm
        }

        public void BestResponceEnumeration()
        {
            //I have asked Chat GPT what would be the best algorithm to solve pure strategy normal form games, I was originally considering IESDS but it only finds nash equalibria that is in the strictly dominant strategies. Although it it more time efficient, i chose BRE because is finds all equalibria
            MessageBox.Show(currentMatrix.GetName() + " will now be solved via the Best Responce Enumeration Algorithm");

            //prepare data for comparison, i need some way of marking cells in rows and columns as best responces in order to compare them later to find the intersection and also do maths with them

            bool[,] Player1BestResponses = new bool[currentMatrix.GetRows(), currentMatrix.GetCols()];
            bool[,] Player2BestResponses = new bool[currentMatrix.GetRows(), currentMatrix.GetCols()];

            float[,] Player1Payoffs = new float[currentMatrix.GetRows(), currentMatrix.GetCols()];
            float[,] Player2Payoffs = new float[currentMatrix.GetRows(), currentMatrix.GetCols()];

            //Player 1 analysis
            //Convert payoffs stored as string into float in order to run math with them
            for (int row = 0; row < currentMatrix.GetRows(); row++)
                {
                    for (int column = 0; column < currentMatrix.GetCols(); column++)
                    {
                        string stringPayoff = currentMatrix.GetOnePayoff(row, column);
                        string[] parts = stringPayoff.Split(':');

                    Player1Payoffs[row, column] = float.Parse(parts[0]);
                    Player2Payoffs[row, column] = float.Parse(parts[1]);
                    }
                }

            // now actual logic of the algorithm 

                //fix the column for player 2
                for (int col = 0; col < currentMatrix.GetCols(); col++)
                {
                    //finds the payoff for player 1 for a currently fixed column
                    float maxPlayer1 = -999999999999999999; //assume the current payoff for player1 is as bad as bossible as so in the first comparsion the first payoff will always be better not matter how bad it is
                    for (int row = 0; row < currentMatrix.GetRows(); row++)
                    {
                        if (Player1Payoffs[row, col] > maxPlayer1)
                        {
                            maxPlayer1 = Player1Payoffs[row, col]; 
                        }
                    }

                    //Highlight each cell with the max payoff for a given cell
                    for (int row = 0; row < currentMatrix.GetRows(); row++)
                    {
                        if (Player1Payoffs[row, col] == maxPlayer1)
                        {
                            Player1BestResponses[row, col] = true;
                        }
                    }
                }

                ///Player 2 analysis
                //fix a row
                for (int row = 0; row < currentMatrix.GetRows(); row++)
                {
                    //compare possible payoffs
                    float maxPlayer2 = -999999999999999999;
                    for (int columns = 0; columns < currentMatrix.GetCols(); columns++)
                    {
                        if (Player2Payoffs[row, columns] > maxPlayer2)
                        {
                        maxPlayer2 = Player2Payoffs[row, columns];
                        }
                    }

                    //highlight every payoff-maximising cell per given row for player 2
                    for (int c = 0; c < currentMatrix.GetCols(); c++)
                    {
                        if (Player2Payoffs[row, c] == maxPlayer2)
                        {
                        Player2BestResponses[row, c] = true;
                        }
                    }
                }

                // Find intersections of best responces (Nash Equalibrium Cells)

                List<string> NashEqualibria = new List<string>(); //tenporary output

                for (int r = 0; r < currentMatrix.GetRows(); r++)
                {
                    for (int c = 0; c < currentMatrix.GetCols(); c++)
                    {
                        // if both cells are true, they intersect
                        if (Player1BestResponses[r, c] && Player2BestResponses[r, c])
                        {
                            NashEqualibria.Add($"{currentMatrix.GetOnePlayer(0)} chooses {currentMatrix.GetOneRowStrategy(r)}\n{currentMatrix.GetOnePlayer(1)} chooses {currentMatrix.GetOneColStrategy(r)}\nThe payoffs are: {currentMatrix.GetOnePayoff(r, c)}");
                        }
                    }
                }

                //return results
                if (NashEqualibria.Count > 0)
                {
                    string outputString = "Pure Strategy Nash Equilibria in "+currentMatrix.GetName() + " are:\n\n";
                    foreach (string val in NashEqualibria)
                    {
                        outputString += val + "\n\n";
                    }
                    MessageBox.Show(outputString, "Output");
                }
                else
                {
                    MessageBox.Show("In "+ currentMatrix.GetName() + " no Pure Strategy Nash Equilibrium exists.", "Output");
                }

        }

        private void ConnectionInitialise_Click(object sender, EventArgs e)
        {
            if (!stopSelection())
            {
                //add
            }
        }

        //now i will add methods for easier canvas navigation 

        // origin is the red dot in the top left corner next to which matricies appear when they are initialised
        private void return_to_origin_Click(object sender, EventArgs e)
        {
            zoomFocus = originPoint;
            Canvas.Invalidate();
        }


        //make all matricies appear close to origin so no matricies are lost
        private void lockalise_matricies_Click(object sender, EventArgs e)
        {
            foreach(Models.Matrix m in savedMaticies)
            {
                m.SetX(150);
                m.SetY(80);
                localise_matrix(m); 
            }
            Canvas.Invalidate();
        }

        //return zoom to default value if too zoomed in on something too much or out too much, more of a shortcut than anything else
        private void zoom_to_default_Click(object sender, EventArgs e)
        {
            zoomDelta = 0.9f;
            Canvas.Invalidate();
        }
    }
}