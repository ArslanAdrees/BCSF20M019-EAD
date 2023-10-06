using System;

namespace VehicleDetails
{
    public class Vehicle
    {
        String type;
        String model;
        String licensePlate;
        public string VehicleType
        {
            get{return type;}
            set{type = value;} 
        }
        public string VehicleModel
        {
            get{return model;}
            set{model = value;}
        }
        public string VehicleLicensePlate
        {
            get{return licensePlate;}
            set{licensePlate = value;}        
        }
    }
}
