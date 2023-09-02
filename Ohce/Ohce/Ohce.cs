using System;

namespace Ohce
{
    public class Ohce
    {

        public static void Main()
        {
            OhceMethods om = new OhceMethods();

            string startString = Console.ReadLine();


            string greeting = om.GetGreeting(DateTime.Now.TimeOfDay, startString);
            Console.WriteLine(greeting);

            /* Quit the program if the starting text was not in the format "Ohce <FirstName>" */
            if (!greeting.Contains("Please enter"))
            {
                while (true)
                {
                    string text = Console.ReadLine();// read line

                    /* printout the reverse of text entered */
                    Tuple<string, bool> ohceResponse = om.Ohce(text);
                    Console.WriteLine(ohceResponse.Item1);

                    /* quit after printing Adios Pedro if the user entered Stop!*/
                    if (ohceResponse.Item2 == true)
                    {
                        break;
                    }
                }
            }

        }
    }
}