using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject OptionsMenuUI;
    // Start is called before the first frame update
    void Awake()
    {
        MainMenuButton();   
    }

    public void MainMenuButton()
    {
        MainMenuUI.SetActive(true);
        OptionsMenuUI.SetActive(false);
    }
    public void PlayButton()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("DemoLevel");
    }
    public void OptionsButton()
    {
        MainMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(true);
    }
    public void QuitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void BackButton()
    {
        MainMenuUI.SetActive(true);
        OptionsMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
