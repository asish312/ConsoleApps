using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{
    class MyConstructorClass
    {
        static double piStatic = 3.147; // D-Obj for Initialisation and Execution
        double piInstance = 3.147; //Req Obj of a class for Initialisation and Execution 

        const double piConstant = 300000;     // D-Obj for Ini & Exec.Value Can't be modified once declaration  ,Single Copy of a wole class
        readonly double piReadOnly = 3.147; //D-Obj of  a class for Ini & Exec. Value can't be modified once Initialisation //Single copy of each object of a class


        static void Main()
        {

            MyConstructorClass obj;         //Obj is a VARIABLE of a Class
                                            //obj=new MyConstructorClass(10); // Obj is a OBJECT of a Class
                                            // obj.display();   //Default Const
                                            //displayS(); //Static method




            // Ref: Two way i.e Caller to Called M & Changes in Called will be effected in the caller
            //int i = 0;
            //Console.WriteLine("Previous value of integer i:" + i.ToString());
            //string test = GetNextName(ref i);
            //Console.WriteLine("Test Value=" + test);
            //Console.WriteLine("Current value of integer i:" + i.ToString());


            //Out: Changes from Called M to Caller only Uses: When retuning multiple value from a method
            //int i = 05;
            //Console.WriteLine("Previous value of integer i:" + i.ToString());
            //string test = GetNextNameByOut(out i);
            //Console.WriteLine("Test Value=" + test);
            //Console.WriteLine("Current value of integer i:" + i.ToString());



            Console.ReadLine();
        }
        public static string GetNextNameByOut(out int id)
        {
            id = 1;
            string returnText = "Next-" + id.ToString();
            return returnText;
        }
        public static string GetNextName(ref int id)
        {
            string returnText = "Next-" + id.ToString();
            id += 1;
            return returnText;
        }

        //Param Constructor
        public MyConstructorClass(int x)
        {
            Console.WriteLine("\n Param Constructor has called,x Value= " + x);
        }

        //Required Object of a class to INITIALISE & EXECUTE
        public void display()
        {
            Console.WriteLine("Display method called");
        }
        public static void displayS()
        {
            Console.WriteLine("Display Static method called");
        }
    }
}
