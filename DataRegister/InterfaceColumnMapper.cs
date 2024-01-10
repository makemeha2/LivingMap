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
    }
}
