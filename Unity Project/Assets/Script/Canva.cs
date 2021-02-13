using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canva : MonoBehaviour
{
    public GameObject text;
    public GameObject menu;
    public GameObject exit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.SetActive(true);
            menu.SetActive(true);
            exit.SetActive(true);
        }
    }
}
