using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Import the UI namespace

public class Cringe : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    private AudioSource musicAudioSource;
    private bool isMuted = true;

    void Start()
    {
        // Find the object with the specified tag
        GameObject musicObject = GameObject.FindWithTag("music");

        if (musicObject != null)
        {
            musicAudioSource = musicObject.GetComponent<AudioSource>();

            if (musicAudioSource == null)
            {
                Debug.LogError("Object with tag 'music' does not contain an AudioSource component.");
            }
        }
        else
        {
            Debug.LogError("Object with tag 'music' not found.");
        }

        // Set up the Button click event
        Button button = GetComponent<Button>(); // Assuming the Button component is on the same GameObject
        if (button != null)
        {
            button.onClick.AddListener(ToggleMute);
        }
    }

    void Update()
    {
        // Optional: Update the button text based on the sound state
        if (buttonText != null)
        {
            buttonText.text = isMuted ? "W³¹cz dŸwiêk" : "Wy³¹cz dŸwiêk";
        }
    }

    // This function will be called when the button is pressed
    public void ToggleMute()
    {
        // Change the sound state (mute/unmute)
        isMuted = !isMuted;

        // Adjust the volume based on the sound state
        if (isMuted)
        {
            musicAudioSource.mute = true;
        }
        else
        {
            // Set any desired volume value, for example, 0.5
            musicAudioSource.mute = false;
        }
    }
}
