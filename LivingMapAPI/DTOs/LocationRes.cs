using Persistences.Models;

namespace LivingMapAPI.DTOs
{
    public class LocationRes
    {
        public LocationRes(Location location)
        {
            location = location ?? new Location();

            AddressText = location.AddressText;
            Latitude = location.Latitude;
            Longitude = location.Longitude;
            Remark = location.Remark;
            MetaAddress = location.MetaAddress;       
            Detail = location.Detail;
        }

        public string AddressText { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Remark { get; set; }

        public string MetaAddress { get; set; }

        public string Detail { get; set; }
    }
}
