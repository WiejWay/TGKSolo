using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Levels : MonoBehaviour
{
    public int level = 1;
    public TMP_Text levelinfo;

    void Start()
    {
        // Set up levelinfo at the start.
        levelinfo = GameObject.FindWithTag("Level").GetComponent<TMP_Text>();
    }

    public void DodajLevel(int ilosc)
    {
        // Increment the level.
        level += ilosc;
    }

    void Update()
    {
        // Update the text based on the current level.
        levelinfo.text = $"Poziom {(level).ToString()}";
    }
}
