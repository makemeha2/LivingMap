using Persistences.Models;

namespace DataRegister.Services
{
    public class Extractor
    {
        public static ExtractAddress? Map(AddrExtrInfo? mapInfo, string[]? item)
        {
            if(mapInfo == null) return null;

            ExtractAddress rtnVal = null;

            if (mapInfo.ExtractType == "Auto")
            {
                rtnVal = CommonMap(mapInfo, item);
            }
            else if (mapInfo.ExtractType == "Custom")
            {
                rtnVal = (mapInfo.Area1Code, mapInfo.Area2Code) switch
                {
                    ("32", "010") => Chuncheonsi(mapInfo, item),    // 춘천시
                    ("11", "200") => Dongjakku(mapInfo, item),      // 동작구
                    ("11", "130") => Sudaemunku(mapInfo, item),     // 서대문구
                    _ => null,
                };
            }

            TreatmentItem(rtnVal);

            return IsValidResult(rtnVal) ? rtnVal : null; 
        }

        public static ExtractAddress? CommonMap(AddrExtrInfo mapInfo, string[]? item)
        {
            if (item == null) return null;
            if (IsInvalidItem(item)) return null;

            ExtractAddress rtnVal = new ExtractAddress();

            rtnVal.Div = mapInfo.Div;
            rtnVal.AddressText = item[mapInfo?.AddressIndex??0];
            rtnVal.Area1Code = mapInfo?.Area1Code ?? string.Empty;
            rtnVal.Area2Code = mapInfo?.Area2Code ?? string.Empty;

            return rtnVal;
        }

        private static bool IsInvalidItem(string[] item)
        {
            string[] headerKeywords = { "연번", "의류수거함" };
            if (item == null || item.Length == 0) return true;

            return headerKeywords.Contains(item[0]);
        }

        private static bool IsValidResult(ExtractAddress? item)
        {
            bool isValid = true;

            if (item == null) isValid = false;
            else if (string.IsNullOrWhiteSpace(item.AddressText)) isValid = false;

            return isValid;
        }

        private static void TreatmentItem(ExtractAddress? rtnVal)
        {
            if (rtnVal == null) return;

            rtnVal.AddressText = rtnVal.AddressText.Trim();
        }

        #region Custom Methods 

        public static ExtractAddress? Chuncheonsi(AddrExtrInfo mapInfo, string[]? item)
        {
            // [0] : 2
            // [1] : 2017-11
            // [2] : 동내면
            // [3] : 강원도 춘천시 동내면 거두리 990-8 
            // [4] : 강원도 춘천시 동내면 춘천순환로72번길 72
            // [5] : 거두리 클린하우스
            // [6] : 2022-11-28

            if (item == null) return null;
            if (IsInvalidItem(item)) return null;

            ExtractAddress rtnVal = new ExtractAddress();

            rtnVal.Div = mapInfo.Div;
            rtnVal.AddressText = item[4];
            if (string.IsNullOrWhiteSpace(rtnVal.AddressText))
            {
                rtnVal.AddressText = item[3];
            }
            rtnVal.Area1Code = mapInfo?.Area1Code ?? string.Empty;
            rtnVal.Area2Code = mapInfo?.Area2Code ?? string.Empty;

            return rtnVal;
        }

        public static ExtractAddress? Dongjakku(AddrExtrInfo mapInfo, string[]? item)
        {
            //[0] : 132,
            //[1] : 상도1동,
            //[2] : 서울특별시 동작구 매봉로 2길 15,
            //[3] : 2023-08-22

            if (item == null) return null;
            if (IsInvalidItem(item)) return null;

            ExtractAddress rtnVal = new ExtractAddress();

            rtnVal.Div = mapInfo.Div;
            rtnVal.AddressText = item[2];
            if (rtnVal.AddressText.Contains("서울 특별시"))
            {
                rtnVal.AddressText = rtnVal.AddressText.Replace("서울 특별시", "서울특별시");
            }

            rtnVal.Area1Code = mapInfo?.Area1Code ?? string.Empty;
            rtnVal.Area2Code = mapInfo?.Area2Code ?? string.Empty;

            return rtnVal;
        }

        public static ExtractAddress? Sudaemunku(AddrExtrInfo mapInfo, string[]? item)
        {
            //[0] : 75,
            //[1] : 75-지,
            //[2] : 지체장애인협회,
            //[3] : 홍제1동,
            //[4] : 홍제내2라길13

            if (item == null) return null;
            if (IsInvalidItem(item)) return null;

            if (mapInfo.AdmCode == null) return null;

            ExtractAddress rtnVal = new ExtractAddress();

            rtnVal.Div = mapInfo.Div;
            rtnVal.AddressText = $"{mapInfo.AdmCode.Area1Name} {mapInfo.AdmCode.Area2Name} {item[4]}";
            rtnVal.Area1Code = mapInfo?.Area1Code ?? string.Empty;
            rtnVal.Area2Code = mapInfo?.Area2Code ?? string.Empty;

            return rtnVal;
        }

        #endregion
    }
}
