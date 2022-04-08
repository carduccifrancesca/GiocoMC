using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biglietto : MonoBehaviour
{
    public float speed;
    public float limite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        if (transform.position.x < limite)
        {
            Destroy(gameObject);
        }
    }
}
