namespace MarkovChain
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
      this.btnStap = new System.Windows.Forms.Button();
      this.btnStart = new System.Windows.Forms.Button();
      this.lblNrOfMoves = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnStap
      // 
      this.btnStap.Location = new System.Drawing.Point(50, 530);
      this.btnStap.Name = "btnStap";
      this.btnStap.Size = new System.Drawing.Size(75, 23);
      this.btnStap.TabIndex = 0;
      this.btnStap.Text = "Stap";
      this.btnStap.UseVisualStyleBackColor = true;
      this.btnStap.Click += new System.EventHandler(this.btnStap_Click);
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(131, 530);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(75, 23);
      this.btnStart.TabIndex = 0;
      this.btnStart.Text = "Start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // lblNrOfMoves
      // 
      this.lblNrOfMoves.AutoSize = true;
      this.lblNrOfMoves.Location = new System.Drawing.Point(227, 539);
      this.lblNrOfMoves.Name = "lblNrOfMoves";
      this.lblNrOfMoves.Size = new System.Drawing.Size(16, 13);
      this.lblNrOfMoves.TabIndex = 1;
      this.lblNrOfMoves.Text = "...";
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(601, 570);
      this.Controls.Add(this.lblNrOfMoves);
      this.Controls.Add(this.btnStart);
      this.Controls.Add(this.btnStap);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form2";
      this.Text = "Chutes And Ladders";
      this.Load += new System.EventHandler(this.Form2_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStap;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblNrOfMoves;
    }
}