using DataRegister.ExtractService;
using Persistences.Models;

namespace DataRegister
{
    internal class InterfaceColumnMapper
    {
        public InterfaceColumnMapper() { }

        public static LocationInfo? Map(InterfaceTarget target, string[] item)
        {
            if (target == null || target.InterfaceTargetConfig == null) return null;

            LocationInfo rtnVal = null;

            if (target.InterfaceTargetConfig.ExtractType == ExtractType.Auto)
            {
                rtnVal = new CommonExtract().Map(target, item);
            }
            else if(target.InterfaceTargetConfig.ExtractType == ExtractType.Custom)
            {
                string objectToInstantiate = $"{target.InterfaceTargetConfig.ExtractFuncName}";

                var objectType = Type.GetType(objectToInstantiate);

                var instantiatedObject = Activator.CreateInstance(objectType);

                rtnVal = (instantiatedObject as IExtractService).Map(target, item);
            }

            return rtnVal;
        }

        //private static void TreatmentItem(LocationInfo? rtnVal)
        //{
        //    if (rtnVal == null) return;

        //    rtnVal.Area1 = rtnVal.Area1.Trim();
        //    rtnVal.Area2 = rtnVal.Area2.Trim();
        //    rtnVal.Area3 = rtnVal.Area3.Trim();
        //    rtnVal.Address = rtnVal.Address.Trim();
        //}

        //public static LocationInfo MapType1(InterfaceTarget target, string[] item)
        //{
        //    if (item == null) return null;
        //    if (item[0] == "연번") return null;

        //    LocationInfo rtnVal = new LocationInfo();

        //    rtnVal.Div = "DIV01";
        //    rtnVal.Area1 = target.Area1;
        //    rtnVal.Area2 = target.Area2;
        //    rtnVal.Area3 = item[2];
        //    rtnVal.Address = item[4];
        //    if (string.IsNullOrWhiteSpace(rtnVal.Address))
        //    {
        //        rtnVal.Address = item[3];
        //    }
        //    rtnVal.UseYN = true;
        //    rtnVal.RegistDate = DateOnly.FromDateTime(DateTime.Now);

        //    if (string.IsNullOrWhiteSpace(rtnVal.Address)) return null;

        //    return rtnVal;
        //}

        //public static LocationInfo MapType2(InterfaceTarget target, string[] item)
        //{
        //    if (item == null) return null;
        //    if (item[1] == "위치") return null;

        //    LocationInfo rtnVal = new LocationInfo();

        //    rtnVal.Div = "DIV01";
        //    rtnVal.Area1 = target.Area1;
        //    rtnVal.Area2 = target.Area2;

        //    string dong = item[0];
        //    var idx = item[0].IndexOf('-');
        //    if (idx > 0)
        //    {
        //        dong = item[0].Substring(0, idx);
        //    }
        //    rtnVal.Area3 = dong;
        //    rtnVal.Address = item[1];
        //    rtnVal.UseYN = true;
        //    rtnVal.RegistDate = DateOnly.FromDateTime(DateTime.Now);

        //    if (string.IsNullOrWhiteSpace(rtnVal.Address)) return null;

        //    return rtnVal;
        //}

        //public static LocationInfo MapType3(InterfaceTarget target, string[] item)
        //{
        //    if (item == null) return null;
        //    if (item[0] == "연번") return null;

        //    LocationInfo rtnVal = new LocationInfo();

        //    rtnVal.Div = "DIV01";
        //    rtnVal.Area1 = target.Area1;
        //    rtnVal.Area2 = target.Area2;
        //    rtnVal.Area3 = item[1];
        //    rtnVal.Address = item[2];
        //    rtnVal.UseYN = true;
        //    rtnVal.RegistDate = DateOnly.FromDateTime(DateTime.Now);

        //    if (string.IsNullOrWhiteSpace(rtnVal.Address)) return null;

        //    return rtnVal;
        //}

        //public static LocationInfo MapType4(InterfaceTarget target, string[] item)
        //{
        //    if (item == null) return null;
        //    if (item[0] == "연번") return null;

        //    LocationInfo rtnVal = new LocationInfo();

        //    rtnVal.Div = "DIV01";
        //    rtnVal.Area1 = target.Area1;
        //    rtnVal.Area2 = target.Area2;
        //    rtnVal.Area3 = item[3];
        //    rtnVal.Address = item[4];
        //    rtnVal.UseYN = true;
        //    rtnVal.RegistDate = DateOnly.FromDateTime(DateTime.Now);

        //    if (string.IsNullOrWhiteSpace(rtnVal.Address)) return null;

        //    return rtnVal;
        //}
    }
}
