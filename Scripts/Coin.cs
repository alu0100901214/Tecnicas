using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        print("hola");
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
        }
        
    }

}