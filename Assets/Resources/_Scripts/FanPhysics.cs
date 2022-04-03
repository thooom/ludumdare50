using UnityEngine;

public class FanPhysics : MonoBehaviour
{
    Vector2 yeet;
    float force;

    public void Awake()
    {
        force = 50f;
        yeet = transform.position - transform.parent.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collision 1");
            if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                Debug.Log(yeet  );
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(yeet * force * Time.deltaTime);
            }
        }
    }
}
