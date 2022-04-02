using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public GameObject scoreBoard;

    private Vector3 startPos;
    private Vector3 currentPos;


    // Start is called before the first frame update
    void Start()
    {
        startPos = player.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentPos = player.transform.position;

        scoreBoard.GetComponent<ScoreCounter>().counter = Mathf.RoundToInt((startPos - currentPos).magnitude);

    }
}
