using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public GameObject Fuel; 
    public GameObject bottelOfWater; 
    public GameObject Bomb; 
    public GameObject Gun;
    public GameObject Enemy;
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
    void SpawnGun()
    { 
        float x = (float)Random.Range(right,left); 
        float y = 16.5f;
        Instantiate(Gun, new Vector2(x,y),Quaternion.identity); 
    }
    void SpawnEnemy()
    {
        float x = 96f;
        float y = 9.4f;
        Instantiate(Enemy, new Vector2(x,y),Quaternion.identity);
    }

    
    void Start () 
    {   
        InvokeRepeating("SpawnEnemy", 10,7);
        InvokeRepeating("SpawnFuel", 0,3);
        InvokeRepeating("SpawnWater", 10,10);  
        InvokeRepeating("SpawnBomb", 20,20); 
        InvokeRepeating("SpawnGun", 30,30);
    } 
}
