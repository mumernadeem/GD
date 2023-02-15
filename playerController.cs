using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float jumpHeight = 7f;
    private Rigidbody2D player;
    private bool isGround = true;
    private SpriteRenderer face;
    CapsuleCollider2D myCollider;
    Animator anim;
    public Text text;
    public GameObject bullet;
    public float G=1;
    public int totalBullts = 10;
    Buttons button;
    public Button restartGame;
    private bool Keycheck = false;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        face = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        text.text = "Reamining Bullets: 10/10";
        button = FindObjectOfType<Buttons>();
    }

    // Update is called once per frame
    void Update()
    {
        if (button.startGameCheck == true)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                face.flipX = true;
                G = 1;
                anim.SetBool("isRunning", true);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                face.flipX = false;
                G = -1;
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0));
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
                {
                    player.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                    anim.SetBool("isRunning", false);
                }

            }
            if (Input.GetKeyDown(KeyCode.Z) && totalBullts > 0)
            {
                Instantiate(bullet, transform.position + new Vector3(G * 0.6f, 0, 0), transform.rotation);
                totalBullts = totalBullts - 1;
            }
            text.text = "Reamining Bullets: " + totalBullts + "/10";
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag=="enemy")
        {
            button.startGameCheck = false;
            restartGame.gameObject.SetActive(true);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("key"))
        {
            Keycheck = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("door")&& Keycheck==true)
        {
            button.startGameCheck = false;
            restartGame.gameObject.SetActive(true);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("door"))
        {
            print("Please get the key first to unlock");
        }
    }
}
