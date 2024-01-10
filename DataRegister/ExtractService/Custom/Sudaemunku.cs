using Persistences.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRegister.ExtractService.Custom
{
    //[0] : 75,
    //[1] : 75-지,
    //[2] : 지체장애인협회,
    //[3] : 홍제1동,
    //[4] : 홍제내2라길13
    internal class Sudaemunku : IExtractService
    {
        public LocationInfo? Map(InterfaceTarget target, string[] item)
        {
            if (item == null) return null;
            if (CommonExtract.IsHeaderItem(item)) return null;

            LocationInfo rtnVal = new LocationInfo();

            rtnVal.Div = target.Div;
            rtnVal.Area1 = target.Area1;
            rtnVal.Area2 = target.Area2;
            rtnVal.Area3 = item[3];
            rtnVal.Address = $"{rtnVal.Area1} {rtnVal.Area2} {item[4]}";
            rtnVal.UseYN = true;
            rtnVal.RegistDate = DateOnly.FromDateTime(DateTime.Now);

            CommonExtract.TreatmentItem(rtnVal);

            return CommonExtract.IsValidRow(rtnVal) ? rtnVal : null;
        }
    }
}
