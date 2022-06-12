using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadData : MonoBehaviour
{
    public static SaveLoadData instance { get; private set; }

    public Data data;
    public Text mainMenuWindow;
    private SaveLoadRepository saveLoadRepository;

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
        AddAllDelegates();
        changeText();
    }

    private void AddAllDelegates()
    {
        changedDataAlerm += changeText;
    }
    private void DeleteAllDelegates()
    {
        changedDataAlerm -= changeText;
    }

    [ContextMenu("Save")]
    public void Save()
    {
        saveLoadRepository.Save(data);
    }
    [ContextMenu("Load")]
    public void Load()
    {
        data = saveLoadRepository.Load();
    }
    public Action changedDataAlerm; 
    public void ChangeData(Data data)
    {
        this.data = data;
        Save();
        changedDataAlerm.Invoke();
    }
    private void changeText()
    {
        if (mainMenuWindow)
        {
            mainMenuWindow.text = data.ToString();
        }
    }

    private void OnDestroy()
    {
        DeleteAllDelegates();
    }
}
