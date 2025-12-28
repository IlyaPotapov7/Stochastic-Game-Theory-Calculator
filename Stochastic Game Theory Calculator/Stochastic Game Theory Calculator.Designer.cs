namespace Stochastic_Game_Theory_Calculator
{
    partial class mainWindow
    {

        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.ModelSelection = new System.Windows.Forms.Label();
            this.MatrixInitialise = new System.Windows.Forms.Button();
            this.tutorialButton = new System.Windows.Forms.Button();
            this.ModelSelectionPannel = new System.Windows.Forms.Panel();
            this.solveButton = new System.Windows.Forms.Button();
            this.ConnectionInitialise = new System.Windows.Forms.Button();
            this.SimulationInitialise = new System.Windows.Forms.Button();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.ModelSelectionPannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // ModelSelection
            // 
            this.ModelSelection.AutoSize = true;
            this.ModelSelection.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelSelection.Location = new System.Drawing.Point(17, 31);
            this.ModelSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModelSelection.Name = "ModelSelection";
            this.ModelSelection.Size = new System.Drawing.Size(204, 32);
            this.ModelSelection.TabIndex = 2;
            this.ModelSelection.Text = "Model Selection";
            // 
            // MatrixInitialise
            // 
            this.MatrixInitialise.AutoSize = true;
            this.MatrixInitialise.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.MatrixInitialise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MatrixInitialise.Location = new System.Drawing.Point(31, 128);
            this.MatrixInitialise.Name = "MatrixInitialise";
            this.MatrixInitialise.Size = new System.Drawing.Size(172, 49);
            this.MatrixInitialise.TabIndex = 3;
            this.MatrixInitialise.Text = "New Matrix";
            this.MatrixInitialise.UseVisualStyleBackColor = false;
            this.MatrixInitialise.Click += new System.EventHandler(this.MatrixInitialise_Click);
            // 
            // tutorialButton
            // 
            this.tutorialButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tutorialButton.Location = new System.Drawing.Point(54, 507);
            this.tutorialButton.Name = "tutorialButton";
            this.tutorialButton.Size = new System.Drawing.Size(126, 39);
            this.tutorialButton.TabIndex = 4;
            this.tutorialButton.Text = "Tutorial Video";
            this.tutorialButton.UseVisualStyleBackColor = true;
            this.tutorialButton.Click += new System.EventHandler(this.tutorialButton_Click);
            // 
            // ModelSelectionPannel
            // 
            this.ModelSelectionPannel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ModelSelectionPannel.AutoScrollMargin = new System.Drawing.Size(50, 60);
            this.ModelSelectionPannel.BackColor = System.Drawing.SystemColors.Window;
            this.ModelSelectionPannel.Controls.Add(this.solveButton);
            this.ModelSelectionPannel.Controls.Add(this.ConnectionInitialise);
            this.ModelSelectionPannel.Controls.Add(this.SimulationInitialise);
            this.ModelSelectionPannel.Controls.Add(this.ModelSelection);
            this.ModelSelectionPannel.Controls.Add(this.tutorialButton);
            this.ModelSelectionPannel.Controls.Add(this.MatrixInitialise);
            this.ModelSelectionPannel.Location = new System.Drawing.Point(12, 12);
            this.ModelSelectionPannel.Name = "ModelSelectionPannel";
            this.ModelSelectionPannel.Size = new System.Drawing.Size(246, 925);
            this.ModelSelectionPannel.TabIndex = 5;
            // 
            // solveButton
            // 
            this.solveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.solveButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.solveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.solveButton.Location = new System.Drawing.Point(23, 847);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(193, 54);
            this.solveButton.TabIndex = 12;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = false;
            // 
            // ConnectionInitialise
            // 
            this.ConnectionInitialise.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ConnectionInitialise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConnectionInitialise.Location = new System.Drawing.Point(31, 260);
            this.ConnectionInitialise.Name = "ConnectionInitialise";
            this.ConnectionInitialise.Size = new System.Drawing.Size(180, 48);
            this.ConnectionInitialise.TabIndex = 7;
            this.ConnectionInitialise.Text = "Connection";
            this.ConnectionInitialise.UseVisualStyleBackColor = false;
            // 
            // SimulationInitialise
            // 
            this.SimulationInitialise.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SimulationInitialise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SimulationInitialise.Location = new System.Drawing.Point(31, 389);
            this.SimulationInitialise.Name = "SimulationInitialise";
            this.SimulationInitialise.Size = new System.Drawing.Size(172, 49);
            this.SimulationInitialise.TabIndex = 6;
            this.SimulationInitialise.Text = "Stochastic";
            this.SimulationInitialise.UseVisualStyleBackColor = false;
            this.SimulationInitialise.Click += new System.EventHandler(this.SimulationInitialise_Click);
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Canvas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Canvas.Location = new System.Drawing.Point(264, 12);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(982, 925);
            this.Canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Canvas.TabIndex = 6;
            this.Canvas.TabStop = false;
            this.Canvas.Click += new System.EventHandler(this.Canvas_Click);
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 949);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.ModelSelectionPannel);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "mainWindow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stochastic Game Theory Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ModelSelectionPannel.ResumeLayout(false);
            this.ModelSelectionPannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label ModelSelection;
        private System.Windows.Forms.Button MatrixInitialise;
        private System.Windows.Forms.Button tutorialButton;
        private System.Windows.Forms.Panel ModelSelectionPannel;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Button ConnectionInitialise;
        private System.Windows.Forms.Button SimulationInitialise;
        private System.Windows.Forms.Button solveButton;
    }
}

