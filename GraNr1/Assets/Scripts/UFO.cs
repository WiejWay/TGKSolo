using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UFO : MonoBehaviour
{
    private Levels levelScript;
    private Points skryptPunktow;

    void Start()
    {
        levelScript = GameObject.FindObjectOfType<Levels>();
        skryptPunktow = GameObject.FindObjectOfType<Points>();
    }

    void Update()
    {
        if (skryptPunktow.punkty < (levelScript.level + 3) * (levelScript.level * 2))
        {
            MoveUFO();
        }
    }

    void MoveUFO()
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
