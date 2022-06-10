using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlace : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] ControllerComponent spawnedTower;
    public ControllerComponent SpawnedTower => spawnedTower;
    private UINode nodeUI;
    private bool placeEmpty = true;
    [SerializeField] AudioClip audioBuildedTower;

    private void Start()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("NodeUI");
        if (gameObjects[0]) { nodeUI = gameObjects[0].GetComponent<UINode>(); }
        else Debug.LogError("Не найдено об'єктів з тегом NodeUI");
        if (gameObjects.Length > 1) Debug.LogError("Найдено два об'єки з тегом NodeUI");


    }
    public void OnPointerClick(PointerEventData eventData)
    {
        nodeUI.Choosed(this, placeEmpty ? "TowerBuyWindow" : "TowerModifyWindow");
    }

    public void BuildTower(Towers tower)
    {

        if (!CheckIfEnoughMoney(tower)) return;
        if (spawnedTower != null) Destroy(spawnedTower.gameObject);
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, -0.5f);
        GameObject temp = Instantiate(tower.towerToSpawn, pos, Quaternion.identity);
        temp.GetComponent<ControllerComponent>().Init(tower);
        spawnedTower = temp.GetComponent<ControllerComponent>();
        ResourceManagment.instance.UseMoney(spawnedTower);
        placeEmpty = false;
        nodeUI.CloseAllWindows();
        if (AudioSingletone.instance) AudioSingletone.instance.PlaySound(audioBuildedTower);

    }

    public bool CheckIfEnoughMoney(Towers tower)
    {
        if (ResourceManagment.instance.Money >= tower.towerCost) return true;
        return false;
    }

    public void SellTower()
    {
        ResourceManagment.instance.SellTower(spawnedTower);
        Destroy(spawnedTower.gameObject);
        spawnedTower = null;
        placeEmpty = true;
    }
}
