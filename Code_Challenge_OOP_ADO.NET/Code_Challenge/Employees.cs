using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge
{

    public abstract class Employee
    {
        public int Id;
        public string Fname;
        public DateTime Hire_Date;
        public string Lname;
        public int Salary;

       

        public void display()
        {
            Console.WriteLine("Id:" + Id);
            Console.WriteLine("Firstname:" + Fname);
            Console.WriteLine("HireDate:" + Hire_Date);
            Console.WriteLine("lastName:" + Lname);
            Console.WriteLine("Salary:" + Salary);
        }


    }

        public class Salesman : Employee
        {
            public decimal Commission_pct;
            public int Targett;
            public string Zone;

         
            public void Display()
            {
                base.display();
                Console.WriteLine("Commission_Percent:" + Commission_pct);
                Console.WriteLine("Target:" + Targett);
                Console.WriteLine("Zone:" + Zone);

            }

            
        }

        public class Manager : Employee
        {
            public string Curr_Project;
            public int No_of_Resources;

          
            public void Display()
            {
                base.display();
                Console.WriteLine("Current_Project:" + Curr_Project);
                Console.WriteLine("No of Resources:" + No_of_Resources);
            }

           
        }
}

