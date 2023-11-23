using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Points : MonoBehaviour
{
    public int punkty = 0;
    public TMP_Text textPunktow;
    public TMP_Text victoryText; // Add a reference to the Victory text component
    public GameObject Victory;
    public Levels levelsScript; // Reference to the Levels script

    void Start()
    {
        textPunktow = GameObject.FindWithTag("Points").GetComponent<TMP_Text>();
        UpdatePointsText();
        levelsScript = GameObject.FindObjectOfType<Levels>();
        victoryText = Victory.GetComponentInChildren<TMP_Text>(); // Assuming the text component is a child of the Victory GameObject

        
    }


    void Update()
    {
        UpdatePointsText();
    }

    public void UpdatePointsText()
    {
        levelsScript = GameObject.FindObjectOfType<Levels>();
        textPunktow.text = punkty.ToString() + "/"+ ((levelsScript.level + 3) * (levelsScript.level * 2)).ToString();

    }

    public void DodajPunkty(int ilosc)
    {
        punkty += ilosc;

        if (punkty >= (levelsScript.level + 3) * (levelsScript.level * 2))
        {
            Victory.SetActive(true);
            StartCoroutine(DeactivateVictoryAfterDelay(2.0f)); // Delay is set to 2 seconds, adjust as needed

            // Set the Victory text to display the current level
            if (victoryText != null)
            {
                victoryText.text = $"Ukoñczono poziom {levelsScript.level}";
            }
        }
    }

    IEnumerator DeactivateVictoryAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Victory.SetActive(false);

        if (levelsScript != null)
        {
            levelsScript.DodajLevel(1);
            punkty = 0;
        }
    }
}
