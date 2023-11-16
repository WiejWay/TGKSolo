using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

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
        print($"{punkty} {punkty + ilosc}");

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (punkty >= (currentSceneIndex +1) * 3)
        {
            Victory.SetActive(true);
            StartCoroutine(LoadNextScene(3.0f));
        }
    }

    IEnumerator LoadNextScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
