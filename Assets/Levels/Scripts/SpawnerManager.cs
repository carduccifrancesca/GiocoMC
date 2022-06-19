using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject stone;
    public GameObject coin;
    public GameObject enemy;
    public float intervallo;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn", 0, intervallo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawn()
    {
        Instantiate(coin, transform.position + new Vector3(Random.Range(5,10), Random.Range(-2, 2), 0), transform.rotation);


        int dice = Random.Range(1, 3);
        if(dice %2 == 1)    
        Instantiate(enemy, transform.position + new Vector3(Random.Range(9, 10), Random.Range(3, 4), 0), transform.rotation);
        else
        Instantiate(stone, transform.position + new Vector3(Random.Range(9, 10), 0, 0), transform.rotation);
    }
}
