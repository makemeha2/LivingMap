using DataRegister.Models;
using Newtonsoft.Json;
using Persistences;
using Persistences.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataRegister.Services
{
    public class CoordinateService
    {
        public async static Task Run()
        {
            using(var context = new LivingMapContext())
            {
                var addressTargets = context.ExtractAddresses.ToList();
                var locations = context.Locations.ToList().ToDictionary(k => $"{k.Div}_{k.AddressText}" , v => v);

                foreach(var target in addressTargets)
                {
                    string key = $"{target.Div}_{target.AddressText}";

                    locations.TryGetValue(key, out var existItem);

                    if (existItem == null)
                    {
                        string jsonResponseString = await CallApi(target, "ROAD");

                        CoordinateAPIResponse response = JsonConvert.DeserializeObject<CoordinateAPIResponse>(jsonResponseString);

                        if (response != null)
                        {
                            if (response.Response.Status == "NOT_FOUND")
                            {
                                jsonResponseString = await CallApi(target, "parcel");
                                response = JsonConvert.DeserializeObject<CoordinateAPIResponse>(jsonResponseString);
                            }

                            if (response.Response.Status == "OK")
                            {
                                Location item = new Location();
                                item.Div = target.Div;
                                item.AddressText = target.AddressText;
                                item.Latitude = Convert.ToDouble(response.Response.Result.Point.X);
                                item.Longitude = Convert.ToDouble(response.Response.Result.Point.Y);
                                item.SuccessYn = true;
                                item.UseYn = true;
                                item.CreateDate = DateTime.Now;
                                item.MetaAddress = response.Response.Refined.Text;
                                item.ManualYn = false;
                                item.Remark = string.Empty;

                                item.Level0 = response.Response.Refined.Structure.Level0;
                                item.Level1 = response.Response.Refined.Structure.Level1;
                                item.Level2 = response.Response.Refined.Structure.Level2;
                                item.Level3 = response.Response.Refined.Structure.Level3;
                                item.Level4L = response.Response.Refined.Structure.Level4L;
                                item.Level4Lc = response.Response.Refined.Structure.Level4LC;
                                item.Level4A = response.Response.Refined.Structure.Level4A;
                                item.Level5 = response.Response.Refined.Structure.Level5;
                                item.Detail = response.Response.Refined.Structure.Detail;

                                locations.Add($"{item.Div}_{item.AddressText}", item);

                                context.Locations.Add(item);
                                await context.SaveChangesAsync();
                            }
                            else
                            {
                                Location item = new Location();
                                item.Div = target.Div;
                                item.AddressText = target.AddressText;
                                item.Latitude = -999;
                                item.Longitude = -999;
                                item.SuccessYn = false;
                                item.UseYn = false;
                                item.CreateDate = DateTime.Now;
                                item.ManualYn = false;
                                item.Remark = string.Empty;

                                locations.Add($"{item.Div}_{item.AddressText}", item);

                                context.Locations.Add(item);
                                await context.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
        }

        private static async Task<string> CallApi(ExtractAddress? item, string apiSearchType)
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

        private static string GetApiUrlString(ExtractAddress? item, string addressSearchType)
        {
            if (item == null) return string.Empty;

            string apikey = ConfigurationManager.AppSettings["vworld_apikey"];

            string searchType = "parcel";
            if (addressSearchType == "ROAD")
            {
                searchType = "ROAD";
            }

            string searchAddr = item.AddressText;
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
    }
}
