using UnityEngine;

public class SnowballBehaviour : MonoBehaviour
{
    public static float CurrentHealth;
    public GameObject player;
    public float healthLost;

    public Vector3 originalScale;
    public Vector3 bigScale;
    private Vector3 destinationScale;
    public bool inSnow;
    private float startHealth;
    public bool inFire;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = player.transform.localScale;
        bigScale = originalScale + originalScale + originalScale;
        destinationScale = new Vector3(0.0f, 0.0f, 0.0f);

        startHealth = 100.0f;
        healthLost = 0.0f;
        CurrentHealth = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentHealth = healthLost / startHealth;
        if (CurrentHealth > 1)
        {
            CurrentHealth = 1;
        }
        if (!inSnow)
        {
            player.transform.localScale = Vector3.Lerp(originalScale, destinationScale, CurrentHealth);
            healthLost += 0.07f;
        }
        else
        {
            healthLost -= 0.3f;
            player.transform.localScale = Vector3.Lerp(originalScale, destinationScale, CurrentHealth);
        }
        if (inFire)
        {
            Debug.Log("Fire");
            healthLost += 10f;
            inFire = false;
        }
    }

    public void IsInSnow()
    {
        inSnow = true;
    }

    public void IsNotInSnow()
    {
        inSnow = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
       
    }
}
