using DataRegister;
using Persistences;
using Persistences.Models;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new LivingMapContext())
        {
            var interfaceTargets = context.InterfaceTargets.Where(target => !target.CompletedIf).ToList();
            //IEnumerable<LocationInfo> addingList = new List<LocationInfo>();
            Dictionary<string, LocationInfo> addingList = new Dictionary<string, LocationInfo>();

            foreach (var target in interfaceTargets)
            {
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

                            var item = InterfaceColumnMapper.Map(target, arrRows);

                            if (item != null)
                            {
                                addingList.TryAdd(item.Address, item);
                            }
                        }
                    }

                    target.CompletedIf = true;
                    target.Ifdate = DateOnly.FromDateTime(DateTime.Now);
                }
            }

            //context.LocationInfos.AddRange(addingList.Values);
            context.BulkMerge(addingList.Values);
            context.BulkSaveChanges();
        }
    }

    private static bool IsValidRow(string[] rows)
    {
        bool isValid = true;

        if (rows.Length != 6) isValid = false;
        else if (!double.TryParse(rows[3], out _)) isValid = false;
        else if (!double.TryParse(rows[4], out _)) isValid = false;
        else if (!DateOnly.TryParse(rows[5], out _)) isValid = false;

        return isValid;
    }
}