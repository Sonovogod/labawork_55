namespace LabaWork.Services.Abstract;

public interface ISectionService <T>
{
    public List<T> GetAll();
    public T? GetById(int id);
    public void Add(T? section);
    public void Delete(T? section);
    public bool IsExist(string name);
}