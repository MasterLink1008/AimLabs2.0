using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerTarget : MonoBehaviour
{
    float currentTime = 0f;
    public float randomWait;
    public float speed = 2f;
    public int direction = 1;
    private float ScoreConverter;
    
    

    private void Start()
    {
        SetValue();
    }

    void SetValue()
    {
        randomWait = Random.Range(1, 15);
        currentTime = randomWait;
    }

    private void Update()
    {
        if (MainMenu.Tracker == true )
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime * direction);
        }

        
        
        //Random things
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            SetValue();
            changeDirection();
        }
       
    }

    void changeDirection()
    {
        if (direction == 1)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "LeftBorder" || collision.gameObject.name == "RightBorder")
        {
            changeDirection();
        }
    }

    public void SetTrackerScore(float amount)
    {
         ScoreConverter += amount * Time.deltaTime;
         Target.score = Mathf.FloorToInt(ScoreConverter);
    }
}
