using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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

        if (punkty >= (currentSceneIndex + 1) * 3)
        {
            Victory.SetActive(true);
            StartCoroutine(LoadNextScene(3.0f));
        }
    }

    IEnumerator LoadNextScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Clone the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        Scene newScene = SceneManager.CreateScene($"lv{nextSceneIndex + 2}");

        // Copy all root objects to the new scene
        foreach (GameObject rootObject in currentScene.GetRootGameObjects())
        {
            SceneManager.MoveGameObjectToScene(rootObject, newScene);
        }

        // Unload the current scene
        SceneManager.UnloadSceneAsync(currentScene);

        // Check if the new scene is not in the build settings, then add it
        if (!SceneInBuildSettings($"lv{nextSceneIndex + 2}"))
        {
            string scenePath = $"Assets/Scenes/lv{nextSceneIndex + 2}.unity";
            EditorBuildSettings.scenes = AddSceneToBuildSettings(EditorBuildSettings.scenes, scenePath);
        }

        // Load the new scene
        SceneManager.LoadScene($"lv{nextSceneIndex + 2}");
    }

    private bool SceneInBuildSettings(string sceneName)
    {
        EditorBuildSettingsScene[] buildScenes = EditorBuildSettings.scenes;
        foreach (var buildScene in buildScenes)
        {
            if (buildScene.path.Contains(sceneName))
            {
                return true;
            }
        }
        return false;
    }

    private EditorBuildSettingsScene[] AddSceneToBuildSettings(EditorBuildSettingsScene[] scenes, string scenePath)
    {
        List<EditorBuildSettingsScene> sceneList = new List<EditorBuildSettingsScene>(scenes);
        sceneList.Add(new EditorBuildSettingsScene(scenePath, true));
        return sceneList.ToArray();
    }
}
