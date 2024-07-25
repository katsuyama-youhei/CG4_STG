using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManagerScript : MonoBehaviour
{
    public GameObject hitKey;

    private int timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") == 1)
        {
            SceneManager.LoadScene("GameScene");
        }
        Flashing();
    }

    void Flashing()
    {
        timer++;
        if (timer % 100 > 50)
        {
            hitKey.SetActive(false);
        }
        else
        {
            hitKey.SetActive(true);
        }
    }
}
