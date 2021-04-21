using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.inctance;
    }
    public void PurchaseStandartTurret()
    {
        Debug.Log("Standart Turret Purchaase");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseRocketTurret()
    {
        Debug.Log("Standart Rocket Purchaase");
        buildManager.SetTurretToBuild(buildManager.rocketTurretPrefab);
    }
}
