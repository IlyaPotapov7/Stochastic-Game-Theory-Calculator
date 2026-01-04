using Stochastic_Game_Theory_Calculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Stochastic_Game_Theory_Calculator
{
    public partial class MatrixModification : Form
    {
        public Models.Matrix currentMatrix = new Models.Matrix();
        public Models.Matrix lastSavedMatrix = new Models.Matrix();
        public bool isSaved = false;
        public bool deleted = false;

        public void recieveMatrix(Models.Matrix matrix)
        {
            currentMatrix = copyMatrix(matrix);
            lastSavedMatrix = copyMatrix(matrix);
        }

        public MatrixModification()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void AccesabilityLimit()
        {
            for (int r = 1; r < MatrixBlueprint.RowCount; r++)
            {
                if (r == 2)
                {
                    continue;
                }
                MatrixBlueprint[0, r].ReadOnly = true; 
            }
            for (int c = 1; c < MatrixBlueprint.ColumnCount; c++)
            {
                if (c == 2)
                {
                    continue;
                }
                MatrixBlueprint[c, 0].ReadOnly = true;
            }

        }

        private bool VerifyPayofsFloat()
        {
            string[] splitPayoff = null;

            for(int r = 0; r < currentMatrix.rows; r++)
            {
                for (int x = 0; x < currentMatrix.cols; x++)
                {
                    object cellValue = MatrixBlueprint[x + 2, r + 2].Value;

                    if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                    {
                        MessageBox.Show($"Cell {x+3},{r+3} is empty. Please fill in the payoff");
                        return false;
                    }
                    splitPayoff = cellValue.ToString().Split(':');
                    if (splitPayoff.Length != 2 || !float.TryParse(splitPayoff[0], out _) || !float.TryParse(splitPayoff[1], out _))
                    {
                        MessageBox.Show($"The value '{(MatrixBlueprint[x+2,r+2]).Value}' is invalid, the payoff must be in the form 'number:number'");
                        return false;
                    }
                }
            }
            return true;
        }

        private void MatrixModification_Load(object sender, EventArgs e)
        {
            MatrixBlueprint.RowCount = currentMatrix.rows + 2;
            MatrixBlueprint.ColumnCount = currentMatrix.cols + 2;
            MatrixBlueprint.ColumnHeadersVisible = false;
            MatrixBlueprint.RowHeadersVisible = false;
            MatrixBlueprint[0, 0].ReadOnly = false;
            MatrixBlueprint[1, 1].ReadOnly = true;
            MatrixBlueprint.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            MatrixBlueprint.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MatrixBlueprint.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DisplayMatrix(currentMatrix);
        }

        private void SaveChanges_Click(object sender, EventArgs e)
        {
            if(VerifyPayofsFloat())
            {
                SaveBeforeEdit();
                lastSavedMatrix = copyMatrix(currentMatrix);
                MessageBox.Show("Model Saved");
                isSaved = true;
            }
        }

        private void SaveBeforeEdit()
        {
            for (int r = 0; r < currentMatrix.rows; r++)
            {
                for (int c = 0; c < currentMatrix.cols; c++)
                {
                    currentMatrix.payoffs[r, c] = MatrixBlueprint[c + 2, r + 2].Value.ToString();
                }
            }
            for (int c = 0; c < currentMatrix.cols; c++)
            {
                currentMatrix.ColStrategies[c] = MatrixBlueprint[c + 2, 1].Value.ToString();
            }

            for (int r = 0; r < currentMatrix.rows; r++)
            {
                currentMatrix.RowStrategies[r] = MatrixBlueprint[1, r + 2].Value.ToString();
            }
            currentMatrix.Players[0] = MatrixBlueprint[0, 2].Value.ToString();
            currentMatrix.Players[1] = MatrixBlueprint[2, 0].Value.ToString();
            currentMatrix.Name = MatrixBlueprint[0,0].Value.ToString();
        }

        public void DisplayMatrix(Models.Matrix matrix)
        {
            currentMatrix = matrix;
            MatrixBlueprint.RowCount = currentMatrix.rows + 2;
            MatrixBlueprint.ColumnCount = currentMatrix.cols + 2;

            MatrixBlueprint.ColumnHeadersVisible = false;
            MatrixBlueprint.RowHeadersVisible = false;

            MatrixBlueprint.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int r = 0; r < currentMatrix.rows; r++)
            {
                if (r > 0)
                {
                    MatrixBlueprint[0, r + 2].Value = "";
                }
                for (int c = 0; c < currentMatrix.cols; c++)
                {
                    MatrixBlueprint[c + 2, r + 2].Value = currentMatrix.payoffs[r, c];
                }
            }
            MatrixBlueprint.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            MatrixBlueprint.RowTemplate.Height = 40;
            MatrixBlueprint[0, 2].Value = currentMatrix.Players[0];
            MatrixBlueprint[2, 0].Value = currentMatrix.Players[1];
            MatrixBlueprint[0, 0].Value = currentMatrix.Name;

            for (int c = 0; c < currentMatrix.cols; c++)
            {
                MatrixBlueprint[c + 2, 1].Value = currentMatrix.ColStrategies[c];
            }



            for (int r = 0; r < currentMatrix.rows; r++)
            {
                MatrixBlueprint[1, r + 2].Value = currentMatrix.RowStrategies[r];
            }
            AccesabilityLimit();
        }

        private void AddRow_Click(object sender, EventArgs e)
        {
            SaveBeforeEdit();

            currentMatrix.rows += 1;

            string[,] temporaryPayoffs = new string[currentMatrix.rows, currentMatrix.cols];
            string[] temporaryRowStrategies = new string[currentMatrix.rows];

            for (int r = 0; r < currentMatrix.rows-1; r++)
            {
                temporaryRowStrategies[r] = currentMatrix.RowStrategies[r];
            }

            for (int r = 0; r < currentMatrix.rows-1; r++)
            {
                for (int c = 0; c < currentMatrix.cols; c++)
                {
                    temporaryPayoffs[r, c] = currentMatrix.payoffs[r, c];
                }
            }

            temporaryRowStrategies[currentMatrix.rows-1] = "New Strategy";

            for (int c = 0; c < currentMatrix.cols; c++)
            {
                temporaryPayoffs[currentMatrix.rows-1, c] = "empty payoff";
            }

            currentMatrix.RowStrategies = temporaryRowStrategies;
            currentMatrix.payoffs = temporaryPayoffs;
            DisplayMatrix(currentMatrix);
        }
        private void DeleteRow_Click(object sender, EventArgs e)
        {
            if (currentMatrix.rows <= 1)
            {
                MessageBox.Show("Cannot have fewer than 1 strategy.");
                return;
            }
            SaveBeforeEdit();
            currentMatrix.rows -= 1;
            string[,] temporaryPayoffs = new string[currentMatrix.rows, currentMatrix.cols];
            string[] temporaryRowStrategies = new string[currentMatrix.rows];
            MatrixBlueprint[0, 2].Value = currentMatrix.Players[0];
            for (int r = 0; r < currentMatrix.rows; r++)
            {
                temporaryRowStrategies[r] = currentMatrix.RowStrategies[r];
            }
            for (int r = 0; r < currentMatrix.rows; r++)
            {
                for (int c = 0; c < currentMatrix.cols; c++)
                {
                    temporaryPayoffs[r, c] = currentMatrix.payoffs[r, c];
                }
            }
            currentMatrix.RowStrategies = temporaryRowStrategies;
            currentMatrix.payoffs = temporaryPayoffs;
            DisplayMatrix(currentMatrix);
        }

        private void AddColumn_Click(object sender, EventArgs e)
        {
            SaveBeforeEdit();
            currentMatrix.cols += 1;
            string[,] temporaryPayoffs = new string[currentMatrix.rows, currentMatrix.cols];
            string[] temporaryColStrategies = new string[currentMatrix.cols];
            for (int c = 0; c < currentMatrix.cols - 1; c++)
            {
                temporaryColStrategies[c] = currentMatrix.ColStrategies[c];
            }
            for (int r = 0; r < currentMatrix.rows; r++)
            {
                for (int c = 0; c < currentMatrix.cols - 1; c++)
                {
                    temporaryPayoffs[r, c] = currentMatrix.payoffs[r, c];
                }
            }
            temporaryColStrategies[currentMatrix.cols - 1] = "New Strategy";
            for (int r = 0; r < currentMatrix.rows; r++)
            {
                temporaryPayoffs[r, currentMatrix.cols - 1] = "empty payoff";
            }
            currentMatrix.ColStrategies = temporaryColStrategies;
            currentMatrix.payoffs = temporaryPayoffs;
            DisplayMatrix(currentMatrix);
        }

        private void DeleteColumn_Click(object sender, EventArgs e)
        {
            if (currentMatrix.cols <= 1)
            {
                MessageBox.Show("Cannot have fewer than 1 strategy.");
                return;
            }

            SaveBeforeEdit();
            currentMatrix.cols -= 1;
            string[,] temporaryPayoffs = new string[currentMatrix.rows, currentMatrix.cols];
            string[] temporaryColStrategies = new string[currentMatrix.cols];
            for (int c = 0; c < currentMatrix.cols; c++)
            {
                temporaryColStrategies[c] = currentMatrix.ColStrategies[c];
            }
            for (int r = 0; r < currentMatrix.rows; r++)
            {
                for (int c = 0; c < currentMatrix.cols; c++)
                {
                    temporaryPayoffs[r, c] = currentMatrix.payoffs[r, c];
                }
            }
            currentMatrix.ColStrategies = temporaryColStrategies;
            currentMatrix.payoffs = temporaryPayoffs;
            DisplayMatrix(currentMatrix);
        }

        private Models.Matrix copyMatrix(Models.Matrix originalMatrix)
        {
            Models.Matrix updatedMatrix = new Models.Matrix();
            
            updatedMatrix.cols = originalMatrix.cols;
            updatedMatrix.rows = originalMatrix.rows;

            updatedMatrix.X = originalMatrix.X;
            updatedMatrix.Y = originalMatrix.Y;

            updatedMatrix.MatrixID = originalMatrix.MatrixID;

            updatedMatrix.payoffs = (string[,])originalMatrix.payoffs.Clone();

            updatedMatrix.Players = (string[])originalMatrix.Players.Clone();

            updatedMatrix.RowStrategies = (string[])originalMatrix.RowStrategies.Clone();

            updatedMatrix.ColStrategies = (string[])originalMatrix.ColStrategies.Clone();

            updatedMatrix.Name = originalMatrix.Name;

            return updatedMatrix;
        }

        private void CancelChanges_Click(object sender, EventArgs e)
        {
            currentMatrix = copyMatrix(lastSavedMatrix);
            DisplayMatrix(currentMatrix);
        }

        private void DeleteMatrixButton_Click(object sender, EventArgs e)
        {
            DialogResult check_beofre_delete = MessageBox.Show("Are you sure you want to delete currently selected matrix?", "Deleting Matrix",MessageBoxButtons.YesNo);
            if (check_beofre_delete == DialogResult.Yes)
            {
                deleted = true;
                MessageBox.Show("Matrix Deleted");
                Close();
            }
        }
    }   
}
