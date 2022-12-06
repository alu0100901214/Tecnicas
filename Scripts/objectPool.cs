using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPool : MonoBehaviour
{
    
    public GameObject coinObject;
    public List<GameObject> coinList;
    public int poolSize = 5;

    void Start(){
        AddCoinsToPool(poolSize);
    }

    private void AddCoinsToPool(int amount){
        for (int i = 0; i < amount; i++) {
            GameObject coin = Instantiate(coinObject);
            coin.SetActive(false);
            coinList.Add(coin);
            coin.transform.parent = transform;
        }
    }

    public GameObject RequestCoin(){
        for(int i = 0; i < coinList.Count; i++){
            if(!coinList[i].activeSelf){
                coinList[i].SetActive(true);
                return coinList[i];
            }
        }
        AddCoinsToPool(1);
        coinList[coinList.Count - 1].SetActive(true);
        return coinList[coinList.Count - 1];

    }
}
