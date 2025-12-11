namespace Stochastic_Game_Theory_Calculator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ModelSelection = new System.Windows.Forms.Label();
            this.MatrixInitialise = new System.Windows.Forms.Button();
            this.tutorialButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox1.Location = new System.Drawing.Point(332, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(729, 599);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ModelSelection
            // 
            this.ModelSelection.AutoSize = true;
            this.ModelSelection.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelSelection.Location = new System.Drawing.Point(13, 102);
            this.ModelSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModelSelection.Name = "ModelSelection";
            this.ModelSelection.Size = new System.Drawing.Size(141, 22);
            this.ModelSelection.TabIndex = 2;
            this.ModelSelection.Text = "Model Selection";
            // 
            // MatrixInitialise
            // 
            this.MatrixInitialise.Location = new System.Drawing.Point(12, 137);
            this.MatrixInitialise.Name = "MatrixInitialise";
            this.MatrixInitialise.Size = new System.Drawing.Size(158, 41);
            this.MatrixInitialise.TabIndex = 3;
            this.MatrixInitialise.Text = "Normal Form";
            this.MatrixInitialise.UseVisualStyleBackColor = true;
            this.MatrixInitialise.Click += new System.EventHandler(this.MatrixInitialise_Click);
            // 
            // tutorialButton
            // 
            this.tutorialButton.Location = new System.Drawing.Point(12, 12);
            this.tutorialButton.Name = "tutorialButton";
            this.tutorialButton.Size = new System.Drawing.Size(116, 41);
            this.tutorialButton.TabIndex = 4;
            this.tutorialButton.Text = "Tutorial Video";
            this.tutorialButton.UseVisualStyleBackColor = true;
            this.tutorialButton.Click += new System.EventHandler(this.tutorialButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 621);
            this.Controls.Add(this.tutorialButton);
            this.Controls.Add(this.MatrixInitialise);
            this.Controls.Add(this.ModelSelection);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Stochastic Game Theory Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ModelSelection;
        private System.Windows.Forms.Button MatrixInitialise;
        private System.Windows.Forms.Button tutorialButton;
    }
}

