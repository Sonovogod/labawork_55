using LabaWork.DataObjects;
using LabaWork.Models;

namespace LabaWork.Services.Abstract;

public interface IFileService
{
    FileDataObject Download(string fileName);
    void Upload(string fileName);
    void Remove(string filename);
    string SaveFileAndGetPath(Product product, IFormFile uploadedFile);
}