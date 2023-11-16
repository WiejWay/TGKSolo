using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviour
{
    public int punkty = 0;
    public TMP_Text textPunktow;
    public GameObject Victory;

    void Start()
    {
        textPunktow = GameObject.FindWithTag("Points").GetComponent<TMP_Text>();
        textPunktow.text = punkty.ToString();
    }

    void Update()
    {
        textPunktow.text = punkty.ToString();
    }

    public void DodajPunkty(int ilosc)
    {
        punkty += ilosc;
        if (punkty >= 3)
        {
            Victory.SetActive(true);
            // Load the next scene with the next build index
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // Get the current scene's build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene by incrementing the current build index
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
