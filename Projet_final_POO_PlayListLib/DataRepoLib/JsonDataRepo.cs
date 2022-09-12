using System.Text.Json;

namespace DataRepoLib;

public abstract class JsonDataRepo<TData, TKey> : IDataRepo<TData, TKey>
{
    public string FileName { get; set; }

    public JsonDataRepo(string fileName)
    {
        FileName = fileName;
    }

    public virtual bool Connect()
    {
        try
        {
            FileStream fileStream = File.OpenWrite(FileName);
            fileStream.Close();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public virtual void Close()
    {
    }


    public virtual List<TData> SelectAll()
    {
        try
        {
            string json = File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<List<TData>>(json) ?? new List<TData>();
        }
        catch (Exception)
        {
            return new List<TData>();
        }
        
    }

    public abstract TData? Select(TKey id);

    public virtual bool Insert(TData data)
    {
        List<TData> dataList = SelectAll();
        if (dataList.Find(x => x.Equals(data)) == null)
        {
            dataList.Add(data);
            return Save(dataList);
        }

        return false;
    }

    public virtual bool Update(TData data)
    {
        List<TData> dataList = SelectAll();
        if (dataList.Remove(data))
        {
            dataList.Add(data);
            return Save(dataList);
        }

        return false;
    }

    public virtual bool Delete(TData data)
    {
        List<TData> dataList = SelectAll();
        if (dataList.Remove(data))
        {
            return Save(dataList);
        }
        return false;
    }

    public abstract bool Delete(TKey key);

    public virtual bool Save(List<TData> dataList) {
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(dataList, options);
        try
        {
            File.WriteAllText(FileName, json);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}