using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollector : MonoBehaviour
{
    [SerializeField] private float rightLimit;
    private int biglietti = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Biglietto"))
        {
            collision.gameObject.transform.position = new Vector3(rightLimit, transform.position.y);
            biglietti++;
            Debug.Log("Biglietti: " + biglietti);

        }
    }
}
