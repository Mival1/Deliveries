using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool GotPackage = false;
    public float destroyTime = 0.5f;
    public Color32 gotPackageColor = new Color32 (1,1,1,1);
    public Color32 noPackageColor = new Color32 (1,1,1,1);

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("You Crashed!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
       
       if (other.tag == "Package" && !GotPackage)
       {
        Debug.Log("Package Picked Up");
        GotPackage = true;
        spriteRenderer.color = gotPackageColor;
        Destroy(other.gameObject,destroyTime);
       }        

       if (other.tag == "Drop Off" && GotPackage == true)
       {
        Debug.Log("Package Dropped Off");
        GotPackage = false;
        spriteRenderer.color = noPackageColor;
       }
    }
}
