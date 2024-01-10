﻿using Persistences.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRegister.ExtractService.Custom
{
    // [0] : 2
    // [1] : 2017-11
    // [2] : 동내면
    // [3] : 강원도 춘천시 동내면 거두리 990-8 
    // [4] : 강원도 춘천시 동내면 춘천순환로72번길 72
    // [5] : 거두리 클린하우스
    // [6] : 2022-11-28
    internal class Chuncheonsi : IExtractService
    {
        public LocationInfo? Map(InterfaceTarget target, string[] item)
        {
            if (item == null) return null;
            if (CommonExtract.IsHeaderItem(item)) return null;

            LocationInfo rtnVal = new LocationInfo();

            rtnVal.Div = target.Div;
            rtnVal.Area1 = target.Area1;
            rtnVal.Area2 = target.Area2;
            rtnVal.Area3 = item[2];
            rtnVal.Address = item[4];
            if (string.IsNullOrWhiteSpace(rtnVal.Address))
            {
                rtnVal.Address = item[3];
            }
            rtnVal.UseYN = true;
            rtnVal.RegistDate = DateOnly.FromDateTime(DateTime.Now);
            
            CommonExtract.TreatmentItem(rtnVal);

            return CommonExtract.IsValidRow(rtnVal) ? rtnVal : null;
        }
    }
}
