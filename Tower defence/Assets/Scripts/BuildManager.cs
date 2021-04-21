using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager inctance;
    public GameObject standardTurretPrefab, rocketTurretPrefab;
    

    private GameObject turretTobuild;

    private void Awake()
    {
        if(inctance != null)
        {
            Debug.LogError("BuildManager Error");
            return;
        }
        inctance = this;
    }


    public GameObject GetTurretToBuild()
    {
        return turretTobuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretTobuild = turret;
    }
}
