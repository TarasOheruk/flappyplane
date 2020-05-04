using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateDanger : MonoBehaviour
{
    bool isDanger;
    int count;
    private int lascount;
    public Text score;
    Rigidbody2D rd;
    public GameObject danger;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        lascount = PlayerPrefs.GetInt("Score");
        StartCoroutine(Making());
    }
    void Update()
    {
        if (isDanger)
        {
            Application.LoadLevel("Dead");
        }

        Making();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            isDanger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        count++;
        score.text = count.ToString();
        PlayerPrefs.SetInt("ScoreDead", count);
        if (lascount < count)
        {
            lose();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Danger")
            isDanger = false;
    }

    IEnumerator Making()
    {
        Vector2 position;
        while (!isDanger)
        {
            position = transform.position;
            position.x += 12.50f;
            Instantiate(danger, position, Quaternion.identity);
            yield return new WaitForSeconds(2.0f);
        }
    }

    void lose()
    {
        PlayerPrefs.SetInt("Score", count);
    }

    /*IEnumerator Make()
    {
        Vector2 position;
        while (!isDanger)
        {
            choose = Random.Range(1, 3);
            position = transform.position;
            position.x += 6.0f;
            if (choose == 1)
            {
                Instantiate(bronze, position, Quaternion.identity);
            }
            else if (choose == 2)
            {
                Instantiate(silver, position, Quaternion.identity);
            }
            else if (choose == 3)
            {
                Instantiate(gold, position, Quaternion.identity);
            }
            yield return new WaitForSeconds(2.0f);
        }
    }*/
}
