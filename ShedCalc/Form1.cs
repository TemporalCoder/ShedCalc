using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShedCalc
{
    public partial class Form1 : Form
    {

        //global variables - could/Should save in a settings file
        int brickLength = 0; //declare and initialise
        int brickWidth = 0;
        int brickHeight = 0;
        float brickCost = 0;

        int blockLength = 0;
        int blockWidth = 0;
        int blockHeight = 0;
        float blockCost = 0; 

        public Form1()
        {
            InitializeComponent();
            //should load from a settings file
            //https://www.designingbuildings.co.uk/wiki/Brick_sizes
            /*The standard co-ordinating size for brickwork is 225 mm x 112.5 mm x 75 mm 
                * (length x depth x height). This includes 10 mm mortar joints, and so 
                * the standard size for a brick itself is 215 mm x 102.5 mm x 65 mm (length x depth x height).
            */

            brickHeight = 255;
            brickLength = 112; //lost 0.5mm
            brickWidth = 5;
            brickCost = 0.58f; //current price! 06/05/2022 wicks engineering bricks

            blockLength = 450; //includes 10mm of mortar
            blockWidth = 110;
            blockHeight = 225;
            blockCost = 2.00f;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //declare and init variables
            int shedLength = 0;
            int shedWidth = 0;
            int shedHeight = 0;

            int side1 = 0;
            int side2 = 0;
            int totalNumOfBricks=0;
            float estimatedCost=0;

            //get inputs
            shedLength = int.Parse(textBox1.Text);
            shedWidth = int.Parse(textBox2.Text);
            shedHeight = int.Parse(textBox3.Text);

            //process
            if (comboBox1.Text == "Red Brick")
            {
                side1 = shedLength / brickLength * shedHeight / brickHeight;
                side2 = shedWidth / brickLength * shedHeight / brickHeight;

                totalNumOfBricks = side1 + side2 + side1 + side2;
                estimatedCost = totalNumOfBricks * brickCost;
            }
            if (comboBox1.Text == "Standard Dense Block")
            {
                side1 = shedLength / blockLength * shedHeight / blockHeight;
                side2 = shedWidth / blockLength * shedHeight / blockHeight;

                totalNumOfBricks = side1 + side2 + side1 + side2;
                estimatedCost = totalNumOfBricks * blockCost;
            }
            //ouput
            textBox4.Text = "QUOTE: " + comboBox1.Text;
            textBox4.AppendText("\r\nSide: " + side1 +" bricks");
            textBox4.AppendText("\r\nFront/Rear: " + side2 + " bricks");
            textBox4.AppendText("\r\nNumber of Bricks: " + totalNumOfBricks);
            textBox4.AppendText("\r\nEstimatedCost £" + estimatedCost.ToString("0.00"));

        }
    }
}

