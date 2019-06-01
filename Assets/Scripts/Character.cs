using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


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
        public GameObject gun;
        public GameObject LeftButton;
        public GameObject RightButton;
        public GameObject JumpButton;
        public GameObject ShotButton;
        float PosLeftButton;
        float PosRightButton;
        float PosJumpButton;
        float PosShotButton;
        float speed;
       

        
        
        void Start()
        {   
            PosLeftButton = LeftButton.transform.position.y;
            PosRightButton = RightButton.transform.position.y;
            PosJumpButton = JumpButton.transform.position.y;
            PosShotButton = ShotButton.transform.position.y;
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
            if (PosJumpButton != JumpButton.transform.position.y && onGround)
            {
                            onGround = false;
                            rb.AddForce(Vector2.up*2000);
            } 
            if (PosLeftButton != LeftButton.transform.position.y)
            {
                speed = -20f;
                isFacingRight = false;
                Flip ();
            }  
            else if (PosRightButton != RightButton.transform.position.y)
            {
                speed = 20f;
                isFacingRight = true;
                Flip ();
            } 
            
            else if (PosShotButton != ShotButton.transform.position.y)
            {
                Debug.Log("Shot");
            }   
            else
            {
                speed = 0;
            }       

            rb.velocity = new Vector2 (speed, rb.velocity.y);

            

        }

        void Flip()
        {
            if (isFacingRight)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            
        }
    
    }
}