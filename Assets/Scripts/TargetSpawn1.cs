using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn1 : MonoBehaviour
{
    #region Variables
    
    public Vector3 center;
    public Vector3 size;
    public GameObject Targetprefab;
    public GameObject tTargetprefab;
    public Vector3 trackerPos;

    #endregion
    void Start()
    {
        if(MainMenu.Tracker == true) 
        {
            SpawnTrackerTarget();
        }
        
        if (MainMenu.Classic == true)
        {
            SpawnTarget();
        }
        
        if (MainMenu.MultiShot == true)
        {
            SpawnTarget();
            SpawnTarget();
            SpawnTarget();
            SpawnTarget();
            SpawnTarget();
        }
    }

    public void SpawnTarget()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Instantiate(Targetprefab, pos, Quaternion.identity);
    }

    public void SpawnTrackerTarget()
    {
        tTargetprefab.transform.position += new Vector3(0, 4, 0);
    }

    public void ResetTrackerTarget()
    {
        tTargetprefab.transform.position += new Vector3(0, -4, 0);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

    
}
