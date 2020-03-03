using System;
using System.Collections.Generic;
using System.IO;

/*I, Olaoluwa Anthony-Egorp, 000776467, certify that all code submitted is my
 own work; that I have not copied it from any other source. I also certify that
 I have not allowed my work to be copied by others. 
 
    November 15th, 2019
     */

namespace Lab4A
{
    /// <summary>
    /// Olaoluwa Anthony-Egorp, 000776467
    /// 
    /// November 9th, 2019
    /// 
    /// The purpose of this program is to sort employees depending on what the user chooses and display it in a neat orderly list. The user can sort this list by name, number, rate, hours, and gross pay.
    /// This is the main program where everything takes place. This is an employee sort app which sorts a list of employees based on the sort category.
    /// </summary>
    class Program
    {
        /// <summary>
        /// This is the main method where user interaction exists
        /// </summary>
        /// <param name="args"> array of arguments</param>
        static void Main(string[] args)
        {
            //Array of employees that is storing employee info which is being read from a comma seperating file
            List<Employee> employees = Read("employees.csv");

            Console.WriteLine("E M P L O Y E E   S O R T I N G   A P P L I C A T I O N \n"
                             + "======================================================= \n\n");

            //Boolean variables that acts a switch for looping the application until user exits
            bool isDone = true;

            //While loop that repeats application
            while (isDone)
            {

                //This is a try-catch statement that enwraps the entire program to account for any errors or exceptions.
                try
                {
                    //Menu for the program
                    Console.WriteLine("\t\t\t\t\t MENU\n" +
                                      "1 - Sort by Employee Name (Ascending) \n" +
                                      "2 - Sort by Employee Number (Ascending) \n" +
                                      "3 - Sort by Employee by Employee Pay Rate (Descending) \n" +
                                      "4 - Sort by Employee by Employee Hours (Descending) \n" +
                                      "5 - Sort by Employee Gross Pay (Descending) \n" +
                                      "6 - Exit\n");

                    //The user's option is converted into an integer. This is what is used to determine which sort will be applied
                    int option = int.Parse(Console.ReadLine());

                    //Switch case that handles all possible options
                    switch (option)
                    {
                        //This case sorts the list of Employees based on their name in ascending order
                        case 1:
                            Console.WriteLine("SORT BY EMPLOYEE NAME\n\n");
                           // InsertionSort(employees, 1);
                            employees.Sort((Employee e1, Employee e2) => {
                                return e1.Name.CompareTo(e2.Name);
                            });
                            foreach (Employee e in employees)
                                Console.WriteLine(e.ToString());
                            break;

                        //This case sorts the list of Employees based on their Employee Number in ascending order
                        case 2:
                            Console.WriteLine("SORT BY EMPLOYEE NUMBER\n\n");
                            //InsertionSort(employees, 2);
                            employees.Sort((Employee e1, Employee e2) =>
                            {
                                return e1.Number.CompareTo(e2.Number);
                            });
                            foreach (Employee e in employees)
                                Console.WriteLine(e.ToString());
                            break;
                        //This case sorts the list of Employees based on their Pay rate in descending order by calling the sort method
                        case 3:
                            Console.WriteLine("SORT BY EMPLOYEE PAY RATE(DESCENDING)\n\n");
                            //InsertionSort(employees, 3);
                            employees.Sort((Employee e1, Employee e2) =>
                            {
                                return e2.Rate.CompareTo(e1.Rate);
                            });
                            foreach (Employee e in employees)
                                Console.WriteLine(e.ToString());
                            break;

                        //This case sorts the list of Employees based on the amount of hours they have worked in descending order by calling the sort method
                        case 4:
                            Console.WriteLine("SORT BY EMPLOYEE HOURS(DESCENDING)\n\n");
                            //InsertionSort(employees, 4);
                            employees.Sort((Employee e1, Employee e2) =>
                            {
                                return e2.Hours.CompareTo(e1.Hours);
                            });
                            foreach (Employee e in employees)
                                Console.WriteLine(e.ToString());
                            break;

                        //This case sorts the list of Employees based on their gross pay in descending order using the sort method
                        case 5:
                            Console.WriteLine("SORT BY EMPLOYEE GROSS PAY(DESCENDING)\n\n");
                            //InsertionSort(employees, 5);
                            employees.Sort((Employee e1, Employee e2) =>
                            {
                                return e2.Gross.CompareTo(e1.Gross);
                            });
                            foreach (Employee e in employees)
                                Console.WriteLine(e.ToString());
                            break;

                        //This case ends the program and turns the boolean switch to false
                        case 6:
                            Console.WriteLine("BYE !!!");
                            isDone = false;
                            break;

                        //This case is responsible for any other input apart from the other cases. Loops back and tells the user to enter a valid input
                        default:
                            Console.WriteLine("Enter a valid number please (1-6)");
                            break;
                    }

                }
                //This catches the exception in which the input is in the wrong format; Not an int
                catch (FormatException ef)
                {
                    Console.WriteLine($"Wrong input. {ef.Message}");
                }
                //This catches any other possible exception that can be pulled from bad input
                catch (Exception ex)
                {
                    Console.WriteLine($"Error! {ex.Message}");
                }
            }


        }

        /// <summary>
        /// This is the read method. It returns an Employee Array and needs to read it from; This refers to the csv file
        /// </summary>
        /// <param name="fileName">Name of the comma seperated file</param>
        /// <returns></returns>
        static List<Employee> Read(String fileName)
        {
            //This try-catch block enwraps the read code in the case of the file not being found or any other error found from reading the file
            try
            {
                //Streamreader object that does the reading of the file
                StreamReader reader = new StreamReader(fileName);
                List<Employee> e = new List<Employee>();
               
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    //Split line into fields
                    string[] parts = line.Split(',');

                    //Create an Employee object with the 4 properties
                    e.Add(new Employee(parts[0], int.Parse(parts[1]), Decimal.Parse(parts[2]), Double.Parse(parts[3])));
                }

                //Array is resized to the correct amount and is returned
                return e;
            }
            //Catch statements for possible Exceptions
            //End of File error exception handling
            catch (EndOfStreamException eos)
            {
                Console.WriteLine($"End of stream has been reached {eos.Message}");
            }
            //End of File error exception handling
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found {ex.Message}");
            }
            //Input/Output error exception handling
            catch (IOException ei)
            {
                Console.WriteLine($"Input/Output Error {ei.Message}");
            }
            //General Exception error exception handling
            catch (Exception er)
            {
                Console.WriteLine($"General error {er.Message}");

            }

            //Nothing is returned if an error pops up
            return null;

        }


        
        }
    }
