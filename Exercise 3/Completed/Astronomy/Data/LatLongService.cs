using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Astronomy
{
    public class LatLongService
    {
        const string freeGeoIpServiceUrl = "http://freegeoip.net/json/";

        public async Task<(double Latitude, double Longitude)> GetLatLong()
        {
            var json = await new HttpClient().GetStringAsync(freeGeoIpServiceUrl);

            var data = JsonConvert.DeserializeObject<FreeGeoIpData>(json);

            return (data.Latitude, data.Longitude);
        }

        class FreeGeoIpData
        {
            public string Ip { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }
    }
}