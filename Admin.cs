using System;
using DriverDetails;
using VehicleDetails;

namespace AdminCentre
{
    public class Admin
    {
        List<Driver> DriversList;
        public List<Driver> AllDrivers
        {
            get{ return DriversList;}
            set{ DriversList = value;}
            
        }
        public Admin()
        {
            DriversList = new List<Driver>();
        }
        public void addDriver()
        {
            Console.Write("Enter Name: ");
            string name;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                name = Console.ReadLine();
                Console.ResetColor();
            } while (name == "");

            Console.Write("Enter Age: ");
            string age;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                age = Console.ReadLine();
                Console.ResetColor();
            } while (age == "");

            Console.Write("Enter Gender: ");
            string gender;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                gender = Console.ReadLine();
                Console.ResetColor();
            } while (gender == "");

            Console.Write("Enter Address: ");
            string address;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                address = Console.ReadLine();
                Console.ResetColor();
            } while (address == "");

            string type;
            do
            {
                Console.Write("\nEnter Vehicle Type: ");
                Console.ForegroundColor = ConsoleColor.Green;
                type = Console.ReadLine();
                Console.ResetColor();
            } while (type != "car" && type != "rikshaw" && type != "bike");

            Console.Write("Enter Vehicle Model: ");
            string model;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                model = Console.ReadLine();
                Console.ResetColor();
            } while (model == "");

            Console.Write("Enter Vehicle License Plate: ");
            string license;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                license = Console.ReadLine();
                Console.ResetColor();
            } while (license == "");

            Vehicle vehicle = new Vehicle
            {
                VehicleType = type,
                VehicleModel = model,
                VehicleLicensePlate = license
            };
            
            int id = 0;
            if (DriversList.Count > 0)
            { 
                id = DriversList.Count + 1;
            }
            else
            {
                id = 1;
            }

            Driver driver = new Driver
            {
                DriverID = id,
                DriverName = name,
                DriverAge = Convert.ToInt32(age),
                DriverGender = gender,
                DriverAddress = address,
                MyVehicle = vehicle
            };

            DriversList.Add(driver);
            Console.WriteLine("Driver is added succssfully with Id " + id);
        }
        public void removeDriver()
        {
            Console.Write("Enter driver ID: ");
            string driverID;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                driverID = Console.ReadLine();
                Console.ResetColor();
            } while (driverID == "");

            Driver driverToDelete = new Driver();
            bool flag = false;
            foreach (Driver driver in DriversList)
            {
                if (driver.DriverID == Convert.ToInt32(driverID))
                {
                    driverToDelete = driver;
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                Console.WriteLine("This driver doesn't exist!");
            }
            else
            {
                DriversList.Remove(driverToDelete);
                Console.WriteLine("Remove operation is done successfully!");
            }
        }

        public void updateDriver()
        {
            Console.Write("Enter driver ID: ");
            string driverID;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                driverID = Console.ReadLine();
                Console.ResetColor();
            } while (driverID == "");

            bool flag = false;
            foreach (Driver driver in DriversList)
            {
                if (driver.DriverID == Convert.ToInt32(driverID))
                {
                    Console.WriteLine("Driver with ID " + driver.DriverID + " exists");

                    Console.Write("Enter Name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string name = Console.ReadLine();
                    Console.ResetColor();
                    if (name != "")
                    {
                        driver.DriverName = name;
                    }

                    Console.Write("Enter Age: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string age = Console.ReadLine();
                    Console.ResetColor();
                    if (age != "")
                    {
                        driver.DriverAge = Convert.ToInt32(age);
                    }

                    Console.Write("Enter Gender: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string gender = Console.ReadLine();
                    Console.ResetColor();
                    if (gender != "")
                        driver.DriverGender = gender;

                    Console.Write("Enter Address: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string address = Console.ReadLine();
                    Console.ResetColor();
                    if (address != "")
                    {
                        driver.DriverAddress = address;
                    }

                    Console.Write("Enter Vehicle Type: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string type = Console.ReadLine();
                    Console.ResetColor();
                    if (type != "")
                    {
                        driver.MyVehicle.VehicleType = type;
                    }

                    Console.Write("Enter Vehicle Model: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string model = Console.ReadLine();
                    Console.ResetColor();
                    if (model != "")
                    {
                        driver.MyVehicle.VehicleModel = model;
                    }

                    Console.Write("Enter Vehicle License Plate: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string license = Console.ReadLine();
                    Console.ResetColor();
                    if (license != "")
                    {
                        driver.MyVehicle.VehicleLicensePlate = license;
                    }

                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("This driver doesn't exist");
            }
            else
            {
                Console.WriteLine("Update operation is done successfully!");
            }
        }
        public void searchDriver()
        {
            Console.Write("Enter driver ID: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string driverID = Console.ReadLine();
            Console.ResetColor();
            Console.Write("Enter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Console.ReadLine();
            Console.ResetColor();
            Console.Write("Enter Age: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string age = Console.ReadLine();
            Console.ResetColor();
            Console.Write("Enter Gender: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string gender = Console.ReadLine();
            Console.ResetColor();
            Console.Write("Enter Address: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string address = Console.ReadLine();
            Console.ResetColor();
            Console.Write("Enter Vehicle Type: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string type = Console.ReadLine();
            Console.ResetColor();
            Console.Write("Enter Vehicle Model: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string model = Console.ReadLine();
            Console.ResetColor();
            Console.Write("Enter Vehicle License Plate: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string license = Console.ReadLine();
            Console.ResetColor();


            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Name\tAge\tGender\tV.Type\tV.Model\tV.License");
            Console.WriteLine("-----------------------------------------------------");
            foreach (Driver driver in DriversList)
            {
                bool flag = false;
                if (driverID != "")
                {
                    if (driver.DriverID == Convert.ToInt32(driverID))
                    {
                        flag = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (name != "")
                {
                    if (driver.DriverName == name)
                    {
                        flag = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (age != "")
                {
                    if (driver.DriverAge == Convert.ToInt32(age))
                    {
                        flag = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (gender != "")
                {
                    if (driver.DriverGender == gender)
                    {
                        flag = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (address != "")
                {
                    if (driver.DriverAddress == address)
                    {
                        flag = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (type != "")
                {
                    if (driver.MyVehicle.VehicleType == type)
                    {
                        flag = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (model != "")
                {
                    if (driver.MyVehicle.VehicleModel == model)
                    {
                        flag = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (license != "")
                {
                    if (driver.MyVehicle.VehicleLicensePlate == license)
                    {
                        flag = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (flag)
                {
                    Console.WriteLine($"{driver.DriverName}\t{driver.DriverAge}\t{driver.DriverGender}\t{driver.MyVehicle.VehicleType}\t{driver.MyVehicle.VehicleModel}\t{driver.MyVehicle.VehicleLicensePlate}");
                }
                
            }
        }
    }
}
