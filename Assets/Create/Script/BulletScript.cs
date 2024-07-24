using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(0, 0, moveSpeed);
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
