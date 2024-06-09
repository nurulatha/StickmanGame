using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int pumpkins = 0;
    public Text pumpkinText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pumpkin"))
        {
            Destroy(collision.gameObject);
            pumpkins++;
            pumpkinText.text = "Pumpkins: " + pumpkins;
        }
    }
}
