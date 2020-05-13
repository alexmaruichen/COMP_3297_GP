using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MC : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject EnemyArrow;
    public GameObject ShootingMethod;
    public Camera Main_Camera;
    public Font font;
    public float speed = 2;
    public volatile int HP = 5;
    private Rigidbody2D rb;
    private Vector2 v;
    private int method = 0;
    private int damage = 1;
    private float shootfreq = 1f;
    private float xmin, xmax, ymin, ymax, cHeight, cWidth;

    // Start is called before the first frame update
    void Start()
    {
        cHeight = Main_Camera.orthographicSize * 2;
        cWidth = cHeight * Screen.width / Screen.height;
        xmin = cWidth / 2;
        xmax = 30 - cWidth / 2;
        ymax = -cHeight / 2;
        ymin = -(30 - cHeight / 2);
        InvokeRepeating("shoot", shootfreq, shootfreq);
    }
    void shoot()
    {
        ShootingMethod.GetComponent<Shoot>().shoot(method, Arrow, transform, damage);
    }
    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D obj)
    {
        string name = obj.gameObject.name;
        string tag = obj.gameObject.tag;

        //if it collided with bullet
        if (name == "EnemyArrow(Clone)")
        {
            HP -= obj.GetComponent<Arrow>().damage;
        }
        else if (tag == "Enemy")
            HP -= 1;
        else if (tag == "Item")
            method = obj.gameObject.GetComponent<Item>().method;
        if (HP <= 0)
        {
            Destroy(gameObject);
            Destroy(obj.gameObject);
        }
        //if it collided with the spaceship
    }
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        v = rb.velocity;
        v.x = Input.GetAxis("Horizontal") * speed;
        v.y = Input.GetAxis("Vertical") * speed;
        rb.velocity = v;
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, xmin, xmax), Mathf.Clamp(rb.position.y, ymin, ymax));
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = 360 - Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}