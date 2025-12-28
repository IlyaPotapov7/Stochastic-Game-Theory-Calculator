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
        public Models.Matrix[] savedMaticies;
        public int matrixID = 0;

        private int currentSimulations;

        public Font text_font = new Font("Times New Roman", 11, FontStyle.Regular);
        public Font payoff_font = new Font("Times New Roman", 12, FontStyle.Regular);
        public Font name_font = new Font("Times New Roman", 12, FontStyle.Bold);

        int CellBuffer = 5;

        private float zoomDelta = 0.6f;
        private PointF zoomFocus = new PointF(0, 0);

        private int movingMatrixID = -1;
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
            savedMaticies = new Models.Matrix[100];
        }

        // This subroutine will handle the initialisation of a new matrix
        private void MatrixInitialise_Click(object sender, EventArgs e)
        {
            if (!stopSelection())
            {
                currentMatrix = new Models.Matrix();
                currentMatrix = currentMatrix.defaultMatrix();
                currentMatrix.X = 100;
                currentMatrix.Y = 70;
                currentMatrix.setMatrixID(matrixID);
                editMatrix();
                matrixID++;
            }
        }

        public void editMatrix()
        {
            MatrixModification MM = new MatrixModification();
            MM.recieveMatrix(currentMatrix);
            MM.ShowDialog();

            if (MM.deleted)
            {
                savedMaticies[currentMatrix.MatrixID] = null;
            }
            else if (MM.isSaved)
            {
                currentMatrix = MM.currentMatrix;
                bool positionVerified = false;

                using (Graphics g = this.CreateGraphics())
                {
                    //try different locaations until it is not taken
                    while (!positionVerified)
                    {
                        //assume true, and if not change back to false
                        positionVerified = true;


                        currentMatrix.hitbox = MatrixBounds(currentMatrix, g);


                        for (int i = 0; i < matrixID; i++)
                        {
                            if (savedMaticies[i] == null || savedMaticies[i].MatrixID == currentMatrix.MatrixID)
                            {
                                continue;
                            }
                            else if (savedMaticies[i] != null)
                            {
                                if (currentMatrix.hitbox.IntersectsWith(savedMaticies[i].hitbox))
                                {
                                    positionVerified = false;
                                    currentMatrix.X += 20;
                                    currentMatrix.Y += 20;
                                    break;
                                }
                            }

                        }

                    }

                }
                savedMaticies[currentMatrix.MatrixID] = MM.currentMatrix;
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
            if (isDragged && movingMatrixID > -1)
            {
                //get current world mouse position
                PointF worldMouseCoord = screenToWorldTranslate(e.Location);

                //new matrix position
                savedMaticies[movingMatrixID].X = worldMouseCoord.X - selectPoint.X;
                savedMaticies[movingMatrixID].Y = worldMouseCoord.Y - selectPoint.Y;

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
            if (isDragged && movingMatrixID > -1)
            {
                bool collision = false;

                using (Graphics g = this.CreateGraphics())
                {
                    savedMaticies[movingMatrixID].hitbox = MatrixBounds(savedMaticies[movingMatrixID], g);

                    for (int i = 0; i < matrixID; i++)
                    {
                        //avoid checking coordinates of the dragged matrix with it's old position
                        if (i == movingMatrixID)
                        {
                            continue;
                        }

                        if (savedMaticies[i] != null)
                        {
                            //get the dymentions of the matrix that is being compared with

                            savedMaticies[i].hitbox = MatrixBounds(savedMaticies[i], g);

                            if (savedMaticies[i].hitbox.IntersectsWith(savedMaticies[movingMatrixID].hitbox))
                            {
                                collision = true;
                                break;
                            }
                        }

                    }
                }
                //if the collision happens, the moving matrix returns back to where it was before the movement

                if (collision)
                {
                    savedMaticies[movingMatrixID].X = startingPosition.X;
                    savedMaticies[movingMatrixID].Y = startingPosition.Y;
                    MessageBox.Show("Matrices cannot overlap");
                }

                isDragged = false;
                movingMatrixID = -1;

                Canvas.Invalidate();
            }
            panning = false;
        }
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            PointF worldMouseLocation = screenToWorldTranslate(e.Location);

            using (Graphics g = this.CreateGraphics())
            {

                for (int i = 0; i < matrixID; i++)
                {
                    Models.Matrix matrix = savedMaticies[i];
                    if (matrix != null)
                    {
                        matrix.hitbox = MatrixBounds(matrix, g);

                        //if matrix is clicked on with the right nouse button it is set as a current matrix.
                        //if its being selected for solving, it will skip editing and will finish selection
                        if (e.Button == MouseButtons.Right && matrix.hitbox.Contains(worldMouseLocation))
                        {
                            currentMatrix = matrix;
                            if (!matrixSelection)
                            {
                                editMatrix();
                            }
                            else
                            {
                                matrixSelection = false;
                                BestResponceEnumeration(currentMatrix);
                            }
                            break;

                        }
                        else if (matrix.hitbox.Contains(worldMouseLocation))
                        {
                            movingMatrixID = i;
                            isDragged = true;

                            selectPoint = new PointF(worldMouseLocation.X - matrix.X, worldMouseLocation.Y - matrix.Y);

                            startingPosition = new PointF(matrix.X, matrix.Y);

                            break;
                        }
                    }
                }
            }

            if (movingMatrixID == -1 && e.Button == MouseButtons.Left)
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
            foreach (string s in matrix.ColStrategies)
            {
                SizeF size = g.MeasureString(s, text_font);
                if (size.Width > maxWidth)
                {
                    maxWidth = size.Width;
                }
            }

            for (int r = 0; r < matrix.rows; r++)
            {
                for (int c = 0; c < matrix.cols; c++)
                {
                    string text = matrix.payoffs[r, c];

                    SizeF size = g.MeasureString(text, payoff_font);
                    if (size.Width > maxWidth)
                    {
                        maxWidth = size.Width;
                    }
                }
            }

            return maxWidth;

        }
        private void DrawMatrix(Graphics g, Models.Matrix matrix)
        {
            float cellHight = 60;
            float cellWidth = 100;

            float contentWidth = LongestCol(matrix, g);
            cellWidth = Math.Max(cellHight, contentWidth + (CellBuffer * 2));

            float gridW = matrix.cols * cellWidth;
            float gridH = matrix.rows * cellHight;

            RectangleF currentGrid = new RectangleF(matrix.X + cellWidth, matrix.Y + cellHight, gridW, gridH);
            g.FillRectangle(Brushes.White, currentGrid);
            g.DrawRectangle(Pens.Black, currentGrid.X, currentGrid.Y, currentGrid.Width, currentGrid.Height);

            using (Pen gridPen = new Pen(Color.Black, 1))
            using (StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.DrawString(matrix.Players[0], name_font, Brushes.Black, new PointF(matrix.X - 47, matrix.Y + cellHight + (gridH / 2)), format);
                g.DrawString(matrix.Players[1], name_font, Brushes.Black, new PointF(matrix.X + cellWidth + (gridW / 2), matrix.Y - 10), format);

                for (int r = 0; r < matrix.rows; r++)
                {
                    float rowYcord = matrix.Y + cellHight + (r * cellHight);
                    RectangleF rowStrategies = new RectangleF((matrix.X)-CellBuffer, rowYcord, cellWidth, cellHight);
                    g.DrawString(matrix.RowStrategies[r], text_font, Brushes.Black, rowStrategies, format);

                    for (int c = 0; c < matrix.cols; c++)
                    {
                        float colXcrd = matrix.X + cellWidth + (c * cellWidth);

                        if (r == 0)
                        {
                            RectangleF colHeaderRect = new RectangleF(colXcrd, matrix.Y, cellWidth, cellHight);
                            g.DrawString(matrix.ColStrategies[c], text_font, Brushes.Black, colHeaderRect, format);
                        }
                        g.DrawRectangle(gridPen, colXcrd, rowYcord, cellWidth, cellHight);

                        RectangleF cellPic = new RectangleF(colXcrd, rowYcord, cellWidth, cellHight);
                        g.DrawString(matrix.payoffs[r, c], payoff_font, Brushes.Black, cellPic, format);
                    }
                }
            }
        }

        private void Canvas_MouseWheel(object sender, MouseEventArgs e)
        {

            float canvasX = (e.X - zoomFocus.X) / zoomDelta;
            float canvasY = (e.Y - zoomFocus.Y) / zoomDelta;

            if(e.Delta > 0)
            {
                zoomDelta = zoomDelta * 1.1f;
            }
            else
            {
                zoomDelta = zoomDelta * 0.9f;
            }

            if (zoomDelta < 0.5f)
            {
                zoomDelta = 0.5f;
            }
            if (zoomDelta > 4.0f)
            {
                zoomDelta = 4.0f;
            }

            zoomFocus.X = e.X - (canvasX * zoomDelta);
            zoomFocus.Y = e.Y - (canvasY * zoomDelta);

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

            float totalWidth = (matrix.cols * cellWidth) + cellWidth;

            float totalHeight = (matrix.rows * cellHight) + cellHight;

            return new RectangleF(matrix.X, matrix.Y, totalWidth, totalHeight);
        }

        private void SimulationInitialise_Click(object sender, EventArgs e)
        {
            stopSelection();
            StochasticModification SM = new StochasticModification();
            SM.ShowDialog();
            currentSimulations = SM.itterations;
        }

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
            int matrixCount = 0;

            for (int i = 0; i < matrixID; i++)
            {
                if (savedMaticies[i] != null)
                {
                    matrixCount++;
                }
            }

            if(matrixCount == 0)
            {
                MessageBox.Show("There are currently no existing matrix");
            }
            else if(matrixCount > 1)
            {
                MessageBox.Show("Please select a matrix to solve"); 
                matrixSelection = true;
            }
            else
            {
                for (int i = 0; i < matrixID; i++)
                {
                    if (savedMaticies[i] != null)
                    {
                        currentMatrix = savedMaticies[i];
                    }
                }

                BestResponceEnumeration(currentMatrix);
            }
        }
        private void solveButton_Click(object sender, EventArgs e)
        {
            select_Matrix();
            //now, the current matrix is the matrix that the user wants to solve, so we can implement the algorithm

        }

        public void BestResponceEnumeration(Models.Matrix matrix)
        {
            MessageBox.Show("The selected matrix will now be solved via the Best Responce Enumeration Algorithm");
        }

    }
}