using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager inctance;
    public GameObject standardTurretPrefab;

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

    private void Start()
    {
        turretTobuild = standardTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return turretTobuild;
    }
}
