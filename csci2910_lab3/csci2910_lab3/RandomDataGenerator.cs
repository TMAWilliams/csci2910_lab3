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
            
        }
        /// <summary>
        /// Displays main menu
        /// </summary>
        static void DisplayMenu()
        {
            Console.WriteLine("-----Main Menu-----");
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
                Console.WriteLine($"{person.FirstName} {person.LastName} was removed.");
            }else
            {
                Console.WriteLine($"Error {person.FirstName} {person.LastName} was not found.");
            }
        }


    }
}