using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINode : MonoBehaviour
{
    [SerializeField] List<Towers> towers;

    [SerializeField] GameObject TowerBuyWindow;
    [SerializeField] GameObject TowerModifyWindow;
    [SerializeField] GameObject CloseButtonCanvas;

    [SerializeField] Text towerName;
    [SerializeField] Text towerStats;
    [SerializeField] Text modifyButton;
    [SerializeField] Text sellButton;

    [SerializeField] List<Text> buyButtons;

    private BuildingPlace currentBuildingPlace;
    public void Choosed(BuildingPlace gameObject, string windowName)
    {
        currentBuildingPlace = gameObject;
        Init(windowName);
        CloseButtonCanvas.SetActive(true);
    }

    public void CloseAllWindows()
    {
        TowerBuyWindow.SetActive(false);
        TowerModifyWindow.SetActive(false);
        CloseButtonCanvas.SetActive(false);
        currentBuildingPlace = null;
    }
    public void BuildTower(Text obj)
    {
        string nameOfTower = obj.text;
        Towers tower = towers.Find(x => x.towerName == nameOfTower);
        if (tower == null) return;
        currentBuildingPlace.BuildTower(tower);
    }
    public void SellTower()
    {
        currentBuildingPlace.SellTower();
        CloseAllWindows();
    }
    public void UpgradeTower()
    {
        if (currentBuildingPlace.SpawnedTower.Tower.nextTowerForUpgrade == null)
        {
            Debug.Log("No more upgrades");
            CloseAllWindows();
            return;
        }
        Towers nextTower = currentBuildingPlace.SpawnedTower.Tower.nextTowerForUpgrade;
        currentBuildingPlace.BuildTower(nextTower);
        CloseAllWindows();
    }
    private void Init(string windowName)
    {
        if (windowName == "TowerBuyWindow") 
        {
            TowerBuyWindow.SetActive(true);
            changeBuyInfo();

        }
        if (windowName == "TowerModifyWindow")
        {
            TowerModifyWindow.SetActive(true);
            changeModifyInfo();
        }
    }

    private void changeModifyInfo() // TODO Необхідно придумати кращу версію відображення інформації про башню
    {

        Towers towerTemp = currentBuildingPlace.SpawnedTower.GetComponent<ControllerComponent>().Tower;

        towerName.text = towerTemp.towerName;
        towerStats.text =
            $"Level: {towerTemp.levelOfTower}\n" +
            $"Price: {towerTemp.towerCost}\n" +
            $"Damage: {towerTemp.damage}\n" +
            $"Fire rate: {towerTemp.fireRate} \n" +
            $"Tower radius: {towerTemp.colliderRadius}";

        sellButton.text = "Sell for: " + towerTemp.towerCost;
        if (towerTemp.nextTowerForUpgrade == null)
        {
            modifyButton.text = "No more Upgrade";
        }
        else
        {
            modifyButton.text = $"Upgrade tower for:  <color=green>{towerTemp.nextTowerForUpgrade.towerCost}</color>";
        }
    }
    private void changeBuyInfo()
    {
        foreach(Text text in buyButtons)
        {
            text.transform.parent.gameObject.SetActive(false);
        }
        for (int i = 0; i < towers.Count ; i++)
        {
            buyButtons[i].transform.parent.gameObject.SetActive(true);
            buyButtons[i].text = towers[i].towerName/* + "\n" + $"<color=green> {towers[i].towerCost} </color>"*/;
        }
    }
}
