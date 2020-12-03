using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int level;
    public bool nextLV = false;
    Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {     
        if(level == 1 || level == 2)
        {
            if (Input.GetKey(KeyCode.E) && nextLV == true)
            {
                SceneManager.LoadScene(level + 1);
            }
        }        
        else if (level == 3)
        {
            if (Input.GetKey(KeyCode.E) && nextLV == true && player.blueKey == true)
            {
                SceneManager.LoadScene(level + 1);
            }
        }
        else if (level == 4)
        {
            if (Input.GetKey(KeyCode.E) && nextLV == true && player.blueKey == true && player.redKey == true && player.whiteKey == true)
            {
                SceneManager.LoadScene(level + 1);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nextLV = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nextLV = false;
        }
    }
}
