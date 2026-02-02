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
            this.zoom_to_default = new System.Windows.Forms.Button();
            this.lockalise_matricies = new System.Windows.Forms.Button();
            this.return_to_origin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.ModelSelection.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelSelection.Location = new System.Drawing.Point(25, 104);
            this.ModelSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModelSelection.Name = "ModelSelection";
            this.ModelSelection.Size = new System.Drawing.Size(135, 22);
            this.ModelSelection.TabIndex = 2;
            this.ModelSelection.Text = "Model Asembly";
            // 
            // MatrixInitialise
            // 
            this.MatrixInitialise.AutoSize = true;
            this.MatrixInitialise.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.MatrixInitialise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MatrixInitialise.Location = new System.Drawing.Point(62, 201);
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
            this.tutorialButton.Location = new System.Drawing.Point(54, 25);
            this.tutorialButton.Name = "tutorialButton";
            this.tutorialButton.Size = new System.Drawing.Size(198, 39);
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
            this.ModelSelectionPannel.Controls.Add(this.zoom_to_default);
            this.ModelSelectionPannel.Controls.Add(this.lockalise_matricies);
            this.ModelSelectionPannel.Controls.Add(this.return_to_origin);
            this.ModelSelectionPannel.Controls.Add(this.label1);
            this.ModelSelectionPannel.Controls.Add(this.solveButton);
            this.ModelSelectionPannel.Controls.Add(this.ConnectionInitialise);
            this.ModelSelectionPannel.Controls.Add(this.SimulationInitialise);
            this.ModelSelectionPannel.Controls.Add(this.ModelSelection);
            this.ModelSelectionPannel.Controls.Add(this.tutorialButton);
            this.ModelSelectionPannel.Controls.Add(this.MatrixInitialise);
            this.ModelSelectionPannel.Location = new System.Drawing.Point(12, 12);
            this.ModelSelectionPannel.Name = "ModelSelectionPannel";
            this.ModelSelectionPannel.Size = new System.Drawing.Size(338, 1059);
            this.ModelSelectionPannel.TabIndex = 5;
            // 
            // zoom_to_default
            // 
            this.zoom_to_default.Location = new System.Drawing.Point(54, 677);
            this.zoom_to_default.Name = "zoom_to_default";
            this.zoom_to_default.Size = new System.Drawing.Size(208, 53);
            this.zoom_to_default.TabIndex = 17;
            this.zoom_to_default.Text = "Default Zoom";
            this.zoom_to_default.UseVisualStyleBackColor = true;
            this.zoom_to_default.Click += new System.EventHandler(this.zoom_to_default_Click);
            // 
            // lockalise_matricies
            // 
            this.lockalise_matricies.Location = new System.Drawing.Point(54, 764);
            this.lockalise_matricies.Name = "lockalise_matricies";
            this.lockalise_matricies.Size = new System.Drawing.Size(208, 53);
            this.lockalise_matricies.TabIndex = 16;
            this.lockalise_matricies.Text = "Localise Matricies";
            this.lockalise_matricies.UseVisualStyleBackColor = true;
            this.lockalise_matricies.Click += new System.EventHandler(this.lockalise_matricies_Click);
            // 
            // return_to_origin
            // 
            this.return_to_origin.Location = new System.Drawing.Point(54, 593);
            this.return_to_origin.Name = "return_to_origin";
            this.return_to_origin.Size = new System.Drawing.Size(208, 54);
            this.return_to_origin.TabIndex = 14;
            this.return_to_origin.Text = "Return to origin";
            this.return_to_origin.UseVisualStyleBackColor = true;
            this.return_to_origin.Click += new System.EventHandler(this.return_to_origin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 524);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Canvas Coordination";
            // 
            // solveButton
            // 
            this.solveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.solveButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.solveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.solveButton.Location = new System.Drawing.Point(54, 977);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(208, 65);
            this.solveButton.TabIndex = 12;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = false;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // ConnectionInitialise
            // 
            this.ConnectionInitialise.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ConnectionInitialise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConnectionInitialise.Location = new System.Drawing.Point(62, 298);
            this.ConnectionInitialise.Name = "ConnectionInitialise";
            this.ConnectionInitialise.Size = new System.Drawing.Size(180, 48);
            this.ConnectionInitialise.TabIndex = 7;
            this.ConnectionInitialise.Text = "Connection";
            this.ConnectionInitialise.UseVisualStyleBackColor = false;
            this.ConnectionInitialise.Click += new System.EventHandler(this.ConnectionInitialise_Click);
            // 
            // SimulationInitialise
            // 
            this.SimulationInitialise.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SimulationInitialise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SimulationInitialise.Location = new System.Drawing.Point(62, 399);
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
            this.Canvas.Location = new System.Drawing.Point(356, 12);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1127, 1059);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 881);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button return_to_origin;
        private System.Windows.Forms.Button lockalise_matricies;
        private System.Windows.Forms.Button zoom_to_default;
    }
}

