using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Bullet : MonoBehaviour
    {   
        Rigidbody2D rb;
        public static float speed = 40f;
        public GameObject explosion;

        

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        } 


        void Update()
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x>72f | transform.position.x<-25f)
            {
                Destroy(gameObject);
            }
        }
        void OnCollisionEnter2D(Collision2D other) 
        {   
            if (other.gameObject.tag == "Bomb" | other.gameObject.tag == "Fuel")
            {
                Destroy(other.gameObject); 
                Destroy(gameObject);
                SpawnExplosion(); 
            }
            else if (other.gameObject.tag != "Player" && other.gameObject.tag != "Ground" && other.gameObject.tag != "Explosion")
            {
                Destroy(other.gameObject); 
                Destroy(gameObject);
            }
        
        }
        void SpawnExplosion()
        { 
            float x = gameObject.transform.position.x;
            float y = gameObject.transform.position.y;
            Instantiate(explosion, new Vector2(x,y),Quaternion.identity); 
        } 
    }
}