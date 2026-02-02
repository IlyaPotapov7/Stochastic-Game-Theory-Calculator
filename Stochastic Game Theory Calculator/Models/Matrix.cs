using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Stochastic_Game_Theory_Calculator;

namespace Stochastic_Game_Theory_Calculator.Models
{
    public class Matrix
    {
        //define all variables
        private int rows;
        private int cols;
        private string[,] payoffs;
        private string[] rowStrategies;
        private string[] colStrategies;
        private string name;
        private Stack<Matrix> versionsStack;
        private string[] players;
        private int matrixID;
        private float x; //150
        private float y; //80
        private RectangleF hitbox;

        public Matrix(int Rows, int Cols, string[,] Payoffs, string[] RowStrategies, string[] ColStrategies, string Name, Stack<Matrix> VersionsStack, string[] Players, int MatrixID,float X, float Y, RectangleF Hitbox)
        {
            rows = Rows;
            cols = Cols;
            payoffs = Payoffs;
            rowStrategies = RowStrategies;
            colStrategies = ColStrategies;
            name = Name;
            versionsStack = VersionsStack;
            players = Players;
            y = Y;
            x = X;
            hitbox = Hitbox;
        }

        public Matrix()
        {
            //default constructor that allows the program to go to the default matrix
        }
        public int GetRows()
        {
            return rows;
        }

        public void SetRows(int Rows)
        {
            rows = Rows;
        }

        public void ChangeRows(int Rows)
        {
            rows += Rows;
        }

        public int GetCols()
        {
            return cols;
        }

        public void SetCols(int Cols)
        {
            cols = Cols;
        }

        public void ChangeCols(int Cols)
        {
            rows += Cols;
        }

        public string[,] GetPayoffs()
        {
            return payoffs;
        }

        public string GetOnePayoff(int row, int col)
        {
            return payoffs[row, col]; 
        }

        public void SetPayoffs(string[,] newPayoff)
        {
            payoffs = newPayoff;
        }

        public void SetOnePayoff(int Row, int Col, string newPayoff)
        {
            payoffs[Row, Col] = newPayoff;
        }

        public string[] GetRowStrategies()
        {
            return rowStrategies;
        }

        public string GetOneRowStrategy(int index)
        {
            return rowStrategies[index];
        }

        public void SetRowStrategies(string[] strategy)
        {
            rowStrategies = strategy;
        }

        public void SetOneRowStrategy(int index, string strategy)
        {
            rowStrategies[index] = strategy;
        }

        public string[] GetColStrategies()
        {
            return colStrategies;
        }

        public string GetOneColStrategy(int index)
        {
            return colStrategies[index];
        }
        public void SetColStrategies(string[] strategy)
        {
            colStrategies = strategy;
        }

        public void SetOneColStrategy(int index, string strategy)
        {
            colStrategies[index] = strategy;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string Name)
        {
            name = Name;
        }
        public Stack<Matrix> GetVersionStack()
        {
            return versionsStack;
        }

        public void SetVersionStack(Stack<Matrix> Stack)
        {
            versionsStack = Stack;
        }

        public void PushVersionStack(Matrix pushedMatrix)
        {
            versionsStack.Push(pushedMatrix); 
        }

        public Matrix PopVersionStack()
        {
            return versionsStack.Pop(); 
        }

        public string[] GetPlayers()
        {
            return players;
        }

        public string GetOnePlayer(int index)
        {
            return players[index];
        }

        public void SetPlayers(string[] Players)
        {
            players = Players;
        }

        public void SetOnePlayer(int index, string Player)
        {
            players[index] = Player;
        }

        public int GetMatrixID()
        {
            return matrixID;
        }

        public void SetMatrixID(int MatrixID)
        {
            matrixID = MatrixID;
        }
        public float GetX()
        {
            return x;
        }

        public void SetX(float X)
        {
            x = X;
        }

        public void ChangeX(float X)
        {
            x += X;
        }

        public float GetY()
        {
            return y;
        }

        public void SetY(float Y)
        {
            y = Y;
        }

        public void ChangeY(float Y)
        {
            y =+ Y;
        }
        public RectangleF GetHitbox()
        {
            return hitbox;
        }

        public void SetHitbox(RectangleF Hitbox)
        {
            hitbox = Hitbox;
        }
        public Matrix defaultMatrix()
        {
            string[,] defaultPayoffs = { { "3:3", "0:4" }, { "4:0", "2:2" } };
            string[] defaultRowStrategies = { "Cooperate", "Defect" };
            string[] defaultColStrategies = { "Cooperate", "Defect" };
            string[] defaultPlayers = { "Player 1", "Player 2" };
            string defaultName = "Default Name";
            Stack<Matrix> defaultStack = new Stack<Matrix>();
            RectangleF defaultRectangle = new RectangleF();
            Matrix defaultMatrix = new Matrix(2, 2, defaultPayoffs, defaultRowStrategies, defaultColStrategies, defaultName, defaultStack, defaultPlayers, -1, 150, 80, defaultRectangle);
            return defaultMatrix;
        }
    }
}
