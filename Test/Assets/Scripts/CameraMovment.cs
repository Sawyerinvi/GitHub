using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    
    void Update()
    {
        Vector3 temp = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        transform.position = temp;
    }
}
