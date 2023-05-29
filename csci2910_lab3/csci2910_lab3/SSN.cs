/**       
 *--------------------------------------------------------------------
 * 	   File name: SSN.cs
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
    public class SSN
    {
        //Fields
        private string _number;
        //Properties
        public string Number
        {
            get { return _number; }
            //randomly initializes and formats an invalid number for SSN using one of the three invalidation options found here: https://secure.ssa.gov/poms.nsf/lnx/0110201035 
            init
            {
                string number = "";
                Random rand = new Random();
                int option = rand.Next(1, 4);
                if (option == 1)
                {
                    string[] areaNumOptions = { "000", "666", rand.Next(900, 1000).ToString() };
                    int areaNumIndex = rand.Next(areaNumOptions.Length);
                    number += areaNumOptions[areaNumIndex] + "-" + rand.Next(100).ToString("00") + "-" + rand.Next(10000).ToString("0000");
                }
                else if (option == 2)
                {
                    number += rand.Next(1000).ToString("000") + "-00-" + rand.Next(10000).ToString("0000");

                }
                else
                {
                    number += rand.Next(1000).ToString("000") + "-" + rand.Next(100).ToString("00") + "-0000";
                }
                _number = number;
            }
        }
        //Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SSN()
        {

        }
        //Methods
        /// <summary>
        /// Overrides ToString method to retun SSN information
        /// </summary>
        /// <returns>the SSN number</returns>
        public override string ToString()
        {
            return Number;
        }
    }
}
