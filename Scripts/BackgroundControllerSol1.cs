using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControllerSol1 : MonoBehaviour
{

    public GameObject myCamera;
    public GameObject backgroundA;
    public GameObject backgroundB;
    public SpriteRenderer widthA;
    public SpriteRenderer widthB;

    public float speed;

    void Update()
    {
        backgroundA.transform.Translate(Time.deltaTime * speed, 0, 0);
        backgroundB.transform.Translate(Time.deltaTime * speed, 0, 0);

        if(backgroundA.transform.position.x + widthA.sprite.bounds.size.x < myCamera.transform.position.x)
            backgroundA.transform.position = new Vector3(backgroundB.transform.position.x + widthA.sprite.bounds.size.x,0,0);
        else if(backgroundB.transform.position.x + widthB.sprite.bounds.size.x < myCamera.transform.position.x)
            backgroundB.transform.position = new Vector3(backgroundA.transform.position.x + widthB.sprite.bounds.size.x,0,0);
    }
}
