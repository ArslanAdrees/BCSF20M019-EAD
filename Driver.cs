using System;
using LocationDetails;
using VehicleDetails;

namespace DriverDetails
{
    public class Driver
    {
        string name;
        int id;
        int age;
        string gender;
        string address;
        string phoneNumber;
        Location currLocation;
        Vehicle vehicle;
        bool availability;
        List<int> rating;

        public Location MycurrLocation
        {
            get{return currLocation;}
            set{currLocation = value;}
            
        }
        public Vehicle MyVehicle
        {
            get{return vehicle;}
            set{vehicle = value;}
            
        }
        public string DriverName
        {
            get{return name;}
            set{name = value;}
            
        }
        public int DriverID
        {
            get{return id;}
            set{id = value;}
            
        }
        public int DriverAge
        {
            get{ return age;}
            set{age = value;}
           
        }
        public string DriverGender
        {
            get{return gender;}
            set{gender = value;}
            
        }
        public string DriverAddress
        {
            get{return address;}
            set{address = value;}
           
        }
        public string DriverPhNo
        {
            get{return phoneNumber;}
            set{phoneNumber = value;}
            
        }
        public int DriverRating
        {
            set{rating.Add(value);}
        }
        public bool DriverAvailability
        {
            get{return availability;}
            set{availability = value;}
            
        }

        public Driver()
        {
            currLocation = new Location();
            vehicle = new Vehicle();
            rating = new List<int>();
            availability = true;
        }
        public void updateAvailability()
        {
            Console.Write("Your Availability (yes/no): ");
            Console.ForegroundColor = ConsoleColor.Green;
            string availabilityStatus = Console.ReadLine();
            Console.ResetColor();
            if (availabilityStatus == "yes")
            {
                availability = true;
            }
            else if (availabilityStatus == "no")
            {
                availability = false;
            }
            else
            {
                Console.WriteLine("You entered wrong choice");
            }
        }
        public float getRating()
        {
            float average;
            int sum = 0;
            for (int i = 0; i < rating.Count; i++)
            {
                sum = sum + rating[i];
            }
            average = sum / rating.Count;
            return average;
        }
        public void updateLocation()
        {
            Console.Write("Enter your Current Location: ");
            string location;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                location = Console.ReadLine();
                Console.ResetColor();
            } while (location == "");
            string[] locationPoints = location.Split(',');
            float longitude = float.Parse(locationPoints[0]);
            float latitude = float.Parse(locationPoints[1]);
            currLocation = new Location
            {
                LocationLongitude = longitude,
                LocationLatitude = latitude
            };
        }
    }
}
