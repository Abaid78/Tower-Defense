using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] point;
    private void Awake()
    {
        point = new Transform[transform.childCount];
        for(int i = 0; i < point.Length; i++)
        {
            point[i] = transform.GetChild(i);
            
        }
    }
}
