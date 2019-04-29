using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Scripts
{
    public class Character: MonoBehaviour
    {
        Rigidbody2D rb;
        bool isFacingRight = true;
        float horizontal;
        public GameObject end;
        public Slider slider;
        public Text text;
        private float countOfFuel = 0.0f;
        private bool onGround = true;

        
        
        void Start()
        {   
            Scripts.pause.Finished = false;
            rb = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D other) 
        { 
            if (other.gameObject.tag == "Fuel") {   
                if(countOfFuel<=0.95)
                {
                    countOfFuel += 0.05f;
                }
                else
                {
                    countOfFuel=1.0f;
                }
                Destroy(other.gameObject); 
            }
            if (other.gameObject.tag == "Ground")
            {   
                onGround = true;  
            }
            if (other.gameObject.tag == "debaf")
            {   
                countOfFuel -= countOfFuel*0.1f;
                Destroy(other.gameObject); 
            }
        }


        void FixedUpdate()
        {
            slider.value = countOfFuel;
            text.text = (countOfFuel*100).ToString("F" + 0) + "%";
            if (countOfFuel >= 1.0f)
            {
                Scripts.pause.Finished = true;
                end.SetActive(true);
            }
            if (Input.GetKeyDown (KeyCode.Space) && onGround)
            {
                onGround = false;
                rb.AddForce (Vector2.up * 2000);
            }
            if(Application.platform== RuntimePlatform.Android)
            {
                horizontal = Input.acceleration.x;      
            }
            else
            {
                horizontal = Input.GetAxis("Horizontal");
            }
            rb.velocity = new Vector2 (horizontal*25f, rb.velocity.y);
            if (horizontal > 0 && !isFacingRight)
                Flip ();
            else if (horizontal < 0 && isFacingRight)
                Flip ();
            // if(Application.platform == RuntimePlatform.Android){

            // }

        }

        void Flip()
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    
    }
}