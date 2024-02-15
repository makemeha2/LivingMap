
using LivingMapAPI.DTOs;
using Persistences;
using Persistences.Models;

namespace LivingMapAPI.Services
{
    public class LivingMapService
    {
        public List<Coordinate> GetCoordinatesByLevel2(string divText, string areaLevel2)
        {
            List<Coordinate> rtnVal = [];

            string div = "";
            // divText 를 통해 div 값 받아오기
            switch (divText.ToUpper())
            {
                case "CLOTHES":
                    div = "DIV01";
                    break;
                case "BATTERY":
                    div = "DIV02";
                    break;
                case "SMOKE":
                    div = "DIV03";
                    break;
                default:
                    break;
            }

            using(var context = new LivingMapDBContext())
            {
                rtnVal = context.Locations.Where(location => 
                    location.Div == div &&
                    location.Level2 == areaLevel2 && 
                    location.UseYn && 
                    location.SuccessYn).Select(i => new Coordinate(i.Latitude, i.Longitude)).ToList();
            }

            return rtnVal;
        }

        public Location? GetLocationByCoord(Coordinate coord)
        {
            using(var context = new LivingMapDBContext())
            {
                return context.Locations.Where(location =>
                                   location.Latitude == coord.X &&
                                                      location.Longitude == coord.Y).FirstOrDefault();
            }
            
        }

        public int RegisterCompliant(ComplaintReq complaintReq)
        {
                using (var context = new LivingMapDBContext())
                {
                    // 사용자가 차단된 사용자인지 여부를 확인하는 로직이 필요함 

                    Complaint complaint = new Complaint();
                    complaint.Div = complaintReq.Div;
                    complaint.AddressText = complaintReq.AddressText;
                    complaint.UserInfo = complaintReq.UserInfo;
                    complaint.UserType = complaintReq.UserType;
                    complaint.ComplaintType = complaintReq.ComplaintType;
                    complaint.Description = complaintReq.Description;
                    complaint.CreateDate = DateOnly.FromDateTime(DateTime.Now);

                    context.Complaints.Add(complaint);
                    return context.SaveChanges();
                }
        }
    }
}
