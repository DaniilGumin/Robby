using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading;


namespace Scripts
{
    public class Character: MonoBehaviour
    {
        Rigidbody2D rb;
        public static bool isFacingRight = true;
        float horizontal;
        public GameObject end;
        public Slider slider;
        public Text text;
        private float countOfFuel = 0.0f;
        private bool onGround = true;
        public GameObject WithOutGun;
        public GameObject WithGun;  
        static public bool HaveShield = false;
        public GameObject Shield;
        public GameObject ShieldButton;
        public GameObject LeftButton;
        public GameObject RightButton;
        public GameObject JumpButton;
        public GameObject ShotButton; 
        float PosLeftButton;
        float PosRightButton;
        float PosJumpButton;
        float PosShotButton;
        float speed;
        float PosShieldButton;
        bool checkPosShildButton = false;
        public GameObject Bullet;
        float shottime = 0;
       

        void CheckBaf()
        {
            if (Skills.Shield)
            {
               ShieldButton.SetActive(true);
            }
        }
        
        void Start()
        {   
            CheckBaf();
            PosLeftButton = LeftButton.transform.position.y;
            PosRightButton = RightButton.transform.position.y;
            PosJumpButton = JumpButton.transform.position.y;
            PosShotButton = ShotButton.transform.position.y;
            PosShieldButton =  ShieldButton.transform.position.y;
            Scripts.pause.Finished = false;
            rb = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D other) 
        { 
            if (other.gameObject.tag == "Fuel") 
            {   
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
            if (other.gameObject.tag == "Gun") 
            {
                WithGun.SetActive(true);
                WithOutGun.SetActive(false);
                Destroy(other.gameObject);
            }
        }


        void FixedUpdate()
        {   
            shottime += Time.deltaTime;
            slider.value = countOfFuel;
            text.text = (countOfFuel*100).ToString("F" + 0) + "%";
            if (countOfFuel >= 1.0f)
            {
                Scripts.pause.Finished = true;
                end.SetActive(true);
            }
            if (Skills.Shield && PosShieldButton != ShieldButton.transform.position.y && !checkPosShildButton)
            {
                checkPosShildButton = true;
                HaveShield = true;
                ShieldButton.SetActive(false);
                Shield.SetActive(true);
            }
            if (!HaveShield)
            {
                Shield.SetActive(false);
            }
            if (PosJumpButton != JumpButton.transform.position.y && onGround)          
            {
                onGround = false;
                rb.AddForce(Vector2.up*Skills.JumpPower);
            } 
            if (PosLeftButton != LeftButton.transform.position.y)
            {
                speed = -Skills.Speed;
                isFacingRight = false;
                Flip ();
            }  
            else if (PosRightButton != RightButton.transform.position.y)
            {
                speed = Skills.Speed;
                isFacingRight = true;
                Flip ();
            }        
            else if (PosShotButton != ShotButton.transform.position.y && shottime > 0.5f && isFacingRight)
            {   
                Scripts.Bullet.speed = 40f;
                Instantiate(Bullet,new Vector2(transform.position.x + 2f,transform.position.y - 0.2f),Quaternion.identity);
                shottime = 0;
            } 
            else if(PosShotButton != ShotButton.transform.position.y && shottime > 0.5f && !isFacingRight)
            {   Scripts.Bullet.speed = -40f; 
                Instantiate(Bullet,new Vector2(transform.position.x - 2f,transform.position.y - 0.2f),Quaternion.identity);                  
                shottime = 0;
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