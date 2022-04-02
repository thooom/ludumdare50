using UnityEngine;

public class FanPhysics : MonoBehaviour
{
    Vector2 yeet;
    float force;

    public void Awake()
    {
        force = 5f;
        yeet = transform.position - transform.parent.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(yeet * force * Time.deltaTime);
            }
        }
    }
}
