using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 5f;
    playerController player;
    float sign;
    void Start()
    {
        player = FindObjectOfType<playerController>();
        sign = player.G;
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(sign*speed*Time.deltaTime,0,0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if(collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
