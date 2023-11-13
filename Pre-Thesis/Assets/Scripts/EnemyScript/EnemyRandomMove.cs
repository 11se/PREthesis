using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRandom_Move : MonoBehaviour
{
    public static Vector3 RandomPoint(Vector3 Start_point, float Radius)
    {
        Vector3 dir = Random.insideUnitSphere * Radius;
        dir += Start_point;
        NavMeshHit hit;
        Vector3 final_Pos = Vector3.zero;
        if(NavMesh.SamplePosition(dir, out hit, Radius, 1))
        {
            final_Pos = hit.position;
        }
        return final_Pos;
    }
}
