using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLivello1 : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float groundLevel;
    [SerializeField] private float undergroundLevel;
    private float cameraSpeed = 1.5f;
    private Vector3 velocity = Vector3.zero;
    private float offset = 2;

    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, groundLevel, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }

    public void MoveToOtherGround(float level)
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x, level, transform.position.z), ref velocity, cameraSpeed * Time.deltaTime);
    }

}
