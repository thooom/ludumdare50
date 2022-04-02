using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    // Start is called before the first frame update
    void Start()
    {
     MainMenuButton();   
    }

    public void MainMenuButton(){
        MainMenuUI.SetActive(true);
    }
    public void PlayButton(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void QuitButton(){
      
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
 
}
