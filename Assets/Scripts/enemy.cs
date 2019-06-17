using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace Scripts
{
	public class enemy : MonoBehaviour 
	{
		Rigidbody2D rb;
		float speed = -12f;


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        } 
		
		void Update()
        {  
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x<-27f)
            {
                Destroy(gameObject);
            }
		}	

		void OnCollisionEnter2D (Collision2D other)
		{
			if (other.gameObject.tag == "Player" && Character.HaveShield)
			{
				Character.HaveShield = false;
			}
			else if (other.gameObject.tag == "Player")
			{
				Thread.Sleep(500);
				Varibales.Death = true;
			}
			else if (other.gameObject.tag != "Ground")
			{
				Destroy(other.gameObject);
			}
		}
	
	}
}