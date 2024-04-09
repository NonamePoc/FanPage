using System.Data.Entity.Core.Metadata.Edm;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.Helper
{
    public interface IStorageHttp
    {
        Task<UploadResult> SendFileToStorageService(IFormFile file);
        Task<string> GetImageBase64FromStorageService(string path);
    }

    public class StorageHttp : IStorageHttp
    {
        private const string _url = "https://zkdmv48c-5002.euw.devtunnels.ms";

        public async Task<UploadResult> SendFileToStorageService(IFormFile file)
        {
            using var client = new HttpClient();
            using var formData = new MultipartFormDataContent();
            var fileExtension = Path.GetExtension(file.FileName);

            formData.Add(
                new StreamContent(file.OpenReadStream()),
                "file",
                file.FileName + fileExtension
            );
            var response = await client.PostAsync(_url + "/MinioFile", formData);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to upload file to storage service");
            var result = await response.Content.ReadFromJsonAsync<UploadResult>();
            return result;
        }

        public async Task<string> GetImageBase64FromStorageService(string path)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(
                $"{_url}/MinioFile?path={path}",
                HttpCompletionOption.ResponseHeadersRead
            );

            if (!response.IsSuccessStatusCode)
                return "";

            var imageBytes = await response.Content.ReadAsByteArrayAsync();
            return Convert.ToBase64String(imageBytes);
        }
    }
}
