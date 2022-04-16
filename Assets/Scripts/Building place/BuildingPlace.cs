using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlace : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] List<Towers> towers;
    [SerializeField] StatsComponent spawnedTower;
    public StatsComponent SpawnedTower => spawnedTower;
    private UINode nodeUI;
    private bool placeEmpty = true;

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

    public void BuildTower(string towersName)
    {
        foreach (Towers tower in towers)
        {
            if (tower.towerName == towersName)
            {
                if(!CheckIfEnoughMoney(tower)) return;
                if (spawnedTower != null) Destroy(spawnedTower.gameObject);
                Vector3 pos = new Vector3(transform.position.x, 0.5f, transform.position.z);
                GameObject temp = Instantiate(tower.towerToSpawn,pos,Quaternion.identity);
                temp.GetComponent<ControllerComponent>().Init(tower);
                spawnedTower = temp.GetComponent<StatsComponent>();
                ResourceManagment.instance.UseMoney(spawnedTower);
                placeEmpty = false;
                nodeUI.CloseAllWindows();
            }
        }
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
