using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<SnowballBehaviour>() != null)
            {
                collision.gameObject.GetComponent<SnowballBehaviour>().IsInSnow();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<SnowballBehaviour>() != null)
            {
                collision.gameObject.GetComponent<SnowballBehaviour>().IsNotInSnow();
            }
        }
    }
}