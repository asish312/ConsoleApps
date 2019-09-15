using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{
    public delegate void DelRecPer(double h, double w);
    public delegate void DelRecArea(double h, double w);
    class MultiCastDelegate
    {
        public void RecPer(double h, double w)
        {
            Console.WriteLine("Rectangle Perimeter={0}",2*(h+w));
        }
        public void RecArea(double h,double w)
        {
            Console.WriteLine("Rectangle Area={0}", h*w);
        }

        static void Main(string[] arg)
        {
            MultiCastDelegate obj = new MultiCastDelegate();
            //  obj.RecArea(2, 3);
            // obj.RecPer(2, 3);
            //DelRecPer objDel = new DelRecPer(obj.RecPer);

            DelRecPer objDel = obj.RecPer;

            //Multicast delegate
            objDel += obj.RecArea;

            objDel.Invoke(2, 3);

            objDel.Invoke(3, 2);

            Console.ReadLine();

        }
    }
}
