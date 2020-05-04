using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveDanger : MonoBehaviour
{
    public float speed;

    void Start()
    {
         Vector2 position = transform.position;
         position.y = Random.Range(4.76F, 0.51F);
         transform.position = position;
         Destroy(gameObject, 11.0f);

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position - transform.right, speed * Time.deltaTime);
    }
}
