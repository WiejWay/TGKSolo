using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

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

        if (punkty >= (currentSceneIndex + 1) * 1)
        {
            Victory.SetActive(true);
            StartCoroutine(LoadNextScene(3.0f));
        }
    }

    IEnumerator LoadNextScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 2;

        // Duplicate the current scene
        string currentScenePath = SceneUtility.GetScenePathByBuildIndex(currentSceneIndex);
        string newScenePath = $"Assets/Scenes/lv{nextSceneIndex}.unity";
        AssetDatabase.CopyAsset(currentScenePath, newScenePath);
        AssetDatabase.Refresh();

        // Add the duplicated scene to the build settings
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
        ArrayUtility.Add(ref scenes, new EditorBuildSettingsScene(newScenePath, true));
        EditorBuildSettings.scenes = scenes;

        // Load the duplicated scene
        SceneManager.LoadScene($"lv{nextSceneIndex}");
    }
}
