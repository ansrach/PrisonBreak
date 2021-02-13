using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;

public class Soilder_AI : MonoBehaviour
{
    public Transform target;
    public Transform soilder;
    public GameObject wayPoints;
    public float speed = 200;
    public float nextWayPointDistance = 3f;
    public bool startFollowPlayer = false;    

    Path path;
    Seeker seeker;
    Rigidbody2D rb;
    Player player;
    Door door;
    Hide hide;
    int currentWayPoint = 0;
    bool reachEndOfPath = false;
        

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        door = GameObject.Find("Player").GetComponent<Door>();
        hide   = GameObject.Find("Player").GetComponent<Hide>();
        seeker = GetComponent<Seeker>();        
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 1f, 0.5f);
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    void Update()
    {
        if (startFollowPlayer == true)
        {
            FollowPlayer();
            door.nextLV = false;
            hide.canHide = false;
        }
    }
    void FollowPlayer()
    {
        if (path == null)
            return;
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachEndOfPath = true;
            return;
        }
        else
        {
            reachEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
        if (force.x >= 0.01f)
        {
            soilder.localScale = new Vector3(-3f, 3f, 3f);
        }
        else if (force.x <= -0.01f)
        {
            soilder.localScale = new Vector3(3f, 3f, 3f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("แตกพ่าย");
            SceneManager.LoadSceneAsync(6);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            startFollowPlayer = true;
            wayPoints.SetActive(false);            
        }
    }
}
