using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjctiveWaypoint : MonoBehaviour
{
    public Image Waypoint;
    public Transform TargetWaypoint;

    private void Update()
    {
        float minX = Waypoint.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = Waypoint.GetPixelAdjustedRect().width / 2;
        float maxY = Screen.height - minY;
      
        Vector2 pos = Camera.main.WorldToScreenPoint(TargetWaypoint.position);

        if (Vector3.Dot((TargetWaypoint.position - transform.position), transform.forward) < 0)
        {
            if(pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }
      
        Waypoint.transform.position = pos;
    }
}
