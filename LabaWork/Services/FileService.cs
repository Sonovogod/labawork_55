using LabaWork.DataObjects;
using LabaWork.Models;
using LabaWork.Services.Abstract;

namespace LabaWork.Services;

public class FileService : IFileService
{
    private readonly IHostEnvironment _hostEnvironment;
    public FileService(IHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    public FileDataObject Download(string filename)
    {
        var contentRootPAth = _hostEnvironment.ContentRootPath;
        var filePath = @$"{contentRootPAth}/ProductFiles/{filename}";
        if (!File.Exists(filePath))
            throw new Exception("Файл не найден");
        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return new FileDataObject
        {
            Path = filePath,
            FileType = "text/plain",
            FileStream = fileStream
        };
    }

    public void Upload(string fileName)
    {
        var path = Path.Combine(_hostEnvironment.ContentRootPath, $"ProductFiles/{fileName}");
        string directoryPath = Path.Combine(_hostEnvironment.ContentRootPath, "ProductFiles");
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);
        var stream = File.Create(path);
        stream.Close();
        File.WriteAllText(path, "Content");
    }

    public void Remove(string filename)
    {
        var contentRootPAth = _hostEnvironment.ContentRootPath;
        var filePath = @$"{contentRootPAth}/ProductFiles/{filename}";
        if (!File.Exists(filePath))
            throw new Exception("Файл не найден");
        File.Delete(filePath);
    }

    public string SaveFileAndGetPath(Product product, IFormFile? uploadedFile)
    {
        if (uploadedFile != null)
        {
            string fileName = uploadedFile.FileName;
            string path =Path.Combine(_hostEnvironment.ContentRootPath, $"wwwroot/Files/Img/{fileName}");
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                uploadedFile.CopyTo(fileStream);
            }
            return $"/Files/Img/{fileName}";
        }

        return string.Empty;
    }
}