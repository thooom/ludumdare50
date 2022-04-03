using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballBehaviour : MonoBehaviour
{

    public GameObject player;

    private Vector3 originalScale;
    private Vector3 destinationScale;

    public float healthLost;
    public float startHealth;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = player.transform.localScale;
        destinationScale = new Vector3(0.0f, 0.0f, 0.0f);

        startHealth = 100.0f;
        healthLost = 0.0f;

        //StartCoroutine(ScaleOverTime(15));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player.transform.localScale = Vector3.Lerp(originalScale, destinationScale, healthLost / startHealth);
        healthLost += 0.1f;

    }

}
