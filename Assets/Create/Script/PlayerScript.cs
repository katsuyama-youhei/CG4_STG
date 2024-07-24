using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 1.0f;

    public Animator animator;

    public GameObject bullet;

    private int bulletTimer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        if (bulletTimer == 0)
        {
            Fire();
        }
        else
        {
            bulletTimer++;
            if (bulletTimer >= 20)
            {
                bulletTimer = 0;
            }
        }

    }

    void Move()
    {
        Vector3 v = rb.velocity;
        float stageMax = 4.0f;
        float move = Input.GetAxis("Horizontal");

        if (move < 0)
        {
            if (transform.position.x > -stageMax)
            {
                v.x = moveSpeed * move;
                rb.velocity = v;
                animator.SetBool("IsRun", true);
            }
        }
        else if (move > 0)
        {
            if (transform.position.x < stageMax)
            {
                v.x = moveSpeed * move;
                rb.velocity = v;
                animator.SetBool("IsRun", true);
            }
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            animator.SetBool("IsRun", false);
        }


        rb.velocity = v;
    }

    void Fire()
    {
        if (Input.GetAxis("Fire1")==1)
        {
            Vector3 position = transform.position;
            position.y += 0.8f;
            position.z += 1.0f;
            Instantiate(bullet, position, Quaternion.identity);
            bulletTimer = 1;
        }
    }
}
