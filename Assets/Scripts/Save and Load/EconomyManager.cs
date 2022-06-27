using UnityEngine;
using UnityEngine.UI;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager instance { get; private set; }
    public Text mainMenuWindow;

    private Data data;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SaveLoadData.instance.loadedNewData += ChangeData;
    }

    private void OnDestroy()
    {
        SaveLoadData.instance.loadedNewData -= ChangeData;
    }

    private void ChangeData(Data data)
    {
        this.data = data;
        changeText();
    }

    private void changeText()
    {
        if (mainMenuWindow)
        {
            mainMenuWindow.text = data.ToString();
        }
    }

    [ContextMenu("Increment")]
    public void Increment()
    {
        data.amountOfMoney++;
        changeText();
    }
}
