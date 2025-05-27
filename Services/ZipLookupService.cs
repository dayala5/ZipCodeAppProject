using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ZipCodeAppProject.Models;

namespace ZipCodeAppProject.Services
{


    public class ZipLookupService(HttpClient client) : IZipLookupService
    {
        private readonly HttpClient _client = client;

        public async Task<ZipLookupResponse?> GetZipInformationAsync(string zipCode)
        {
            //Zippopotam API given in the project description
            var url = $"https://api.zippopotam.us/us/{zipCode}";

            try
            {
                var response = await _client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ZipLookupResponse>(content);
                }
                else //API returns 404 not found if zip code isn't in its database
                {
                    return null;
                }
            }
            catch(HttpRequestException e)
            {
                System.Diagnostics.Debug.WriteLine("API call was not successful: " + e.Message);
                return null;
            }

        }

    }
}
