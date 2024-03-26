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
        private const string _url = "http://localhost:5002";

        public async Task<UploadResult> SendFileToStorageService(IFormFile file)
        {
            using var client = new HttpClient();
            using var formData = new MultipartFormDataContent();
            formData.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);

            var response = await client.PostAsync(_url + "/MinioFile", formData);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to upload file to storage service");
            var result = await response.Content.ReadFromJsonAsync<UploadResult>();
            return result;
        }

        public async Task<string> GetImageBase64FromStorageService(string path)
        {
            using var client = new HttpClient();
            var response =
                await client.GetAsync($"{_url}/MinioFile?path={path}", HttpCompletionOption.ResponseHeadersRead);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to get file from storage service");

            var imageBytes = await response.Content.ReadAsByteArrayAsync();
            return Convert.ToBase64String(imageBytes);
        }
    }
}