using Persistences.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRegister.ExtractService
{
    public interface IExtractService
    {
        LocationInfo? Map(InterfaceTarget target, string[] item);
    }
}
