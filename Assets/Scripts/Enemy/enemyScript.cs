using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    // Public variable that contains the speed of the enemy
    public float speed = 1f;
    public GameObject EnemyArrow;
    public float shootfreq = 0.1f;
    private Transform target;
    public float enemy_sight = 2f;
    public int HP;
    public GameObject Arrow;
    // Start is called before the first frame update
    void Start()
    {
        //define target for chasing
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        HP = 1;
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
        //make the enemy chase the player
        if(Vector2.Distance(transform.position,target.position) < enemy_sight)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
       
    }

    //Function called when the enemy collides with another object
     void OnTriggerEnter2D(Collider2D obj)
     {
        string name = obj.gameObject.name;

        //if it collided with bullet
        if (name == "arrow(Clone)")
        {
            HP -= obj.GetComponent<Arrow>().damage;
        }
        if (HP <= 0)
        {
            Destroy(gameObject);

            Destroy(obj.gameObject);
        }
        //if it collided with the spaceship
        if (name == "Main")
        {
            Destroy(gameObject);
        }
     } 
    
    void shoot()
    {
        Renderer rd = GetComponent<Renderer>();

        GameObject instance = Instantiate(EnemyArrow, transform.position, transform.rotation);
        instance.GetComponent<Arrow>().damage = 1;
    }

}
