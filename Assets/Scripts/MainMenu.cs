using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject playBtn, settings;
    bool settingsOpen = false;

    [SerializeField]
    AudioSource themeMusic;




    public void PlayGame()
    {
        Debug.Log("OCEEEEE");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }

    public void toggleSettings()
    {
        if (settingsOpen)
        {
            playBtn.SetActive(true);
            settings.SetActive(false);
        }
        else
        {
          
            playBtn.SetActive(false);
            settings.SetActive(true);
        }
        settingsOpen = !settingsOpen;
    }

    public void UkljuciMuziku()
    {
        themeMusic.Play();
    }

    public void IskljuciMuziku()
    {
        themeMusic.Stop();
    }
   
}
