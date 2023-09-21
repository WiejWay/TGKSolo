using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UFO"))
        {
            Points skryptPunktow = GameObject.FindObjectOfType<Points>();
            skryptPunktow.DodajPunkty(1); 
            Destroy(gameObject);
        }
    }
}
