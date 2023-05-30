/**       
 *--------------------------------------------------------------------
 * 	   File name: RandomDataGenerator.cs
 * 	Project name: csci2910_lab3
 *--------------------------------------------------------------------
 * Author’s name and email:	 Tessa Williams williamstm5@etsu.edu				
 *          Course-Section: CSCI-2910-970
 *           Creation Date:	 05/29/2023		
 * -------------------------------------------------------------------
 */

namespace csci2910_lab3
{
    public class RandomDataGenerator
    {
        static void Main()
        {
            //Variables
            int menuOpt;
            bool success;
            int numPeople = 0;
            int counter;
            int personSelect;
            string randLastName;
            Random rand = new Random();
            List<Person> population = new List<Person>();

            
            do
            {
                //Display main menu, ask for menu selection and validate user input
                DisplayMenu();
                Console.Write("Menu Selection: ");
                success = int.TryParse(Console.ReadLine(), out menuOpt);
                if (menuOpt > 6 || menuOpt < 0)
                {
                    success = false;
                }
                while (!success)
                {
                    Console.WriteLine("*Invalid Input* Please enter an integer 0-6.");
                    Console.Write("Menu Selection: ");
                    success = int.TryParse(Console.ReadLine(), out menuOpt);
                    if (menuOpt > 6 || menuOpt < 0)
                    {
                        success = false;
                    }
                }
                //Menu Functionality
                switch (menuOpt)
                {
                    case 1:
                        //Validates user input is a positve integer or else throws an error and displays a helpful message.
                        do
                        {
                            success = false;
                            Console.WriteLine("\n-----Generate Random Person-----");
                            Console.WriteLine("How many people would you like to generate?");
                            try
                            {
                                numPeople = Convert.ToInt32(Console.ReadLine());
                                if (numPeople < 0)
                                {
                                    throw new FormatException();
                                }
                                success = true;
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("*Invalid Input* Please enter a positive integer.");
                            }
                            catch (OverflowException ex)
                            {
                                Console.WriteLine("*Invalid Input* Number was too large.");
                            }
                        } while (!success);
                        //for the number specified by the user, generates a new person and their dependents then adds them to the list of people
                        //and displays a message indicating the number of people added to the population.
                        counter = 0;
                        for (int i = 1; i <= numPeople; i++)
                        {
                            Person person = new Person();
                            person.AddDependent();
                            AddPerson(person, population);
                            for (int j = 0; j < person.Dependents.Count(s => s != null); j++)
                            {
                                AddPerson(person.Dependents[j], population);
                                counter++;
                            }
                            Console.WriteLine(person.ToString());
                            counter++;
                        }
                        Console.WriteLine($"\n{counter} people were added to the population!");
                        
                        break;
                    case 2:
                        Console.WriteLine("\n-----View All Persons-----");
                        if (population.Count == 0)
                        {
                            Console.WriteLine("No people found. Generating random default person now...");
                            Person person = new Person();
                            AddPerson(person, population);
                        }
                        ViewAllPersons(population);
                        //prompts user to select a person to view or cancel and validates input then displays person's information or returns to main menu
                        do
                        {
                            Console.WriteLine("\nWhich person would you like to view? (Enter 0 to cancel)");
                            Console.Write("Person's Number: ");
                            success = int.TryParse(Console.ReadLine(), out personSelect);
                            if (personSelect > population.Count || personSelect < 0)
                            {
                                success = false;
                            }
                            while (!success)
                            {
                                Console.WriteLine($"*Invalid Input* Please enter an integer 0 - {population.Count}.");
                                Console.WriteLine("\nWhich person would you like to view? (Enter 0 to cancel)");
                                Console.Write("Person's Number: ");
                                success = int.TryParse(Console.ReadLine(), out personSelect);
                                if (personSelect > population.Count || personSelect < 0)
                                {
                                    success = false;
                                }
                            }
                            if (personSelect != 0)
                            {
                                Console.WriteLine(population.ElementAt(personSelect - 1).ToString());
                            }
                        } while (personSelect != 0);
                        
                        break;
                    case 3:
                        Console.WriteLine("\n-----Remove Person-----");
                        if (population.Count == 0)
                        {
                            Console.WriteLine("No people to remove. Try generating some people first.");
                        }else
                        {
                            //Displays a list of all people.Prompts user to enter number of person they would like to remove,
                            //validates input, and removes person from population. Repeats until user cancels.
                            do
                            {
                                ViewAllPersons(population);
                                Console.WriteLine("\nWhich person would you like to remove? (Enter 0 to cancel)");
                                Console.Write("Person's Number: ");
                                success = int.TryParse(Console.ReadLine(), out personSelect);
                                if (personSelect > population.Count || personSelect < 0)
                                {
                                    success = false;
                                }
                                while (!success)
                                {
                                    Console.WriteLine($"*Invalid Input* Please enter an integer 0 - {population.Count}.");
                                    Console.WriteLine("\nWhich person would you like to remove? (Enter 0 to cancel)");
                                    Console.Write("Person's Number: ");
                                    success = int.TryParse(Console.ReadLine(), out personSelect);
                                    if (personSelect > population.Count || personSelect < 0)
                                    {
                                        success = false;
                                    }
                                }
                                if (personSelect != 0)
                                {
                                    RemovePerson(population.ElementAt(personSelect - 1), population);
                                }
                            }while (personSelect != 0);
                            
                        }
                        break;
                    case 4:
                        //Generates random last name and displays it.
                        Console.WriteLine("\n-----Random Last Name-----");
                        randLastName = Convert.ToString((LastName)rand.Next(10));
                        Console.WriteLine(randLastName);
                        break;
                    case 5:
                        Console.WriteLine("\n-----Random SSN-----");
                        SSN sSN = new SSN();
                        Console.WriteLine(sSN);
                        break;
                    case 6:

                        break;
                    default:
                        break;
                }
            } while (menuOpt != 0);
        }
        //Methods
        /// <summary>
        /// Displays main menu
        /// </summary>
        static void DisplayMenu()
        {
            Console.WriteLine("\n-----Main Menu-----");
            Console.WriteLine("1.Generate Random Person");
            Console.WriteLine("2.View All Persons");
            Console.WriteLine("3.Remove Person");
            Console.WriteLine("4.Generate Random Last Name");
            Console.WriteLine("5.Generate Random SSN");
            Console.WriteLine("6.Generate Random Phone Number");
            Console.WriteLine("0.Exit Program");
        }
        /// <summary>
        /// Adds a person to a list of people
        /// </summary>
        /// <param name="person">Person - person to add</param>
        /// <param name="people">List<Person> - list of people to add too</param>
        static void AddPerson(Person person, List<Person> people)
        {
            people.Add(person);
        }
        /// <summary>
        /// Removes a person from a list if they exist in that list else display an error message.
        /// </summary>
        /// <param name="person">Person - person to remove</param>
        /// <param name="people">List<Person> - list of people to remove from</param>
        static void RemovePerson(Person person, List<Person> people)
        {
            if (people.Contains(person))
            {
                people.Remove(person);
                Console.WriteLine($"\n{person.FirstName} {person.LastName} was removed.\n");
            }else
            {
                Console.WriteLine($"\nError {person.FirstName} {person.LastName} was not found.\n");
            }
        }
        /// <summary>
        /// Displays all people in a population in an ordered list
        /// </summary>
        /// <param name="population">List containing the people to view</param>
        static void ViewAllPersons(List<Person> population)
        {
            int counter = 1;
            foreach (Person person in population)
            {
                Console.WriteLine(counter + ". " + person.FirstName + " " + person.LastName);
                counter++;
            }
        }
    }
}