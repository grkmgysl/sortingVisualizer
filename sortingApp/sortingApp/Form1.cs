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
        public static int[] theArray; //initializing public array
        Graphics g;
        Brush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush greenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightGreen);
        int rectWidth = 10; // rectangle width
        

        public Form1()
        {
            InitializeComponent();
        }
        //random array generator
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

        private void bubbleSort(int[] lst, int lstlenght)
        {
            
            int k = 0;

            for (int i = 0; i < lstlenght - 1; i++)
            {
                for (k = 0; k < lstlenght - 1 - i; k++)
                {
                    if (theArray[k] > theArray[k + 1])
                    {
                        bubleSwap(k, k + 1);
                    }
                }
                //makes sorted rectangle green
                g.FillRectangle(blackBrush, k * rectWidth, 0, rectWidth, panel1.Height);
                g.FillRectangle(greenBrush, k * rectWidth, panel1.Height - lst[k], rectWidth, panel1.Height);
            }
            //makes last rectangle green
            g.FillRectangle(blackBrush, 0, 0, rectWidth, panel1.Height);
            g.FillRectangle(greenBrush, 0, panel1.Height - lst[0], rectWidth, panel1.Height);

        }

        private void selectionSort(int[] lst, int lstlength)
        {
            for (int i=0; i < lstlength - 1; i++)
            {
                int smallestNum = lst[lstlength - 1];
                int indx = lstlength - 1;
                for(int j = i; j < lstlength - 1; j++)
                {
                    if (lst[j] < smallestNum)
                    {
                        smallestNum = lst[j];
                        indx = j;
                        Thread.Sleep(10);
                    }
                }
                lst[indx] = lst[i];
                lst[i] = smallestNum;
                //makes sorted rectangle green
                g.FillRectangle(blackBrush, i * rectWidth, 0, rectWidth, panel1.Height);
                g.FillRectangle(greenBrush, i * rectWidth, panel1.Height - lst[i], rectWidth, panel1.Height);
                if (i != indx)
                {
                    //makes changed recangle white
                    g.FillRectangle(blackBrush, indx * rectWidth, 0, rectWidth, panel1.Height);
                    g.FillRectangle(whiteBrush, indx * rectWidth, panel1.Height - lst[indx], rectWidth, panel1.Height);
                }
            }
            //makes last rectangle green
            g.FillRectangle(blackBrush, (lstlength - 1) * rectWidth, 0, rectWidth, panel1.Height);
            g.FillRectangle(greenBrush, (lstlength - 1) * rectWidth, panel1.Height - lst[lstlength-1], rectWidth, panel1.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int listLenght = theArray.Count();
            bubbleSort(theArray, listLenght);
            
        }

        private void bubleSwap(int k, int v)
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

        private void button3_Click(object sender, EventArgs e)
        {
            int listLenght = theArray.Count();
            selectionSort(theArray, listLenght);
        }
    }
}
