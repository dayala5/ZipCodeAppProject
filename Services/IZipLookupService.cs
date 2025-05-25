using ZipCodeAppProject.Models;

namespace ZipCodeAppProject.Services
{
    public interface IZipLookupService
    {
        Task<ZipLookupResponse?> GetZipInformationAsync(string zipCode);
    }
}
