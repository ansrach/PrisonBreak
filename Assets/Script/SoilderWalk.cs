using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderWalk : MonoBehaviour
{    
    public float speed;
    public bool moveRight;
    Soilder_AI soilder;   

    void Start()
    {
        soilder = GameObject.Find("SoilderAI").GetComponent<Soilder_AI>();       
    }
    void Update()
    {
        if (soilder.startFollowPlayer == false)
        {
            Move();
        }
    }
    void Move()
    {
        if (moveRight)
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("turn"))
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
    }
    
}
