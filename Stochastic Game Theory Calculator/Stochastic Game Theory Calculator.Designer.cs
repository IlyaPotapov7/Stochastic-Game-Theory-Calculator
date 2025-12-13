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
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ConnectionInitialise = new System.Windows.Forms.Button();
            this.SimulationInitialise = new System.Windows.Forms.Button();
            this.GaphInitialise = new System.Windows.Forms.Button();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.ModelSelectionPannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // ModelSelection
            // 
            this.ModelSelection.AutoSize = true;
            this.ModelSelection.Font = new System.Drawing.Font("Times New Roman", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelSelection.Location = new System.Drawing.Point(16, 67);
            this.ModelSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModelSelection.Name = "ModelSelection";
            this.ModelSelection.Size = new System.Drawing.Size(211, 32);
            this.ModelSelection.TabIndex = 2;
            this.ModelSelection.Text = "Model Selection";
            // 
            // MatrixInitialise
            // 
            this.MatrixInitialise.Location = new System.Drawing.Point(12, 123);
            this.MatrixInitialise.Name = "MatrixInitialise";
            this.MatrixInitialise.Size = new System.Drawing.Size(101, 39);
            this.MatrixInitialise.TabIndex = 3;
            this.MatrixInitialise.Text = "Normal";
            this.MatrixInitialise.UseVisualStyleBackColor = true;
            this.MatrixInitialise.Click += new System.EventHandler(this.MatrixInitialise_Click);
            // 
            // tutorialButton
            // 
            this.tutorialButton.Location = new System.Drawing.Point(11, 18);
            this.tutorialButton.Name = "tutorialButton";
            this.tutorialButton.Size = new System.Drawing.Size(102, 35);
            this.tutorialButton.TabIndex = 4;
            this.tutorialButton.Text = "Tutorial Video";
            this.tutorialButton.UseVisualStyleBackColor = true;
            this.tutorialButton.Click += new System.EventHandler(this.tutorialButton_Click);
            // 
            // ModelSelectionPannel
            // 
            this.ModelSelectionPannel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ModelSelectionPannel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ModelSelectionPannel.Controls.Add(this.solveButton);
            this.ModelSelectionPannel.Controls.Add(this.pictureBox4);
            this.ModelSelectionPannel.Controls.Add(this.pictureBox3);
            this.ModelSelectionPannel.Controls.Add(this.pictureBox2);
            this.ModelSelectionPannel.Controls.Add(this.pictureBox1);
            this.ModelSelectionPannel.Controls.Add(this.ConnectionInitialise);
            this.ModelSelectionPannel.Controls.Add(this.SimulationInitialise);
            this.ModelSelectionPannel.Controls.Add(this.GaphInitialise);
            this.ModelSelectionPannel.Controls.Add(this.ModelSelection);
            this.ModelSelectionPannel.Controls.Add(this.tutorialButton);
            this.ModelSelectionPannel.Controls.Add(this.MatrixInitialise);
            this.ModelSelectionPannel.Location = new System.Drawing.Point(12, 12);
            this.ModelSelectionPannel.Name = "ModelSelectionPannel";
            this.ModelSelectionPannel.Size = new System.Drawing.Size(246, 642);
            this.ModelSelectionPannel.TabIndex = 5;
            // 
            // solveButton
            // 
            this.solveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.solveButton.Location = new System.Drawing.Point(53, 560);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(125, 65);
            this.solveButton.TabIndex = 12;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(153, 358);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(60, 57);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(145, 280);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(82, 61);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(145, 188);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(67, 67);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(129, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // ConnectionInitialise
            // 
            this.ConnectionInitialise.Location = new System.Drawing.Point(11, 367);
            this.ConnectionInitialise.Name = "ConnectionInitialise";
            this.ConnectionInitialise.Size = new System.Drawing.Size(136, 39);
            this.ConnectionInitialise.TabIndex = 7;
            this.ConnectionInitialise.Text = "Connection";
            this.ConnectionInitialise.UseVisualStyleBackColor = true;
            // 
            // SimulationInitialise
            // 
            this.SimulationInitialise.Location = new System.Drawing.Point(11, 289);
            this.SimulationInitialise.Name = "SimulationInitialise";
            this.SimulationInitialise.Size = new System.Drawing.Size(128, 39);
            this.SimulationInitialise.TabIndex = 6;
            this.SimulationInitialise.Text = "Stochasitc";
            this.SimulationInitialise.UseVisualStyleBackColor = true;
            // 
            // GaphInitialise
            // 
            this.GaphInitialise.Location = new System.Drawing.Point(11, 207);
            this.GaphInitialise.Name = "GaphInitialise";
            this.GaphInitialise.Size = new System.Drawing.Size(121, 39);
            this.GaphInitialise.TabIndex = 5;
            this.GaphInitialise.Text = "Extensive";
            this.GaphInitialise.UseVisualStyleBackColor = true;
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.SystemColors.Info;
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1016, 666);
            this.Canvas.TabIndex = 6;
            this.Canvas.TabStop = false;
            this.Canvas.Click += new System.EventHandler(this.Canvas_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 666);
            this.Controls.Add(this.ModelSelectionPannel);
            this.Controls.Add(this.Canvas);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button GaphInitialise;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

