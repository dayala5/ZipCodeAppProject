using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZipCodeAppProject.Models;

namespace ZipCodeAppProject.Services
{
    public interface IZipLookupService
    {
        Task<ZipLookupResponse?> GetZipInformationAsync(string zipCode);
    }
}
