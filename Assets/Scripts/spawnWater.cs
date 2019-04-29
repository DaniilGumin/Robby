using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnWater : MonoBehaviour
{
    public GameObject bottelOfWater; 
    private int left = -25; 
    private int right = 72; 


    void Spawn()
    { 
        float x = (float)Random.Range(right,left); 
        float y = 16.5f;
        Instantiate(bottelOfWater, new Vector2(x,y),Quaternion.identity); 
    } 
    
    void Start () 
    { 
        InvokeRepeating("Spawn", 3,15);  
    } 
}

