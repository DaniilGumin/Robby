using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts{
public class Character: MonoBehaviour
{
    Rigidbody2D rb;
    bool isFacingRight = true;
    float horizontal;
    private AudioSource Audio;
    public GameObject end;
    

    void Start()
    {   Scripts.pause.Finished = false;
        rb = GetComponent<Rigidbody2D>();
        Audio = GetComponent<AudioSource> ();
    }

    void OnCollisionEnter2D(Collision2D other){ 
        if(other.gameObject.tag == "Platform"){
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * 15 , ForceMode2D.Impulse);
            Audio.Play();}
        else if (other.gameObject.tag == "area"){
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
    }
    }
    

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Finish"){
            Scripts.pause.Finished = true;
            end.SetActive(true);
        }      
    }

    void FixedUpdate(){
       
        if(Application.platform== RuntimePlatform.Android){
            horizontal = Input.acceleration.x;      
        }else{
            horizontal = Input.GetAxis("Horizontal");
        }
        rb.velocity = new Vector2 (horizontal*25f, rb.velocity.y);

        if (horizontal > 0 && !isFacingRight)
            Flip ();
        else if (horizontal < 0 && isFacingRight)
            Flip ();

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