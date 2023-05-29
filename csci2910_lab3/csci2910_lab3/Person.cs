/**       
 *--------------------------------------------------------------------
 * 	   File name: Person.cs
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
    public class Person
    {
        //Fields
        private string[]_arrayOfFirstNames = new string[10];
        private Dependent[] _dependents = new Dependent[10];

        //Properties
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime BirthDate { get; init; }
        public SSN SSN { get; init; }
        public Phone Phone { get; init; }

        //Constructors
        public Person()
        {

        }

        //Methods
        public int Age()
        {

        }

        public void AddDependent()
        {

        }

        public override string ToString()
        {
            
        }
    }
}
