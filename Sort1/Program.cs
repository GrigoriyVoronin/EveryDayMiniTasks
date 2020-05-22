using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Sort1
{
    //public class Point
    //{
    //     public int X;
    //     public int Y;
    //     public Point (int x,int y)
    //    {
    //       X = x;
    //       Y = y;
    //    }
    //}

    class Program
    {
        static void Main()
        {
            //var n = int.Parse(Console.ReadLine());
            var n = 9;
            var arr = new Point[n];
            //for(int i =0; i<n;i++)
            //{
            //    arr[i] = new Point(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            //}
            arr[0] = new Point(-1, 1);
            arr[1] = new Point(-1, -1);
            arr[2] = new Point(1, 1);
            arr[3] = new Point(2, -1);
            arr[4] = new Point(3, -1);
            arr[5] = new Point(-2, -2);
            arr[6] = new Point(-5, 3);
            arr[7] = new Point(-0, 4);
            arr[8] = new Point(4, 3);
            var arrX = new Dictionary<int,int> (n);
            var bufferArr = new Point[n];
            for(int i=0; i<n;i++)
            {
                arrX[i] = arr[i].X;
            }
            bufferArr = arrX.OrderBy(x => x.Value).Select(x=>arr[x.Key]).ToArray();
            var number = 1;
            for (int i = 1; i < n; i++)
            {
                if(bufferArr[i]==bufferArr[i-1])
                {
                    number++;
                }
                else
                {
                    var bufferArr1 = new Dictionary<int, int>(number);
                    for (int j = 0; j < number; j++)
                    {
                        bufferArr1[j] = bufferArr[i].Y;
                    }
                    bufferArr1.OrderBy(x => x.Value).Select(x => bufferArr[x.Key]).ToArray().CopyTo(arr, i - number);
                }
            }
            var form = new Form1();
            Application.Run(form);
            form.ClientSize = new Size(800, 600);
            form.Paint += (sender, ev) => Paint((Form)sender, ev,arr);
        }
        private static void Paint(Form sender,PaintEventArgs e, Point[] arr)
        {

            var graphics = e.Graphics;
            var grahPen = new Pen(Color.Red);
            graphics.DrawLines(grahPen, arr);
        }
    }
}
