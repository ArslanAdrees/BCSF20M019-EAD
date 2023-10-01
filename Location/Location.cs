using System;

namespace LocationDetails
{
    public class Location
    {
        float latitude;
        float longitude;
        public float LocationLatitude
        {
            get { return latitude; }
            set { latitude = value; }
   
        }
        public float LocationLongitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        public void setLocation(float longi, float lati)
        {
            longitude = longi;
            latitude = lati;
        }
    }
}
