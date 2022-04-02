using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{

    public int counter;
    [SerializeField] private TextMeshProUGUI scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        scoreCounter.text = "Score: 0";
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreCounter.text = "Score: " + counter;
    }
}
