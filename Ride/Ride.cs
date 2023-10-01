using System;
using LocationDetails;
using DriverDetails;
using PassengerDetails;
using AdminCentre;
using VehicleDetails;

namespace RideDetails
{
    public class Ride
    {
        Location startLocation;
        Location endLocation;
        int price;
        Driver driver;
        Passenger passenger;
        public Location MyStartLocation
        {
            get{return startLocation;}
            set{startLocation = value;}    
        }
        public Location MyEndLocation
        {
            get{return endLocation;}
            set{endLocation = value;} 
        }
        public int RidePrice
        {
            get{return price;}
            set{price = value;}   
        }
        public Driver RideDriver
        {
            get{return driver;}
            set {driver = value; }  
        }
        public Passenger RidePassenger
        {
            get{return passenger;}
            set{passenger = value;}
        }
        public Ride()
        {
            startLocation = new Location();
            endLocation = new Location();
            driver = new Driver();
        }
        public void assignPassenger()
        {
            Console.Write("Enter your Name: ");
            string name;
            do
            {
                Console.ForegroundColor= ConsoleColor.Green;
                name = Console.ReadLine();
                Console.ResetColor();
            } while (name == "");

            Console.Write("Enter your Phone No: ");
            string phoneNo;
            do
            {
                Console.ForegroundColor= ConsoleColor.Green;
                phoneNo = Console.ReadLine();
                Console.ResetColor();
            } while (phoneNo == "");

            passenger = new Passenger
            {
                PassengerName = name,
                PassengerPhNo = phoneNo
            };
        }
        public bool assignDriver(string RideType, Admin admin)
        {
            List<Driver> AvailableDrivers = new List<Driver>();
            List<Driver> drivers = admin.AllDrivers;

            foreach (Driver driver in drivers)
            {
                if (driver.DriverAvailability == true && driver.MyVehicle.VehicleType == RideType)
                {
                    AvailableDrivers.Add(driver);
                }
            }

            List<double> distances = new List<double>();
            
            foreach (Driver driver in AvailableDrivers)
            {
                Location Driverloc = driver.MycurrLocation;
                double LongitudeDifference = Math.Pow(Driverloc.LocationLongitude - startLocation.LocationLongitude, 2);
                double LatitudeDifference = Math.Pow(Driverloc.LocationLatitude - startLocation.LocationLatitude, 2);
                double distance = Math.Sqrt(LongitudeDifference + LatitudeDifference);
                distances.Add(distance);
            }
            
            int ShortestDistanceIndex = 0;
            for (int i = 1; i < distances.Count; i++)
            {
                if (distances[i] < distances[ShortestDistanceIndex])
                {
                    ShortestDistanceIndex = i;
                }
            }
            
            if (AvailableDrivers.Count > 0)
            {
                driver = AvailableDrivers[ShortestDistanceIndex];
                return true;
            }
            else
            {
                return false;
            }
        }
        public void getLocations()
        {
            
            Console.Write("Enter Start Location: ");
            string strtLocation;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                strtLocation = Console.ReadLine();
                Console.ResetColor();
            } while (strtLocation == "");

            string[] StartLocationPoints = strtLocation.Split(',');
            startLocation.LocationLongitude = float.Parse(StartLocationPoints[0]);
            startLocation.LocationLatitude = float.Parse(StartLocationPoints[1]);

           
            Console.Write("Enter End Location: ");
            string endLocat;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                endLocat = Console.ReadLine();
                Console.ResetColor();
            } while (endLocat == "");

            string[] EndLocationPoints = endLocat.Split(',');
            endLocation.LocationLongitude = float.Parse(EndLocationPoints[0]);
            endLocation.LocationLatitude = float.Parse(EndLocationPoints[1]);
        }
        public int calculatePrice()
        {
            double LongitudeDifference = Math.Pow(endLocation.LocationLongitude - startLocation.LocationLongitude, 2);
            double LatitudeDifference = Math.Pow(endLocation.LocationLatitude - startLocation.LocationLatitude, 2);
            double distance = Math.Sqrt(LongitudeDifference + LatitudeDifference);
            double commission;
            if (driver.MyVehicle.VehicleType == "bike")
            {
                double originalPrice = ((distance * 250) / 50);
                commission = originalPrice * 0.05;
                price = Convert.ToInt32(originalPrice + commission);
            }
            else if (driver.MyVehicle.VehicleType == "car")
            {
                double originalPrice = ((distance * 250) / 15);
                commission = originalPrice * 0.2;
                price = Convert.ToInt32(originalPrice + commission);
                
            }
            else
            {
                double originalPrice = ((distance * 250) / 35);
                commission = originalPrice * 0.1;
                price = Convert.ToInt32(originalPrice + commission);
            }
            
            return price;
        }
    }
}
