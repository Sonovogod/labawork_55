namespace LabaWork.DataObjects;

public class FileDataObject
{
    public string FileType { get; set; }
    public string? Filename { get; set; }
    public string  Path { get; set; }
    public FileStream FileStream { get; set; }
}