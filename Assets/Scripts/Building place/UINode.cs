using UnityEngine;
using UnityEngine.UI;

public class UINode : MonoBehaviour
{
    [SerializeField] Transform objTransform;
    [SerializeField] GameObject TowerBuyWindow;
    [SerializeField] GameObject TowerModifyWindow;
    [SerializeField] GameObject CloseButtonCanvas;

    [SerializeField] Text towerInfo;
    [SerializeField] Text sellButtonInfo;
    [SerializeField] Text buyButtonInfo;
    [SerializeField] Text modifyButtonInfo;

    private BuildingPlace currentBuildingPlace;
    public void Choosed(BuildingPlace gameObject, string windowName)
    {
        currentBuildingPlace = gameObject;
        objTransform.position = gameObject.GetComponent<Transform>().position;
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
        currentBuildingPlace.BuildTower("Minigun-1");
    }
    public void BuildRocketLauncher()
    {
        currentBuildingPlace.BuildTower("RocketLauncher-1");
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
        string nextTower = currentBuildingPlace.SpawnedTower.TowerToUpgrade.towerName;
        currentBuildingPlace.BuildTower(nextTower);
        CloseAllWindows();
    }
    private void Init(string windowName)
    {
        TowerBuyWindow.SetActive(windowName == "TowerBuyWindow");
        if (windowName == "TowerModifyWindow")
        {
            TowerModifyWindow.SetActive(true);
            Button modifyBtn = modifyButtonInfo.GetComponentInParent<Button>();
            changeTextInfo();
        }
    }

    private void changeTextInfo() // TODO Необхідно придумати кращу версію відображення інформації про башню
    {

        StatsComponent towerTemp = currentBuildingPlace.SpawnedTower.GetComponent<StatsComponent>();
        towerInfo.text =
            $"Tower info:" +
            $"Tower: {towerTemp.TowerName}\n" +
            $"Description: {towerTemp.ShortDiscription}\n" +
            $"Price: {towerTemp.Cost}\n" +
            $"Damage: {towerTemp.Damage}\n" +
            $"Fire rate: {towerTemp.FireRate}\n" +
            $"Tower radius: {towerTemp.ColliderRadius}";
        sellButtonInfo.text = "Sell for: " + towerTemp.SellingCost;
        if(towerTemp.TowerToUpgrade == null)
        {
            modifyButtonInfo.text = "No more Upgrade";
        }
        else
        {
            modifyButtonInfo.text = towerTemp.TowerToUpgrade.towerCost.ToString();
        }
    }

}
