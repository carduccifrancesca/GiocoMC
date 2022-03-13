using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Portabiglietti : MonoBehaviour
{
    int biglietti = 0;
    public TextMeshProUGUI contaBiglietti;

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("atac"))
        {
            biglietti++;
            collision.gameObject.SetActive(false);
            AggiornaBiglietti();
        }
    }
    void AggiornaBiglietti()
    {
        contaBiglietti.SetText("Biglietti: " + biglietti);
    }
}
