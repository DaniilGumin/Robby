using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    Rigidbody2D rb;
    public float speed = 5f;

    void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        } 


    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D other) 
        { 
            if (other.gameObject.tag != "Player" && other.gameObject.tag != "Ground")
			{
                Destroy(other.gameObject); 
                Destroy(gameObject);
            }
        }
}
