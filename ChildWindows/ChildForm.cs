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

namespace ChildWindows
{
    public partial class ChildForm : Form
    {
        public enum SortType { BubbleSort, HoareSort};

        SortType st;

        const int barCount = 30;
        int[] array1 = new int[barCount];
    
       public   void BubbleSortThread()
        {
            for (int i = 0; i < array1.Length; i++)
            {
              
                for (int j = 0; j < array1.Length - i - 1; j++)
                {
                     
                    if (array1[j] > array1[j + 1])
                    {
                        int temp = array1[j];
                        array1[j] = array1[j + 1];
                        array1[j + 1] = temp;
                    }
                    Thread.Sleep(100);
                }  
                return;
            }


           
          
        }
     
       public void HoareSortThread(int[] array1,long first, long last )
       {
       
           int p =array1[(last - first) / 2 + first];
           int temp;
           long i = first, j = last;
         
           while (i <= j)
           {   
               while (array1[i] < p && i <= last) ++i;
               while (array1[j] > p && j >= first) --j;
             
               if (i <= j)
               {
                   Thread.Sleep(1);
                   temp = array1[i];
                   array1[i] = array1[j];
                   array1[j] = temp;
                   ++i; --j;
               }
           }
         
           if (j > first) HoareSortThread(array1, first, j);
           if (i < last) HoareSortThread(array1, i, last);
           
       }
       

        public ChildForm(ParentForm form, SortType st)
        {
            this.st = st;
            InitializeComponent();
            this.MdiParent = form;
            Random rand = new Random();
            for (int j = 0; j < array1.Length; j++)
                array1[j] = rand.Next(0, 100);

            if (bub)
            {

            }
        }
       

        private void ChildForm_Shown(object sender, EventArgs e)
        {
            //SeparateThread();
            Thread t = new Thread(BubbleSortThread);
            t.Start();
        }
      

       


        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        Pen b = new Pen(Color.Blue, 2);



        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {



            int h = pictureBox1.Height;
            int w = pictureBox1.Width;

            int wBar = w / barCount;

            for (int i = 0; i < barCount; i++)
            {

                int length = array1[i];
                e.Graphics.DrawRectangle(b, wBar * i, h - length, wBar / 2, length);


            }
        }
    }
}
