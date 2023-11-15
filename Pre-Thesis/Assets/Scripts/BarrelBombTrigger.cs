using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBombTrigger : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> _inRangeMonsters = new List<Enemy>();
    public List<Enemy> InRangeMonsters => _inRangeMonsters;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("trggerstay" + other.name);
        if (other.GetComponent<Enemy>() is Enemy enemy) 
        {
            if (!_inRangeMonsters.Contains(enemy)) 
            {
                _inRangeMonsters.Add(enemy);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Enemy>() is Enemy enemy)
        {
            if (_inRangeMonsters.Contains(enemy))
            {
                _inRangeMonsters.Remove(enemy);
            }
        }
    }
}
