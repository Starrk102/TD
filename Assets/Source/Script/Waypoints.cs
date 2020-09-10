using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] WayPoint;

    private void Awake()
    {
        WayPoint = new Transform[transform.childCount];

        for (int i = 0; i < WayPoint.Length; i++)
        {
            WayPoint[i] = transform.GetChild(i);
        }
    }
}
