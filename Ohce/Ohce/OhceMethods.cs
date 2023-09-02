using System;

namespace Ohce
{
    public class OhceMethods
    {
        string name = "dummyName";

        /* GetGreeting 
         * Params: 
         *      timeNow -Current time, 
         *      startString - start string entered by user (expected in format Ohce <your FirstName>)
         * retun value: string
         *      timeNow between 20(included) to 6(Excluded) - ¡Buenas noches <name>
         *      timeNow between 6(included) to 12(Excluded) - ¡Buenos días <name>
         *      timeNow between 12(included) to 20(Excluded) - ¡Buenas tardes <name>
         */

        public string GetGreeting(TimeSpan timeNow, string startString)
        {
            string greetings;

            if (startString.Split(' ').Length <=1 || !startString.Split(' ')[0].Equals("Ohce", StringComparison.InvariantCultureIgnoreCase) || startString.Split(' ')[1].Equals(string.Empty))
            {
                return "Please enter: Ohce <your FirstName> to start";
            }
            name = startString.Split(' ')[1];

            TimeSpan time20 = new TimeSpan(20, 0, 0); //20 o'clock
            TimeSpan timeMidNight = new TimeSpan(23, 59, 59); //right before midnight 12 o'clock
            TimeSpan time0 = new TimeSpan(0, 0, 0);//midnight 12 o'clock
            TimeSpan time6 = new TimeSpan(6, 0, 0); //6 o'clock
            TimeSpan time12 = new TimeSpan(12, 0, 0); //12 o'clock

            

            if (((timeNow >= time20) && (timeNow <= timeMidNight))||((timeNow >= time0) && (timeNow < time6)))
            {
                greetings = $"¡Buenas noches {name}!";
            }
            else if ((timeNow >= time6) && (timeNow < time12))
            {
                greetings = $"¡Buenos días {name}!";
            }
            else
            {
                greetings = $"¡Buenas tardes {name}!";
            }

            return greetings;

        }


        /* Ohce 
         * Param: 
         *      text -text to be reversed, 
         * retun value: string
         *      normal text     - <reverse of text>
         *      Palindrome text - <reverse of text> ¡Bonita palabra!
         *      Stop!           - "Adios <Name>"
         */

        public Tuple<string, bool> Ohce(string text)
        {
            if (text.Equals("Stop!", StringComparison.InvariantCultureIgnoreCase))
            {
                return Tuple.Create($"Adios {name}",true);
            }

            if (text == " " || text == string.Empty)
            {
                return Tuple.Create(text, false);
            }

            string reverseText = new string((from c in text.Select((value, index) => new { value, index })
                                             orderby c.index descending
                                             select c.value).ToArray());

            if (text.Equals(reverseText, StringComparison.InvariantCultureIgnoreCase))
            {
                reverseText += "\n¡Bonita palabra!";
            }

            return Tuple.Create(reverseText, false);
        }
    }
}