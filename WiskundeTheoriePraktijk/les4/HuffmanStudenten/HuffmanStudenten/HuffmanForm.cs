using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Huffman
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCodeer;
        Huffman huffman;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label input;
        private System.Windows.Forms.Label code;
        private System.Windows.Forms.Label reductie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox frequentieLijst;
        private TextBox tbx_gecodeerd;
        private Button btn_decode;
        private Label lbl_gedecodeerd;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            huffman = new Huffman();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCodeer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.input = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.Label();
            this.reductie = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.frequentieLijst = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_gecodeerd = new System.Windows.Forms.TextBox();
            this.btn_decode = new System.Windows.Forms.Button();
            this.lbl_gedecodeerd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(134, 8);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(450, 20);
            this.inputTextBox.TabIndex = 0;
            this.inputTextBox.Text = "bananen eten veel vlees";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input tekst:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonCodeer
            // 
            this.buttonCodeer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCodeer.Location = new System.Drawing.Point(8, 50);
            this.buttonCodeer.Name = "buttonCodeer";
            this.buttonCodeer.Size = new System.Drawing.Size(124, 23);
            this.buttonCodeer.TabIndex = 3;
            this.buttonCodeer.Text = "Huffman Kodering:";
            this.buttonCodeer.Click += new System.EventHandler(this.buttonCodeer_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(406, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Input lengte";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(406, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Code  lengte";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(486, 190);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(100, 23);
            this.input.TabIndex = 6;
            this.input.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(486, 214);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(100, 23);
            this.code.TabIndex = 7;
            this.code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // reductie
            // 
            this.reductie.Location = new System.Drawing.Point(486, 242);
            this.reductie.Name = "reductie";
            this.reductie.Size = new System.Drawing.Size(100, 23);
            this.reductie.TabIndex = 9;
            this.reductie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(406, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Reductie:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frequentieLijst
            // 
            this.frequentieLijst.Location = new System.Drawing.Point(596, 34);
            this.frequentieLijst.Name = "frequentieLijst";
            this.frequentieLijst.Size = new System.Drawing.Size(120, 238);
            this.frequentieLijst.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(596, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Frequentie";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_gecodeerd
            // 
            this.tbx_gecodeerd.Location = new System.Drawing.Point(134, 53);
            this.tbx_gecodeerd.Name = "tbx_gecodeerd";
            this.tbx_gecodeerd.Size = new System.Drawing.Size(450, 20);
            this.tbx_gecodeerd.TabIndex = 13;
            // 
            // btn_decode
            // 
            this.btn_decode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_decode.Location = new System.Drawing.Point(8, 105);
            this.btn_decode.Name = "btn_decode";
            this.btn_decode.Size = new System.Drawing.Size(124, 23);
            this.btn_decode.TabIndex = 14;
            this.btn_decode.Text = "Decoderen:";
            this.btn_decode.Click += new System.EventHandler(this.btn_decode_Click);
            // 
            // lbl_gedecodeerd
            // 
            this.lbl_gedecodeerd.Location = new System.Drawing.Point(138, 110);
            this.lbl_gedecodeerd.Name = "lbl_gedecodeerd";
            this.lbl_gedecodeerd.Size = new System.Drawing.Size(446, 80);
            this.lbl_gedecodeerd.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(729, 286);
            this.Controls.Add(this.lbl_gedecodeerd);
            this.Controls.Add(this.btn_decode);
            this.Controls.Add(this.tbx_gecodeerd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.frequentieLijst);
            this.Controls.Add(this.reductie);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.code);
            this.Controls.Add(this.input);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCodeer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputTextBox);
            this.Name = "Form1";
            this.Text = "Huffman codering";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        private void buttonCodeer_Click(object sender, System.EventArgs e)
        {
            frequentieLijst.Items.Clear();
            string binaireCode = huffman.Codeer(inputTextBox.Text, frequentieLijst);
            tbx_gecodeerd.Text = binaireCode;
            input.Text = "" + (8 * inputTextBox.Text.Length) + " bits";
            code.Text = tbx_gecodeerd.Text.Length.ToString() + " bits";

            if (inputTextBox.Text.Length > 0)
                reductie.Text = "" + Math.Round((double)(8.0 * inputTextBox.Text.Length - tbx_gecodeerd.Text.Length) / (8 * inputTextBox.Text.Length) * 1000) / 10 + "%";
            else
                reductie.Text = "";
        }

        private void btn_decode_Click(object sender, EventArgs e)
        {
            string binaireCode = tbx_gecodeerd.Text;
            lbl_gedecodeerd.Text = huffman.Decodeer(binaireCode);
        }
    }
}