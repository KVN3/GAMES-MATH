using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Mazes {  

	public class MazeForm : System.Windows.Forms.Form {

		#region attributes
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private IContainer components;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxH;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.TextBox textBoxW;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxR;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxC;

		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private Maze maze;
		private System.Windows.Forms.Label label5;
		private MazeFilter mazeFilter;
        #endregion

		public MazeForm() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			mazeFilter = new MazeFilter( );
			maze = new Maze(1,1);//draw results in pictureBox2, starting at position 1,1
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxW = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxC = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "File";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(458, 304);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // textBoxH
            // 
            this.textBoxH.Location = new System.Drawing.Point(200, 20);
            this.textBoxH.Name = "textBoxH";
            this.textBoxH.Size = new System.Drawing.Size(38, 26);
            this.textBoxH.TabIndex = 1;
            this.textBoxH.Text = "20";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Columns";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(136, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rows";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxW
            // 
            this.textBoxW.Location = new System.Drawing.Point(80, 20);
            this.textBoxW.Name = "textBoxW";
            this.textBoxW.Size = new System.Drawing.Size(40, 26);
            this.textBoxW.TabIndex = 3;
            this.textBoxW.Text = "40";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(6, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(458, 304);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxW);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxH);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 48);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maze dimensions";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(778, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Solve";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxR);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxC);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(504, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 48);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Maze entry";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Row";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxR
            // 
            this.textBoxR.Location = new System.Drawing.Point(80, 20);
            this.textBoxR.Name = "textBoxR";
            this.textBoxR.Size = new System.Drawing.Size(32, 26);
            this.textBoxR.TabIndex = 3;
            this.textBoxR.Text = "0";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(136, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Column";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxC
            // 
            this.textBoxC.Location = new System.Drawing.Point(200, 20);
            this.textBoxC.Name = "textBoxC";
            this.textBoxC.Size = new System.Drawing.Size(28, 26);
            this.textBoxC.TabIndex = 1;
            this.textBoxC.Text = "0";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(282, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 38);
            this.button2.TabIndex = 9;
            this.button2.Text = "Create Maze";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Location = new System.Drawing.Point(8, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(472, 328);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Location = new System.Drawing.Point(504, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(472, 328);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 404);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(470, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Click maze defining cell (smallest boarders)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MazeForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1004, 445);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Menu = this.mainMenu1;
            this.Name = "MazeForm";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region actions

		private void menuItem1_Click(object sender, System.EventArgs e) {
			OpenFileDialog filechooser = new OpenFileDialog( );
			filechooser.InitialDirectory= Application.StartupPath;
			if( filechooser.ShowDialog( ) == DialogResult.OK ) {
				this.pictureBox1.Image=new Bitmap(filechooser.FileName);
				this.mazeFilter.Image= new Bitmap(this.pictureBox1.Image);
				this.pictureBox1.Image = mazeFilter.Image;
				this.pictureBox1.Width = this.pictureBox1.Image.Width+4;
				this.pictureBox1.Height = this.pictureBox1.Image.Height+4;
				pictureBox2.Height =pictureBox1.Height;
				pictureBox2.Width = pictureBox1.Width;
				this.Invalidate( );
                button2.Enabled = true;
			}		
		}
		private void button1_Click(object sender, System.EventArgs e) {
			int r=1;
			int c=1;
			try{
				r = Int32.Parse(textBoxR.Text);
				c = Int32.Parse(textBoxC.Text);
			}
			catch{}
			maze.Solve(r,c);
			maze.paint(pictureBox2.CreateGraphics());
			this.Invalidate( );
		}
		private void button2_Click(object sender, System.EventArgs e) {
            button1.Enabled =true;
			int w = 1;
			int h = 1;
			int r = 1;
			int c = 1;
			try{
				w = Int32.Parse(textBoxW.Text);
				h = Int32.Parse(textBoxH.Text);
				r = Int32.Parse(textBoxR.Text);
				c = Int32.Parse(textBoxC.Text);
			}
			catch{}

			maze.IntMatrix = mazeFilter.createMaze(h,w);

			maze.SquareSizeH = h;
			maze.SquareSizeW = w;
			maze.SquareDrawSize = (pictureBox1.Width-4) / w ;
			if ((pictureBox1.Height-4)/h < (pictureBox1.Width-4)/w)
				maze.SquareDrawSize = (pictureBox1.Height-4)/h;
			maze.paint(pictureBox2.CreateGraphics());
			this.Invalidate( );				
		}
		private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
			int x=e.X;
			int y=e.Y;
			maze.SquareDrawSize=mazeFilter.predictWidth(x,y);
			textBoxW.Text =""+(pictureBox1.Width-4)/maze.SquareDrawSize;
			textBoxH.Text =""+(pictureBox1.Height-4)/maze.SquareDrawSize;
		}
		private void pictureBox2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
			int x=e.X/maze.SquareDrawSize;
			textBoxC.Text = x.ToString();
			int y=e.Y/maze.SquareDrawSize;
			textBoxR.Text = y.ToString();
		}
		#endregion

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
			maze.paint(pictureBox2.CreateGraphics());
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.Run(new MazeForm());
		}



	}
}
