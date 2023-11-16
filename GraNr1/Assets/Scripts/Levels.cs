using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class Levels : MonoBehaviour
{
    public TMP_Text levelinfo;

    void Start()
    {
        levelinfo = GameObject.FindWithTag("Level").GetComponent<TMP_Text>();

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        levelinfo.text = $"Poziom {(currentSceneIndex + 1).ToString()}";
    }

    void Update()
    {
    }

}