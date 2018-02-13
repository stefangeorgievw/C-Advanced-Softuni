using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var departaments = new Dictionary<string,List<string>>();
            var doctors = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                var inputArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                string department = inputArgs[0];
                string doctor = inputArgs[1] + " " + inputArgs[2];
                string patient = inputArgs[3];
                
                
                if (!departaments.ContainsKey(department))
                {
                    departaments[department] = new List<string>();
                }
                if (!doctors.ContainsKey(doctor))
                {
                    doctors[doctor] = new List<string>();
                }

                if (departaments[department].Count < 60)
                {
                    departaments[department].Add(patient);
                    doctors[doctor].Add(patient);
                }

            }

            string printInput;
            while ((printInput = Console.ReadLine()) !="End" )
            {
                var inputArgs = printInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (inputArgs.Count == 1)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departaments[printInput]));
                }
                else
                {
                    string doctor = inputArgs[0] + " " + inputArgs[1];
                    if (doctors.ContainsKey(doctor))
                    {
                        Console.WriteLine(string.Join(Environment.NewLine, doctors[doctor].OrderBy(n=>n)));
                    }
                    else
                    {
                        var room = int.Parse(inputArgs[1]);
                        var patientInTheRoom = departaments[inputArgs[0]].Skip(room * 3 - 3).Take(3).OrderBy(x => x);
                        Console.WriteLine(string.Join(Environment.NewLine,patientInTheRoom));
                    }
                }

               
            }
        }
    }
}
