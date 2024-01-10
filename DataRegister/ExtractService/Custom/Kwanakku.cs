using Persistences.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRegister.ExtractService.Custom
{
    internal class Kwanakku : IExtractService
    {
        public LocationInfo? Map(InterfaceTarget target, string[] item)
        {
            if (item == null) return null;
            if (CommonExtract.IsHeaderItem(item)) return null;

            LocationInfo rtnVal = new LocationInfo();

            rtnVal.Div = "DIV01";
            rtnVal.Area1 = target.Area1;
            rtnVal.Area2 = target.Area2;

            string dong = item[0];
            var idx = item[0].IndexOf('-');
            if (idx > 0)
            {
                dong = item[0].Substring(0, idx);
            }
            rtnVal.Area3 = dong;
            rtnVal.Address = item[1];
            rtnVal.UseYN = true;
            rtnVal.RegistDate = DateOnly.FromDateTime(DateTime.Now);

            CommonExtract.TreatmentItem(rtnVal);

            return CommonExtract.IsValidRow(rtnVal) ? rtnVal : null;
        }
    }
}
