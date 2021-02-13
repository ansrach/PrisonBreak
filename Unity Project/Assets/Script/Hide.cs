using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public Rigidbody2D Player_rb;
    public Player player;
    public SpriteRenderer playerSprit;
    public CapsuleCollider2D capPlayer;
    public bool canHide = false;

    bool can_click = false;
    bool hide = false;        
    void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Player_rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerSprit = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        capPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();        
    }

    void Update()
    {
        if(canHide == true)
        {
            Hidden();
        }        
    }
    void Hidden()
    {
        float dis = Vector2.Distance(this.transform.position, player.transform.position);
        if (dis < 0.3f)
        {
            can_click = true;
        }
        else if (dis >= 0.3f)
        {
            can_click = false;
        }

        if (Input.GetMouseButtonDown(0) && can_click == true) //Input.GetMouseButtonDown(0) (คลิกซ้าย)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); //LayerMask.NameToLayer("Obj"));
            if (hit.collider != null)
            {
                Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
                if (can_click == true && hide == false)
                {
                    Invoke("get_in", 0.2f);                  
                }
                else if (can_click == true && hide == true)
                {
                    Invoke("get_out", 0.2f);                   
                }
            }
        }
    }

    void get_in()
    {
        Debug.Log("hide");
        Player_rb.isKinematic = true;
        Player_rb.velocity = Vector2.zero;
        player.enabled = false;
        playerSprit.enabled = false;
        capPlayer.enabled = false;
        hide = true;
        canHide = true;
    }

    void get_out()
    {
        Debug.Log("out");
        player.speed = 0.5f;
        Player_rb.isKinematic = false;
        player.enabled = true;
        playerSprit.enabled = true;
        capPlayer.enabled = true;
        hide = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hide"))
        {
            canHide = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("hide"))
        {
            canHide = false;
        }
    }
}
