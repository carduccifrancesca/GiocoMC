using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    private Rigidbody2D train;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    private void Awake()
    {
        train = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (train.position.x < 40)
            train.velocity = new Vector2(speed, 0);
        else
            train.velocity = Vector2.zero;
    }
}
