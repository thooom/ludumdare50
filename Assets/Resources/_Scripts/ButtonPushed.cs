using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPushed : MonoBehaviour
{
    public static int SelectedButton = -1;
    public static bool HasActiveFan = false;
    public static bool HasActivePlank = false;
    private Button fanButton;
    private Button plankButton;

    // Start is called before the first frame update
    void Start()
    {
        fanButton = GameObject.Find("SelectFanButton").GetComponent<Button>();
        plankButton = GameObject.Find("SelectPlankButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SelectedButton = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedButton = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedButton = 2;
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            SelectedButton = -1;
        }

        fanButton.enabled = !HasActiveFan;
        plankButton.enabled = !HasActivePlank;
    }

    public void ButtonClicked(int pushedButton)
    {
        SelectedButton = pushedButton;
    }
}
