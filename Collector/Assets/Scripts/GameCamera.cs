using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    private static float _border = 0f;

    public static float Border
    {
        get
        {
            if(_border == 0)
            {
                var cam = Camera.main;
                _border = cam.aspect * cam.orthographicSize;
            }
            return _border;
        }
        private set { }
    }

}
