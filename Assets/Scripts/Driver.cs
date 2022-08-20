using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public float steeringSpeed = 0.1f;
    public float acceleration = 0.01f;
    public float normalSpeed = 10f;
    public float slowSpeed = 5f;
    public float boostSpeed = 20f;
    public float countDown;
    public float waitTime = 5f;
    public float slowSpeedTimer;
    public bool hitObstacle = false;
    public float boostSpeedTimer;
    public bool hitBoost = false;
    
    void Start()
    {
     
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
       
       if (other.tag == "Boost")
       {
            Debug.Log("Boosted");
            acceleration = boostSpeed;
            boostSpeedTimer = waitTime;
            hitBoost = true;
       }     
       
       
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        acceleration = slowSpeed;
        slowSpeedTimer = waitTime;
        hitObstacle = true;
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") *  steeringSpeed * Time.deltaTime;
        float accelerationAmount = Input.GetAxis("Vertical") * acceleration * Time.deltaTime;
        if (accelerationAmount >= 0.001f)
        {
            transform.Rotate(0,0,-steerAmount);
        }
        else
        {
            transform.Rotate(0,0,steerAmount);
        }
        transform.Translate(0,accelerationAmount,0);
       if (accelerationAmount <= 0.001f && accelerationAmount >= -0.001f)
        {
            steeringSpeed = 0;
        }
        else
        {
            {
                steeringSpeed = 200;
            }
        }
        slowSpeedTimer -= Time.deltaTime;
        boostSpeedTimer -= Time.deltaTime;
        if (boostSpeedTimer <= 0f && boostSpeedTimer >= -1f && hitBoost == true && slowSpeedTimer <0f)
        {
            acceleration = normalSpeed;
            Debug.Log("Normal Speed");
            hitBoost = false;
        }

        if (slowSpeedTimer <= 0f && slowSpeedTimer >= -1f && hitObstacle == true && boostSpeedTimer <0f)
        {
            acceleration = normalSpeed;
            Debug.Log("Normal Speed");
            hitObstacle = false;
        }
        
    }
}
