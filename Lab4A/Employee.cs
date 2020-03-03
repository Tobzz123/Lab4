//Hello
using System;
using System.Collections.Generic;
using System.Text;
/*I, Olaoluwa Anthony-Egorp, 000776467, certify that all code submitted is my
 own work; that I have not copied it from any other source. I also certify that
 I have not allowed my work to be copied by others. */

namespace Lab4A
{
    /// <summary>
    /// This is the Employee class. It makes an employee object and upon creation has a constructor that needs name, number, rate and hours.
    /// </summary>
    class Employee 
    {
        //Public declaration of instance variables with get and set properties
        public string Name { get; set; }
        public int Number { get; set; }
        public Decimal Rate { get; set; }
        public double Hours { get; set; }
        //Calculating gross in get property, with no set property
        public Decimal Gross
        {
            get {
                //If Hours is less than or equal 40 or greater than 0, then no overtime is applied
                if (Hours <= 40 && Hours > 0)
                {
                    return Rate * 40;
                }

                //If the Employee works over 40 hours, they get paid their normal wage, and over time pay is calculated for every hour after 40
                else
                {
                   return (Rate * (decimal)Hours) + (((decimal)Hours - 40) * (Rate * (decimal)1.5));
                }
            }                

  
        }
        /// <summary>
        /// This is the Employee constructor that takes the instance variables above and uses them to make an object
        /// </summary>
        /// <param name="name">The name of the Employee</param>
        /// <param name="number">The Employee's number</param>
        /// <param name="rate">This represents the Employee's hourly wage</param>
        /// <param name="hours">This represents how many hours the Employee works for</param>
        public Employee(string name, int number, Decimal rate, double hours)
        {
            Name = name;
            Number = number;
            Rate = rate;
            Hours = hours;
        }

        /// <summary>
		/// This method returns all the information about the employee. Name, number rate, hours and gross salary.
		/// </summary>
		/// <returns string> All information about employee : name, number, rate, hours, gross pay</returns>
		public override string ToString()
        {
            return Name + ", " + Number + ", " + Rate + ", " + Hours + ", " + String.Format("{0:0.00}", Gross) + ".";
        }

    }  
}

