using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float moveSpeed = 1.0f;

    private GameObject gameManager;
    private GameManagerScript gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 7);
        Spawn();
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.IsGameOver())
        {
            return;
        }
        Move();
    }

    private void Move()
    {
        if (transform.position.x > 4)
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }
        else if (transform.position.x < -4)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }
        Vector3 velocity = new Vector3(0, 0, moveSpeed * Time.deltaTime);
        transform.position += transform.rotation * velocity;
    }

    private void Spawn()
    {
        int r = Random.Range(0, 2);
        if (r == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }
    }
}
