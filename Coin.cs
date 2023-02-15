using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Buttons score;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Buttons>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 5f, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            score.AddScore(1);
            Destroy(gameObject);
        }
    }
}
