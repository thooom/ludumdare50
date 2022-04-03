using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public ScoreCounter scoreBoard;

    private Vector3 startPos;
    private Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = GameObject.Find("ScoreBoard").GetComponent<ScoreCounter>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentPos = transform.position;
        if (scoreBoard != null)
        {
            scoreBoard.counter = Mathf.RoundToInt((startPos - currentPos).magnitude);
        }
    }
}
