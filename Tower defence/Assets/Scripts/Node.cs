using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private Renderer rend;
    private Color startColor;
    private GameObject turret;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build here");
            return;
        }

        GameObject turretToBuild = BuildManager.inctance.GetTurretToBuild();

        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);


    }
}
