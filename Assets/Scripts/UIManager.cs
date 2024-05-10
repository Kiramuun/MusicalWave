using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[CreateAssetMenu]
public class UIManager : ScriptableObject
{
    
    
    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
    }

    public void MenuPause()
    {
        Time.timeScale = 0f;
        AudioSource[] audio = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audio)
        {
            audioSource.Pause();
        }
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        AudioSource[] audio = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audio)
        {
            audioSource.Play();
        }
    }

    public void RetourMainMenu()
    {
        SceneManager.UnloadSceneAsync("SampleScene");
        Time.timeScale = 1f;
    }

    public void MenuOptions()
    {

    }

    public void Exit()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
