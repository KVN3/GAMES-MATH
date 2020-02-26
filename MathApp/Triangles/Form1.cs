using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangles
{
    public partial class Form1 : Form
    {
        public Pen pen = new Pen(Color.Black);

        public int count;

        public Form1()
        {
            count = 0;
            InitializeComponent();


        }

        // How to run it as a task / asynchronous without the error?

        private void DrawTriangle(Graphics graphics, Point highestPoint, int width, int height)
        {
            //graphics.DrawRectangle(new Pen(Color.Green), new Rectangle(0, 0, 40, 40));

            Point topPoint = highestPoint;
            Point bottomRightPoint = new Point((highestPoint.X - width), (highestPoint.Y + height));
            Point bottomLeftPoint = new Point((highestPoint.X + width), (highestPoint.Y + height));

            // Draw the triangle
            graphics.DrawLine(new Pen(Color.Black), topPoint, bottomRightPoint);
            graphics.DrawLine(new Pen(Color.Black), bottomRightPoint, bottomLeftPoint);
            graphics.DrawLine(new Pen(Color.Black), bottomLeftPoint, topPoint);

            // New sizes
            int newWidth = width / 2;
            int newHeight = height / 2;

            if (newWidth > 1 && newHeight > 1)
            {
                // Left
                DrawTriangle(graphics, new Point(highestPoint.X - newWidth, highestPoint.Y + newHeight), newWidth, newHeight);

                // Right
                DrawTriangle(graphics, new Point(highestPoint.X + newWidth, highestPoint.Y + newHeight), newWidth, newHeight);

                // Top
                DrawTriangle(graphics, topPoint, newWidth, newHeight);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            DrawTriangle(e.Graphics, new Point(Width / 2, 0), Width / 2 - 20, Height - 80);
        }
    }
}
