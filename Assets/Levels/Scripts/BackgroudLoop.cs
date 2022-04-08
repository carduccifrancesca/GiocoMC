using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroudLoop : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0);
        

        if(transform.position.x < -leftLimit)
        {
            transform.position = new Vector3(rightLimit, transform.position.y);
        }

    }
}
