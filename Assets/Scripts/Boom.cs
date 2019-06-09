using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


namespace Scripts
{
    public class Boom : MonoBehaviour
    {
        void DestroyItem()
        { 
            Destroy(gameObject, .3f); 
        }
        void Start () 
        { 
            DestroyItem();
        } 
        void OnCollisionEnter2D(Collision2D other) 
        { 
            if (other.gameObject.tag == "Player" && Character.HaveShield)
			{
				Character.HaveShield = false;
			}
			else if (other.gameObject.tag != "Ground" && other.gameObject.tag == "Player")
			{
                Destroy(other.gameObject); 
                Destroy(gameObject);
                Thread.Sleep(100);
                Varibales.Death = true;
            }
            else
            {
                Destroy(other.gameObject); 
                Destroy(gameObject);
            }
        }
    }
}
