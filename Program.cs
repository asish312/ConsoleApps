using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{
    class Program
    {
        public Program()
        {
            Console.WriteLine("This is Default Parent Constructor has called in Program");
        }

        public void Method1()
        {
            Console.WriteLine("This is Default Parent Method has called in Program");
        }
    }
    class ChildProgram : Program
    {
        public ChildProgram()
        {
            Console.WriteLine("This is Child Constructor has called in Program");
        }

        //public override void Method1()
        //{
        //    Console.WriteLine("This is Child Method has called in Program");
        //}
        static void Main(string[] args)
        {
            //ChildProgram C = new ChildProgram();
            //C.Method1();


            //Program P = new Program();
            //P.Method1();

            //Program C = new ChildProgram();
            //C.Method1();

            //ChildProgram C = new ChildProgram();
            //Program P=C;
            //P.Method1();    //Default Parent Method


            //Program C = new Program();
            //ChildProgram P =(ChildProgram) C;    //run time error
            //P.Method1(); 

            //Program C = new ChildProgram();
            //C.Method1();

            ChildProgram C = new ChildProgram();
            C.Method1();

            Console.ReadLine();

        }
    }
}
