namespace DijkstraStudent
{
  partial class DijkstraForm
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
      this.lvResults = new System.Windows.Forms.ListView();
      this.Column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.btnCalculate = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lvResults
      // 
      this.lvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column1});
      this.lvResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lvResults.FullRowSelect = true;
      this.lvResults.Location = new System.Drawing.Point(22, 22);
      this.lvResults.Name = "lvResults";
      this.lvResults.Size = new System.Drawing.Size(597, 281);
      this.lvResults.TabIndex = 1;
      this.lvResults.UseCompatibleStateImageBehavior = false;
      this.lvResults.View = System.Windows.Forms.View.Details;
      // 
      // Column1
      // 
      this.Column1.Text = "-";
      // 
      // btnCalculate
      // 
      this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCalculate.Location = new System.Drawing.Point(495, 309);
      this.btnCalculate.Name = "btnCalculate";
      this.btnCalculate.Size = new System.Drawing.Size(124, 29);
      this.btnCalculate.TabIndex = 2;
      this.btnCalculate.Text = "Calculate";
      this.btnCalculate.UseVisualStyleBackColor = true;
      this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
      // 
      // DijkstraForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(631, 350);
      this.Controls.Add(this.btnCalculate);
      this.Controls.Add(this.lvResults);
      this.Name = "DijkstraForm";
      this.Text = "Dijkstra\'s algoritme";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView lvResults;
    private System.Windows.Forms.ColumnHeader Column1;
    private System.Windows.Forms.Button btnCalculate;
  }
}

