using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public float speed = 5f;
    private bool active = false;

    private void OnEnable(){
        active = true;
    }

    private void OnDisable() {
        active = false;
    }

    private void Update(){
        if(active)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            gameObject.SetActive(false);
        }
        
    }

}
