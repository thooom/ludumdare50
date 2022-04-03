using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballBehaviour : MonoBehaviour
{
    public static float CurrentHealth;
    public GameObject player;
    public float healthLost;

    private Vector3 originalScale;
    private Vector3 destinationScale;
    private float startHealth;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = player.transform.localScale;
        destinationScale = new Vector3(0.0f, 0.0f, 0.0f);

        startHealth = 100.0f;
        healthLost = 0.0f;
        CurrentHealth = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentHealth = healthLost / startHealth;
        player.transform.localScale = Vector3.Lerp(originalScale, destinationScale, CurrentHealth);
        healthLost += 0.1f;
    }
}
