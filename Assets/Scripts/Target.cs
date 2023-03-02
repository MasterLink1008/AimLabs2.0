using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private TargetSpawn1 DieDetect;
    public GameObject TargetSpawn1;
    public float health = 50f;
    public static int score = 0;
    

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        DieDetect.SpawnTarget();
        ++score;
    }

    
    void Start()
    {
        DieDetect = GameObject.Find("TargetSpawner1").GetComponent<TargetSpawn1>();
    }
}
