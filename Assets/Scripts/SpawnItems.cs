﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public GameObject Fuel; 
    public GameObject bottelOfWater; 
    public GameObject Bomb; 
    private int left = -25; 
    private int right = 72; 


    void SpawnFuel()
    { 
        float x = (float)Random.Range(right,left); 
        float y = 16.5f;
        Instantiate(Fuel, new Vector2(x,y),Quaternion.identity); 
    } 
    void SpawnWater()
    { 
        float x = (float)Random.Range(right,left); 
        float y = 16.5f;
        Instantiate(bottelOfWater, new Vector2(x,y),Quaternion.identity); 
    } 
    void SpawnBomb()
    { 
        float x = (float)Random.Range(right,left); 
        float y = 16.5f;
        Instantiate(Bomb, new Vector2(x,y),Quaternion.identity); 
    } 

    
    void Start () 
    { 
        InvokeRepeating("SpawnFuel", 0,3);
        InvokeRepeating("SpawnWater", 10,10);  
        InvokeRepeating("SpawnBomb", 20,20); 
    } 
}