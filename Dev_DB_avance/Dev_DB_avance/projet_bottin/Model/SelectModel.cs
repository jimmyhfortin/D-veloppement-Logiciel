namespace Model;

public abstract class SelectModel
{
    public string TableName { get; set; }
    public abstract void Select();
    public abstract void Delete();
}
