using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject enemy;

    public GameObject gameOverText;

    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1980, 1080, false);
        
    }

    private void Update()
    {
        if (isGameOver)
        {
            if (Input.GetAxis("Fire1") == 1)
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }

    private void FixedUpdate()
    {
        if(isGameOver)
        {
            return;
        }
        Spawn();
    }


    private void Spawn()
    {
        int r = Random.Range(0, 50);
        if (r == 0)
        {
            float x = Random.Range(-3.0f, 3.0f);
            Instantiate(enemy, new Vector3(x, 0, 10), Quaternion.identity);
        }
    }

    public void GameOverStart()
    {
        gameOverText.SetActive(true);
        isGameOver = true;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
