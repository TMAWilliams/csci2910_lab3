/**       
 *--------------------------------------------------------------------
 * 	   File name: Phone.cs
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
    public class Phone
    {
        //Field
        private string _number;
        //Property
        public string Number
        {
            get { return _number; }
            init
            {
                
                _number = value;
            }
        }
        //Constructor
        public Phone()
        {
            Random rand = new Random();
            string number = rand.NextInt64(2000000000, 10000000000).ToString();
            Number = number;
        }
        //Method
        public string Format(char seperator = '-')
        {
            StringBuilder phoneNumber = new StringBuilder($"{Number}", 12);
            phoneNumber.Insert(3, seperator);
            phoneNumber.Insert(7, seperator);
            return phoneNumber.ToString();
        }
    }
}
