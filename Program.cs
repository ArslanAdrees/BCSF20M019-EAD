using System;
using DriverDetails;
using RideDetails;
using AdminCentre;
using LocationDetails;


namespace EAD_Assignment1
{
    public class MyRide
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine(" WELCOME TO MYRIDE");
            Console.WriteLine("------------------------------------");
            string myChoice;
            Admin admin = new Admin();
            do
            {
                Console.WriteLine("1. Book a Ride");
                Console.WriteLine("2. Enter as Driver");
                Console.WriteLine("3. Enter as Admin");
                Console.WriteLine("4. Exit");
                Console.Write("Press 1 to 4 to select an option: ");
                Console.ForegroundColor = ConsoleColor.Green;
                myChoice = Console.ReadLine();
                Console.ResetColor();
                if (myChoice == "1")
                {
                    Ride ride = new Ride();
                    string riderChoice;
                    ride.assignPassenger();
                    ride.getLocations();
                    string type;
                    do
                    {
                        Console.Write("\nEnter Ride Type: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        type = Console.ReadLine();
                        Console.ResetColor();
                    } while (type != "car" && type != "rikshaw" && type != "bike");
                    if (ride.assignDriver(type, admin))
                    {
                        Console.WriteLine("-------------THANK YOU-------------");
                        Console.WriteLine("Price for this ride is: " + ride.calculatePrice());
                        Console.Write("Enter ‘Y’ if you want to Book the ride, enter ‘N’ if you want to cancel operation: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        riderChoice = Console.ReadLine();
                        Console.ResetColor();
                        if (riderChoice == "Y" || riderChoice == "y")
                        {
                            Console.WriteLine("Happy Travel...!");
                            ride.RideDriver.DriverRating = Convert.ToInt32(ride.RidePassenger.giveRating());
                        }
                        else if(riderChoice != "N" && riderChoice != "n")
                        {
                            Console.WriteLine("You entered wrong choice");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No driver exists for this ride");
                    }
                }
                else if (myChoice == "2")
                {
                    Console.Write("Enter ID: ");
                    string ID;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        ID = Console.ReadLine();
                        Console.ResetColor();
                    } while (ID == "");
                    
                    Console.Write("Enter Name: ");
                    string name;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        name = Console.ReadLine();
                        Console.ResetColor();
                    } while (name == "");

                    List<Driver> drivers = admin.AllDrivers;
                    Driver driver = new Driver();
                    bool flag = false;
                    foreach (Driver d in drivers)
                    {
                        if (d.DriverID == Convert.ToInt32(ID) && d.DriverName == name)
                        {
                            flag = true;
                            driver = d;
                            break;
                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine("Hello " + name + "!");
                        Console.Write("\nEnter your current Location: ");
                        string loc;
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            loc = Console.ReadLine();
                            Console.ResetColor();
                        } while (loc == "");

                        string[] locationPoints = loc.Split(',');
                        Location location = new Location
                        {
                            LocationLongitude = float.Parse(locationPoints[0]),
                            LocationLatitude = float.Parse(locationPoints[1])
                        };
                        driver.MycurrLocation = location;
                        do
                        {
                            Console.WriteLine("1. Change Availability");
                            Console.WriteLine("2. Change Location");
                            Console.WriteLine("3. Exit as Driver");
                            string driverChoice;
                            do
                            {
                                Console.Write("Enter your choice: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                driverChoice = Console.ReadLine();
                                Console.ResetColor();
                            } while (!(driverChoice == "1" || driverChoice == "2" || driverChoice == "3"));
                            
                            if (driverChoice == "1")
                            {
                                driver.updateAvailability();
                            }
                            else if (driverChoice == "2")
                            {
                                driver.updateLocation();
                            }
                            else if (driverChoice == "3")
                            {
                                break;
                            }
                        } while (true);
                    }
                    else
                    {
                        Console.WriteLine("No Driver exists with this ID and Name");
                    }
                }
                else if (myChoice == "3")
                {
                    string adminChoice;
                    do
                    {
                        Console.WriteLine("1. Add Driver");
                        Console.WriteLine("2. Remove Driver");
                        Console.WriteLine("3. Update Driver");
                        Console.WriteLine("4. Search Driver");
                        Console.WriteLine("5. Exit as Admin");
                        do
                        {
                            Console.Write("Enter your choice: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            adminChoice = Console.ReadLine();
                            Console.ResetColor();
                            if (!(Convert.ToInt32(adminChoice) >= 1 && Convert.ToInt32(adminChoice) <= 5))
                            {
                                Console.WriteLine("You entered wrong option");
                            }

                        } while (!(Convert.ToInt32(adminChoice) >= 1 && Convert.ToInt32(adminChoice) <= 5));
                        if (adminChoice == "1")
                        {
                            admin.addDriver();
                        }
                        else if (adminChoice == "2")
                        {
                            admin.removeDriver();
                        }
                        else if (adminChoice == "3")
                        {
                            admin.updateDriver();
                        }
                        else if (adminChoice == "4")
                        {
                            admin.searchDriver();
                        }
                        else if (adminChoice == "5")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You entered wrong option");
                        }
                    } while (Convert.ToInt32(adminChoice) >= 1 && Convert.ToInt32(adminChoice) <= 5);
                }
                else if (myChoice == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter correct choice");
                }
            } while (true);
        }
    }
}