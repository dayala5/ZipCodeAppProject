using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZipCodeAppProject.Models;

namespace ZipCodeAppProject.Services
{


    public class ZipLookupService : IZipLookupService
    {
        private readonly HttpClient _client = new();

        public async Task<ZipLookupResponse?> GetZipInformationAsync(string zipCode)
        {
            var url = $"https://api.zippopotam.us/us/{zipCode}";

            try
            {
                var response = await _client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine(content);
                    var result = JsonConvert.DeserializeObject<ZipLookupResponse>(content);
                    System.Diagnostics.Debug.WriteLine(result);

                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("API call was not successful: " + e.Message);
                return null;
            }

            
        }

    }
}
