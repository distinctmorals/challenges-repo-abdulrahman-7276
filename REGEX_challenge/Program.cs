using System;
using System.Text.RegularExpressions;

   while (true)
        {
            Console.Write("Enter a date (mm/dd/yyyy) or type 'exit' to quit: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
                break;

            try
            {
                string result = ReverseDateFormat(input);
                if (result != null)
                {
                    Console.WriteLine("Reversed Date: " + result);
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please try again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    static string ReverseDateFormat(string input)
    {
        if (DateTime.TryParse(input, out _))
        {
            string pattern = @"^(?<mon>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})$";
            string replacement = "${year}-${mon}-${day}";
            TimeSpan timeout = TimeSpan.FromMilliseconds(500); // Setting a timeout for regex operation

            try
            {
                string result = Regex.Replace(input, pattern, replacement, RegexOptions.None, timeout);
                return NormalizeDate(result);
            }
            catch (RegexMatchTimeoutException)
            {
                Console.WriteLine("Regex operation timed out.");
                return input; 
            }
        }
        else
        {
            return null;
        }
    }

    static string NormalizeDate(string date)
    {
        string[] parts = date.Split('-');
        if (parts.Length == 3)
        {
            string year = parts[0].PadLeft(4, '0');
            string month = parts[1].PadLeft(2, '0');
            string day = parts[2].PadLeft(2, '0');
            return $"{year}-{month}-{day}";
        }
        return date;
    }
