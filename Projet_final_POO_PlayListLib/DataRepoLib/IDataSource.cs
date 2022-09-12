namespace DataRepoLib;

public interface IDataSource
{
    public bool Connect();

    public void Close();
    
}