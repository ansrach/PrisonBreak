using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int level;    
    public float speed;
    public float jumpForce;

    public Animator anim;
    public GameObject BlueKey;
    public GameObject RedKey;
    public GameObject WhiteKey;

    Rigidbody2D rb;
    private float moveH;
       
    bool grounded = false;
    public bool blueKey, redKey, whiteKey;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }        
    void Update()
    {
        Walk();
        Run();
        Jump();
        Animation();        
        Checklocalscale();
    }
    void Animation()
    {        
        if (moveH != 0 )
        {
            anim.SetBool("walk", true);
            if (speed == 4)
            {
                anim.SetBool("run", true);
            }
            if (speed == 2)
            {
                anim.SetBool("run", false);
            }
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }
    }
    public void Walk()
    {
        moveH = Input.GetAxisRaw("Horizontal") * speed;
        rb.velocity = new Vector2(moveH, rb.velocity.y);        
    }
    public void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4;
        }
        else
        {
            speed = 2;
        }
    }
    public void Jump()
    {
        anim.SetBool("Grounded", grounded);
        if (Input.GetKey(KeyCode.W))
        {           
            if (grounded == true)
            {
                //rb.AddForce(new Vector2(0f, jumpForce));
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                grounded = false;
                anim.SetTrigger("Jump");                
            }
        }      
    }        
    private void Checklocalscale()
    {
        if (moveH < 0)
        {
            this.transform.localScale = new Vector3(-3, 3, 3);
        }
        if (moveH > 0)
        {
            this.transform.localScale = new Vector3(3, 3, 3);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        if (collision.gameObject.tag == "death")
        {
            SceneManager.LoadSceneAsync(6);
            print("แตกพ่าย");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bluekey"))
        {
            Destroy(collision.gameObject);
            blueKey = true;
            BlueKey.SetActive(true);
        }
        if (collision.CompareTag("redkey"))
        {
            Destroy(collision.gameObject);
            redKey = true;
            RedKey.SetActive(true);
        }
        if (collision.CompareTag("whitekey"))
        {
            Destroy(collision.gameObject);
            whiteKey = true;
            WhiteKey.SetActive(true);
        }
    }    
}
