using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CubinMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^[0-9]+)([a-zA-Z]+)([^a-zA-Z]*)$";

            string input;
            while((input = Console.ReadLine()) != "Over!" )
            {
                int n = int.Parse(Console.ReadLine());
                Regex regex = new Regex(pattern);
                var sb = new StringBuilder();
                Match match = regex.Match(input);
                
                if (match.Success && match.Groups[2].Value.Length ==n )
                {
                   
                    string message = match.Groups[2].Value;
                    string numbersLeft = match.Groups[1].Value;
                    var numbersRight = string.Empty;
                    if (match.Groups[3].Value.Length >0)
                    {
                         numbersRight = match.Groups[3].Value;        
                    }
                  var  indeces = Regex.Replace(numbersLeft + numbersRight, @"\D*", string.Empty);
                    for (int i = 0; i < indeces.Length; i++)
                    {
                        var ind = int.Parse(indeces[i].ToString());
                        if (ind >= 0 && ind < message.Length)
                        {
                            sb.Append(message[ind]);
                        }
                        else
                        {
                            sb.Append(' ');
                        }
                        
                    }

                    Console.WriteLine($"{message} == {sb.ToString()}");
                }
            }

            
        }
    }
}
