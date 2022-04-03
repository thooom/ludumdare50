using UnityEngine;

public class FanPhysics : MonoBehaviour
{
    float force;

    public void Awake()
    {
        force = 5000f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collision 1");
            if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.position - transform.parent.position) * force * Time.deltaTime);
            }
        }
    }
}
