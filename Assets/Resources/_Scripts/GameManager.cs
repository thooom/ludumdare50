using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ScoreCounter scoreBoard;
    public GameObject player;

    private Vector3 startPos;
    private Vector3 currentPos;

    public static GameObject EndScreenPanel;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = GameObject.Find("ScoreBoard").GetComponent<ScoreCounter>();
        startPos = player.transform.position;

        EndScreenPanel = GameObject.Find("EndScreen");
        EndScreenPanel.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentPos = player.transform.position;

        if (scoreBoard != null)
        {
            scoreBoard.counter = Mathf.RoundToInt((startPos - currentPos).magnitude);
        }

        // TODO: Trigger on player health instead
        if (scoreBoard.counter >= 100)
        {
            EndScreenPanel.SetActive(true);
            var finalScoreText = GameObject.Find("FinalScore").GetComponent<Text>();
            finalScoreText.text = $"Final score: {scoreBoard.counter}";
            Time.timeScale = 0f;
        }
    }
}
