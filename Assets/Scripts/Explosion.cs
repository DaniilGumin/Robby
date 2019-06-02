using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;

    void SpawnExplosion()
    { 
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        Instantiate(explosion, new Vector2(x,y),Quaternion.identity); 
    } 

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject); 
        SpawnExplosion();        
    } 
}
