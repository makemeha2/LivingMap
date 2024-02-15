using Microsoft.EntityFrameworkCore;
using Persistences;
using Persistences.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRegister.Services
{
    public class AddressService
    {
        public static void Run()
        {
            using (var context = new LivingMapDBContext())
            {
                var targetList = context.AddrExtrInfos.Where(i => !i.IfsuccessYn).Include(p => p.AdmCode).ToList();

                Dictionary<string, ExtractAddress> addingList = new Dictionary<string, ExtractAddress>();

                foreach (AddrExtrInfo target in targetList)
                {
                    if (string.IsNullOrEmpty(target.FilePath)) continue;

                    var fileInfo = new FileInfo(target.FilePath);
                    if (fileInfo.Exists)
                    {
                        var encodeCodePage = 51949;
                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                        using (StreamReader sr = new StreamReader(target.FilePath, Encoding.GetEncoding(encodeCodePage), false))
                        {
                            while (sr.Peek() >= 0)
                            {
                                string? line = sr.ReadLine();

                                string[] arrRows = line?.Split(',');

                                var item = Extractor.Map(target, arrRows);

                                if(item != null)
                                {
                                    addingList.TryAdd(item.Div + "_" + item.AddressText, item);
                                }
                            }
                        }
                    }

                    target.IfsuccessYn = true;
                    target.Ifdate = DateOnly.FromDateTime(DateTime.Now);
                }

                context.BulkMerge(addingList.Values);
                context.BulkSaveChanges();
            }
        }
    }
}
