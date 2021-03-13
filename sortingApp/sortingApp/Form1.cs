using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sortingApp
{
    public partial class Form1 : Form
    {
        public static int[] theArray;
        Graphics g;
        Brush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush greenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightGreen);
        int rectWidth = 10;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            g = panel1.CreateGraphics();
            int numOfEntries = panel1.Width / rectWidth;
            int maxValue = panel1.Height;
            theArray = new int[numOfEntries];

            //initializing panel background color
            g.FillRectangle(blackBrush, 0, 0, panel1.Width, panel1.Height);

            Random rnd = new Random();

            for(int i = 0; i < numOfEntries; i++)
            {
                //initializing random array
                theArray[i] = rnd.Next(10, maxValue);
            }
            
            for (int i = 0; i < numOfEntries; i++)
            {
                //drawing unsorted array
                g.FillRectangle(whiteBrush, i*rectWidth, maxValue - theArray[i], rectWidth,maxValue);
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            int listLenght = theArray.Count();
            int k = 0;
            
            for (int i = 0; i < listLenght - 1; i++)
            {
                for (k = 0; k < listLenght - 1 - i; k++)
                {
                    if (theArray[k] > theArray[k + 1])
                    {
                        Swap(k, k + 1);
                    }
                }
                //makes rectangle green
                g.FillRectangle(blackBrush, k * rectWidth, 0, rectWidth, panel1.Height);
                g.FillRectangle(greenBrush, k * rectWidth, panel1.Height - theArray[k], rectWidth, panel1.Height);
            }
            //makes last rectangle green
            g.FillRectangle(blackBrush, 0, 0, rectWidth, panel1.Height);
            g.FillRectangle(greenBrush, 0, panel1.Height - theArray[0], rectWidth, panel1.Height);
        }

        private void Swap(int k, int v)
        {
            int temp;
            int maxVal = panel1.Height;

            temp = theArray[k];
            theArray[k] = theArray[v];
            theArray[v] = temp;
            //deletes rectangles that is swaping 
            g.FillRectangle(blackBrush, k * rectWidth, 0, rectWidth, maxVal );
            g.FillRectangle(blackBrush, v * rectWidth, 0, rectWidth, maxVal);
            //draws rectangles that is swapinn
            g.FillRectangle(whiteBrush, k * rectWidth, maxVal - theArray[k], rectWidth, maxVal);
            g.FillRectangle(whiteBrush, v * rectWidth, maxVal - theArray[v],rectWidth , maxVal);

            Thread.Sleep(10);
        }
    }
}
