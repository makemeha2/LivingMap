using DataRegister.Services;

internal class Program
{
    // adress
    // coordinate

    private static async Task Main(string[] args)
    {
        args = ["coordinate"];

        if (args != null && args.Length > 0)
        {
            if (args[0] == "coordinate")
            {
                await CoordinateService.Run();
                
            }
            else
            {
                AddressService.Run();
            }
        }
        else
        {
            AddressService.Run();
        }
    }


        /*
        using (var context = new LivingMapContext())
        {
            var interfaceTargets = context.InterfaceTargets.Where(target => !target.CompletedIf).Include(i => i.InterfaceTargetConfig).ToList();
            //IEnumerable<LocationInfo> addingList = new List<LocationInfo>();
            Dictionary<string, LocationInfo> addingList = new Dictionary<string, LocationInfo>();

            foreach (var target in interfaceTargets)
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

                            var item = InterfaceColumnMapper.Map(target, arrRows);

                            if (item != null)
                            {
                                string jsonResponseString = await CallApi(item, "ROAD");


                                dynamic jsonObject = JsonConvert.DeserializeObject(jsonResponseString);

                                if (jsonObject.response.status == "NOT_FOUND")
                                {
                                    jsonResponseString = await CallApi(item, "parcel");
                                    jsonObject = JsonConvert.DeserializeObject(jsonResponseString);
                                }

                                if (jsonObject.response.status == "OK")
                                {
                                    item.Latitude = Convert.ToDouble(jsonObject.response.result.point.x);
                                    item.Longitude = Convert.ToDouble(jsonObject.response.result.point.y);
                                }

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
    */
        /*
        private static async Task<string> CallApi(LocationInfo? item, string apiSearchType)
        {
            string jsonResponseString = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                HttpResponseMessage response = await client.GetAsync(GetApiUrlString(item, apiSearchType));
                response.EnsureSuccessStatusCode();
                jsonResponseString = await response.Content.ReadAsStringAsync();
            }

            return jsonResponseString;
        }

        private static string GetApiUrlString(LocationInfo? item, string addressSearchType)
        {
            string apikey = ConfigurationManager.AppSettings["vworld_apikey"];

            string searchType = "parcel";
            if (addressSearchType == "ROAD")
            {
                searchType = "ROAD";
            }

            string searchAddr = item.Address;
            string epsg = "epsg:4326";

            StringBuilder sb = new StringBuilder("https://api.vworld.kr/req/address");
            sb.Append("?service=address");
            sb.Append("&request=getCoord");
            sb.Append("&format=json");
            sb.Append("&crs=" + epsg);
            sb.Append("&key=" + apikey);
            sb.Append("&type=" + searchType);
            sb.Append("&address=" + searchAddr);

            return sb.ToString();
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
        */
    }