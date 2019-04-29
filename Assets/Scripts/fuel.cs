using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fuel : MonoBehaviour
{
    public GameObject Fuel; 
    private int left = -25; 
    private int right = 72; 
    bool first = true; 


    void Spawn()
    { 
        float x = (float)Random.Range(right,left); 
        float y = 16.5f;
        Instantiate(Fuel, new Vector2(x,y),Quaternion.identity); 
    } 
    
    void Start () 
    { 
        if (first) 
        { 
            Spawn(); 
            first = false; 
        } 
        InvokeRepeating("Spawn", 3,3);  
    } 
}
