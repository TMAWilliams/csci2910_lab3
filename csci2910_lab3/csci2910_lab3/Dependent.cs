/**       
 *--------------------------------------------------------------------
 * 	   File name: Dependent.cs
 * 	Project name: csci2910_lab3
 *--------------------------------------------------------------------
 * Author’s name and email:	 Tessa Williams williamstm5@etsu.edu				
 *          Course-Section: CSCI-2910-970
 *           Creation Date:	 05/29/2023		
 * -------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csci2910_lab3
{
    public class Dependent : Person
    {
        //Constructors
        /// <summary>
        /// Constructor that randomizes data for a dependent similar to a person but the age is limited to a max of 10 years.
        /// </summary>
        public Dependent()
        {
            Random rand = new Random();
            //Select first name randomly
            FirstName = _arrayOfFirstNames[rand.Next(_arrayOfFirstNames.Length)];
            //Select last name randomly
            LastName = Convert.ToString((LastName)rand.Next(10));
            //Generate random birthdate where the age of the person is 18-80 years old from current date
            DateTime min = DateTime.Today;
            DateTime max = DateTime.Today.AddYears(-10);
            TimeSpan range = min - max;
            BirthDate = max.AddDays(rand.Next(range.Days));
            //Generate random invalid SSN
            SSN = new SSN();
            //Generate random phone number
            Phone = new Phone();
        }
    }
}
