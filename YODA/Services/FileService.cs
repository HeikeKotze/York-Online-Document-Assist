using Microsoft.JSInterop;
using MimeKit;
using System.Diagnostics;

namespace YODA.Services
{
    public class FileService
    {
        private readonly IJSRuntime _jsRuntime;

        public FileService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task OpenFileInNewTabAsync(string filePath, string fileName)
        {
            try
            {
                using (FileStream fs = File.OpenRead(filePath))
                {
                    byte[] fileBytes = new byte[fs.Length];
                    await fs.ReadAsync(fileBytes, 0, (int)fs.Length);

                    var contentType = MimeTypes.GetMimeType(fileName);
                    var base64 = Convert.ToBase64String(fileBytes);
                    var url = $"data:{contentType};base64,{base64}";
                    await _jsRuntime.InvokeVoidAsync("openFileInNewTab", url);
                }
            }
            catch (Exception ex)
            {
                // Get the stack trace as a string
                string stackTrace = new StackTrace(ex).ToString();

                // Log or display the stack trace
                Console.WriteLine("Exception caught:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(stackTrace);
                throw;
            }
        }
    }
}
