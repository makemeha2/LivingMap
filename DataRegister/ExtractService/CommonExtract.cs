using Persistences.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRegister.ExtractService
{
    public class CommonExtract : IExtractService
    {
        public CommonExtract()
        {
        }

        public LocationInfo? Map(InterfaceTarget target, string[] item)
        {
            if (item == null) return null;
            if (IsHeaderItem(item)) return null;

            LocationInfo rtnVal = new LocationInfo();

            rtnVal.Div = target.Div;

            if (target.InterfaceTargetConfig != null) 
            {
                // AREA1
                if (target.InterfaceTargetConfig.Area1Index != null)
                {
                    rtnVal.Area1 = item[(int)target.InterfaceTargetConfig.Area1Index];
                }
                else
                {
                    rtnVal.Area1 = target.Area1;
                }

                // AREA2
                if (target.InterfaceTargetConfig.Area2Index != null)
                {
                    rtnVal.Area2 = item[(int)target.InterfaceTargetConfig.Area2Index];
                }
                else
                {
                    rtnVal.Area2 = target.Area2;
                }

                // AREA3
                if (target.InterfaceTargetConfig.Area3Index != null) {
                    rtnVal.Area3 = item[(int)target.InterfaceTargetConfig.Area3Index];
                }

                // Address
                if (target.InterfaceTargetConfig.AddressIndex != null)
                {
                    rtnVal.Address = item[(int)target.InterfaceTargetConfig.AddressIndex];
                }

                // LatitudeIndex
                if (target.InterfaceTargetConfig.LatitudeIndex != null)
                {
                    rtnVal.Address = item[(int)target.InterfaceTargetConfig.LatitudeIndex];
                }

                // LongitudeIndex
                if (target.InterfaceTargetConfig.LongitudeIndex != null)
                {
                    rtnVal.Address = item[(int)target.InterfaceTargetConfig.LongitudeIndex];
                }

                TreatmentItem(rtnVal);
            }

            return IsValidRow(rtnVal) ? rtnVal : null;
        }

        public static bool IsHeaderItem(string[] item)
        {
            string[] headerKeywords = { "연번", "의류수거함" };
            if(item == null || item.Length == 0) return true;

            return headerKeywords.Contains(item[0]);
        }

        public static bool IsValidRow(LocationInfo item)
        {
            bool isValid = true;

            if (item == null) isValid = false;
            else if (string.IsNullOrWhiteSpace(item.Area1) || string.IsNullOrWhiteSpace(item.Area2) || string.IsNullOrWhiteSpace(item.Area3)) isValid = false;
            else if(string.IsNullOrWhiteSpace(item.Address)) isValid = false;

            return isValid;
        }

        public static void TreatmentItem(LocationInfo? rtnVal)
        {
            if (rtnVal == null) return;

            rtnVal.Area1 = rtnVal.Area1.Trim();
            rtnVal.Area2 = rtnVal.Area2.Trim();
            rtnVal.Area3 = rtnVal.Area3.Trim();
            rtnVal.Address = rtnVal.Address.Trim();
        }
    }
}
