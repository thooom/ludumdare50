using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        GameManager.EndScreenPanel.SetActive(false);
        // Go to main menu
    }
}
