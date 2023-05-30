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
        protected string[]_arrayOfFirstNames = {"Abby", "Sydnie", "Krystal", "Sammy", "Eli", "John", "Josh", "Roberto", "Tom", "Collin"};
        private Dependent[] _dependents = new Dependent[10];
        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;
        private SSN _ssn;
        private Phone _phone;

        //Properties
        /*init assigns a value to the property only during the object's construction 
         * meaning the value cannot be changed after the object is created. 
         * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/init
         */
        public string FirstName
        {
            get { return _firstName; }
            init { _firstName = value; } 
        }
        public string LastName
        {
            get { return _lastName; }
            init { _lastName = value; }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            init { _birthDate = value; }
        }
        public SSN SSN
        {
            get { return _ssn; }
            init { _ssn = value; }
        }
        public Phone Phone
        {
            get { return _phone; }
            init { _phone = value; }
        }
        //Constructors
        /// <summary>
        /// Constructor that randomizes data for a person
        /// </summary>
        public Person()
        {
            Random rand = new Random();
            //Select first name randomly
            FirstName = _arrayOfFirstNames[rand.Next(_arrayOfFirstNames.Length)];
            //Select last name randomly
            LastName = Convert.ToString((LastName)rand.Next(10));
            //Generate random birthdate where the age of the person is 18-80 years old from current date
            DateTime min = DateTime.Today.AddYears(-18);
            DateTime max = DateTime.Today.AddYears(-80);
            TimeSpan range = min - max;
            BirthDate = max.AddDays(rand.Next(range.Days));
            //Generate random invalid SSN
            SSN = new SSN();
            //Generate random phone number
            Phone = new Phone();
        }

        //Methods
        /// <summary>
        /// Calculates the age of a person based on their birthday compared to today's date
        /// </summary>
        /// <returns>person's age</returns>
        public int Age()
        {
            TimeSpan age = DateTime.Today - BirthDate;
            int ageInYears = (age.Days/365);
            return ageInYears;
        }
        /// <summary>
        /// Adds a random number (max of 10) of randomly generated dependents.
        /// </summary>
        public void AddDependent()
        {
            Random rand = new Random();
            for (int i = 0; i <= rand.Next(10); i++)
            {
                _dependents[i] = new Dependent();
            }
        }
        /// <summary>
        /// Overrides ToSting method to format information about a person
        /// </summary>
        /// <returns>message containing info about a person</returns>
        public override string ToString()
        {
            string msg = "";
            msg += "\n--------------------";
            msg += $"\nFirst Name: {FirstName}";
            msg += $"\nLast Name: {LastName}";
            msg += $"\nBirthDate: {BirthDate}";
            msg += $"\nAge: {Age()}";
            msg += $"\nSSN: {SSN}";
            msg += $"\nPhone Number: {Phone.Format()}";
            msg += "\nList of Dependents:";
            if (_dependents[0] != null)
            {
                foreach (Dependent dependent in _dependents)
                {
                    if (dependent != null)
                    {
                        msg += $"\n {dependent.FirstName} {dependent.LastName}";
                    }
                }
            }else
            {
                msg += "\nNone";
            }
            return msg;
        }

    }
}
