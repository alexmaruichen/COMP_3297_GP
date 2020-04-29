using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEditor.Timeline;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Public variable that contains the speed of the enemy
    private float speed = 1f;
    public GameObject EnemyArrow;
    public GameObject ShootingMethod;
    private float shootfreq = 1f;
    private Transform target;
    private float enemy_sight = 2f;
    private int HP = 1;
    private int method = 0;
    private int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        //define target for chasing
        target = GameObject.Find("Main").GetComponent<Transform>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 v = rb.velocity;
        v.x = 0;
        v.y = 0;
        rb.velocity = v;
        rb.angularVelocity = Random.Range(-200, 200);
        //Destroy(gameObject, 3);

        //call the shoot function every shootfreq seconds
        InvokeRepeating("shoot", shootfreq, shootfreq);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnWillRenderObject()
    {
        //make the enemy chase the player
        if (Vector2.Distance(transform.position, target.position) < enemy_sight)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
    //Function called when the enemy collides with another object
     void OnTriggerEnter2D(Collider2D obj)
     {
        string name = obj.gameObject.name;
        //if it collided with bullet
        if (name == "Arrow(Clone)")
            HP -= obj.gameObject.GetComponent<Arrow>().damage;
        else if (name == "Main")
            HP--;
        if (HP <= 0)
            Destroy(gameObject);
     } 
    
    void shoot()
    {
        ShootingMethod.GetComponent<Shoot>().shoot(method, EnemyArrow, transform, damage);
    }

}
