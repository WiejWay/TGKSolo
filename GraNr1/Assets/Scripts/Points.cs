using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public int punkty = 0;
    public TMP_Text textPunktow;

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
    }
}
