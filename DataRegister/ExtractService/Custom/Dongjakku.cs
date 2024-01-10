using Persistences.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRegister.ExtractService.Custom
{
    //[0] : 132,
    //[1] : 상도1동,
    //[2] : 서울특별시 동작구 매봉로 2길 15,
    //[3] : 2023-08-22
    internal class Dongjakku : IExtractService
    {
        public LocationInfo? Map(InterfaceTarget target, string[] item)
        {
            if (item == null) return null;
            if (CommonExtract.IsHeaderItem(item)) return null;

            LocationInfo rtnVal = new LocationInfo();

            rtnVal.Div = target.Div;
            rtnVal.Area1 = target.Area1;
            rtnVal.Area2 = target.Area2;
            rtnVal.Area3 = item[1];
            rtnVal.Address = item[2];
            if(rtnVal.Address.Contains("서울 특별시"))
            {
                rtnVal.Address = rtnVal.Address.Replace("서울 특별시", "서울특별시");
            }
            rtnVal.UseYN = true;
            rtnVal.RegistDate = DateOnly.FromDateTime(DateTime.Now);

            CommonExtract.TreatmentItem(rtnVal);

            return CommonExtract.IsValidRow(rtnVal) ? rtnVal : null;
        }
    }
}
