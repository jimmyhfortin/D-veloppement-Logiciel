namespace Model;

public abstract class Model
{
    public string TableName { get; set; }
    public abstract void Select();
    public abstract void Delete();
    
}