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
    public void BuildMinigun()
    {
        currentBuildingPlace.BuildTower(towers[0]);
    }
    public void BuildRocketLauncher()
    {
        currentBuildingPlace.BuildTower(towers[1]);
    }
    public void SellTower()
    {
        currentBuildingPlace.SellTower();
        CloseAllWindows();
    }
    public void UpgradeTower()
    {
        if (currentBuildingPlace.SpawnedTower.TowerToUpgrade == null)
        {
            Debug.Log("No more upgrades");
            CloseAllWindows();
            return;
        }
        Towers nextTower = currentBuildingPlace.SpawnedTower.TowerToUpgrade;
        currentBuildingPlace.BuildTower(nextTower);
        CloseAllWindows();
    }
    private void Init(string windowName)
    {
        TowerBuyWindow.SetActive(windowName == "TowerBuyWindow");
        if (windowName == "TowerModifyWindow")
        {
            TowerModifyWindow.SetActive(true);
            changeTextInfo();
        }
    }

    private void changeTextInfo() // TODO Необхідно придумати кращу версію відображення інформації про башню
    {

        StatsComponent towerTemp = currentBuildingPlace.SpawnedTower.GetComponent<StatsComponent>();

        towerName.text = towerTemp.TowerName;
        towerStats.text =
            $"Level: {towerTemp.LevelOfTower}\n" +
            $"Price: {towerTemp.Cost}\n" +
            $"Damage: {towerTemp.Damage}\n" +
            $"Fire rate: {towerTemp.FireRate} +  \n" +
            $"Tower radius: {towerTemp.ColliderRadius}";
        
        sellButton.text = "Sell for: " + towerTemp.Cost;
        if(towerTemp.TowerToUpgrade == null)
        {
            modifyButton.text = "No more Upgrade";
        }
        else
        {
            modifyButton.text = $"Upgrade tower for:  <color=green>{towerTemp.TowerToUpgrade.towerCost}</color>";
        }
    }

}
