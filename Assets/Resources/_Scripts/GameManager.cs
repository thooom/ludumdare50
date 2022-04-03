using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScoreCounter scoreBoard;
    public GameObject player;

    private Vector3 startPos;
    private Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = GameObject.Find("ScoreBoard").GetComponent<ScoreCounter>();
        startPos = player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentPos = player.transform.position;
        if (scoreBoard != null)
        {
            scoreBoard.counter = Mathf.RoundToInt((startPos - currentPos).magnitude);
        }
    }
}
