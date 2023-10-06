using System;

namespace PassengerDetails
{
    public class Passenger
    {
        string name;
        string phoneNumber;
        public string PassengerName
        {
            get{return name;}
            set{name = value;}
            
        }
        public string PassengerPhNo
        {
            get{return phoneNumber;}
            set{phoneNumber = value;}
           
        }
        public string giveRating()
        {
            string rating;
            do
            {
                Console.Write("\nGive Rating out of 5: ");
                Console.ForegroundColor = ConsoleColor.Green;
                rating = Console.ReadLine();
                Console.ResetColor();
            } while (rating != "1" && rating != "2" && rating != "3" && rating != "4" && rating != "5");

            return rating;
        }
    }
}
