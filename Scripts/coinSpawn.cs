using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawn : MonoBehaviour
{

    public GameObject pool;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;

    void Update(){
        if(Input.GetKey(KeyCode.R) && (Time.time > nextFire)){
            nextFire = Time.time + fireRate;
            GameObject coin = pool.GetComponent<objectPool>().RequestCoin();
            coin.transform.position = transform.position;
        }   
        
    }
}
