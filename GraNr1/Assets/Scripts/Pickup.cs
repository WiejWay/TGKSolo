using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int pointsToAdd = 1; // Set the default value or adjust in the Inspector

    void Start()
    {
        RozmiescNaPlanszy();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UFO"))
        {
            Points skryptPunktow = GameObject.FindObjectOfType<Points>();
            skryptPunktow.DodajPunkty(pointsToAdd);
            RozmiescNaPlanszy();
        }
    }

    void RozmiescNaPlanszy()
    {
        GameObject[] backgroundElements = GameObject.FindGameObjectsWithTag("Back");

        if (backgroundElements.Length > 0)
        {
            GameObject randomBackground = backgroundElements[Random.Range(0, backgroundElements.Length)];
            float randomX = Random.Range(randomBackground.transform.position.x - randomBackground.transform.localScale.x * 12,
                                        randomBackground.transform.position.x + randomBackground.transform.localScale.x * 12);
            float randomY = Random.Range(randomBackground.transform.position.y - randomBackground.transform.localScale.y * 12,
                                        randomBackground.transform.position.y + randomBackground.transform.localScale.y * 12);

            transform.position = new Vector3(randomX, randomY, 0f);
        }
    }
}
