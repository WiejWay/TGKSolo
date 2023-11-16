using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UFO : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        Points skryptPunktow = GameObject.FindObjectOfType<Points>();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (skryptPunktow.punkty <= (currentSceneIndex + 1) * 3)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * Time.deltaTime * 15f);
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * Time.deltaTime * 15f);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * Time.deltaTime * 15f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.down * Time.deltaTime * 15f);
            }
        }
    }
}
