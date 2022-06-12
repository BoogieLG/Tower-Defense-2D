using System.IO;
using UnityEngine;

public class SaveLoadRepository : MonoBehaviour
{
    private Data data;
    private JsonData jsonData;

    private const string folderName = "saveData";
    private const string fileName = "data.dat";
    private readonly string path;

    public SaveLoadRepository()
    {
        jsonData = new JsonData();
        path = Path.Combine(Application.dataPath, folderName);
    }

    public void Save(Data data)
    {
        this.data = data;
        if (!Directory.Exists(Path.Combine(path)))
        {
            Directory.CreateDirectory(path);
        }
        Data saveData = new Data
        {
            amountOfMoney = data.amountOfMoney
        };
        jsonData.Save(saveData, Path.Combine(path, fileName));
    }

    public Data Load()
    {
        data = jsonData.Load(Path.Combine(path, fileName));
        Debug.Log($"Loaded: {data.amountOfMoney}");
        return data;
    }
}
