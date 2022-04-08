using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject stone;
    public GameObject coin;
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
        Instantiate(stone, transform.position, transform.rotation);
        Instantiate(coin, transform.position + new Vector3(Random.Range(-2,10), Random.Range(-2, 2), 0), transform.rotation);
    }
}
