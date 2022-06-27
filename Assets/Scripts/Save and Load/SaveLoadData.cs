using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadData : MonoBehaviour
{
    public static SaveLoadData instance { get; private set; }

    private Data data;

    private SaveLoadRepository saveLoadRepository;

    public Action<Data> loadedNewData;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        saveLoadRepository = new SaveLoadRepository();
        Load();
    }

    [ContextMenu("Save")]
    private void Save()
    {
        saveLoadRepository.Save(data);
    }
    [ContextMenu("Load")]
    private void Load()
    {
        data = saveLoadRepository.Load();
        if (data == null)
        {
            Debug.Log("No recods found, created new.");
            data = new Data();
        }
        loadedNewData.Invoke(data);
    }
}
