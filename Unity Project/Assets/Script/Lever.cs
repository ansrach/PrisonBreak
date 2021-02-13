using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject leverOff;
    public GameObject leverOn;
    public GameObject obstacle;
    bool leverSwitch = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && leverSwitch == true)
        {
            obstacle.SetActive(false);
            leverOff.SetActive(false);
            leverOn.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            leverSwitch = true;
        }        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            leverSwitch = false;
        }
    }
}
