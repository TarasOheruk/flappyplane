using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{
    private bool isOff = false;
    public GameObject textof;
    public GameObject teston;


    public void ExitDead()
    {
        GetComponent<AudioSource>().Play();
        Application.LoadLevel("Main");
        GameObject btn;
    }
    public void Play()
    {
        GetComponent<AudioSource>().Play();
        Application.LoadLevel("Playing");
    }
    public void Setting()
    {
        GetComponent<AudioSource>().Play();
        Application.LoadLevel("setting");
    }
    public void ExitFromGame()
    {
        GetComponent<AudioSource>().Play();
        Application.Quit();
    }
    public void OfMusic()
    {
        if (!isOff)
        {
            AudioListener.volume = 0;
            isOff = true;
            textof.SetActive(true);
            teston.SetActive(false);

        }
        else if (isOff)
        {
            AudioListener.volume = 1;
            isOff = false;
            teston.SetActive(true);
            textof.SetActive(false);
        }
    }
}
