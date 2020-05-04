using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float verticalImpulse;
    public GameObject pause;
    Rigidbody2D rd;
    private bool paused = false;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        Time.timeScale = 0.0f;
        AudioListener.volume = 0;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !paused)
        {
            Time.timeScale = 1.0f;
            AudioListener.volume = 1;
            rd.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Time.timeScale = 0.0f;
                paused = true;
                pause.SetActive(true);
                AudioListener.volume = 0;
            }
            else
            {
                Time.timeScale = 1.0f;
                paused = false;
                pause.SetActive(false);
                AudioListener.volume = 1;
            }
        }
    }


}
