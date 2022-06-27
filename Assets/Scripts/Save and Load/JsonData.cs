using System;
using System.IO;
using UnityEngine;

[Serializable]
public class JsonData
{

    public void Save(Data data, string path)
    {
        var str = JsonUtility.ToJson(data);
        Debug.Log(str);
        File.WriteAllText(path, str);
    }

    public Data Load(string path)
    {
        if (File.Exists(path))
        {
            var str = File.ReadAllText(path);

            return JsonUtility.FromJson<Data>(str);
        }
        return null;
    }

}
