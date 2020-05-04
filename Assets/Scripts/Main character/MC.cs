using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject EnemyArrow;
    public GameObject ShootingMethod;
    public Font font;
    public float speed = 2;
    private Rigidbody2D rb;
    private Vector2 v;
    private int HP = 5;
    private int method = 0;
    private int damage = 1;
    private float shootfreq = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", shootfreq, shootfreq);
    }
    void shoot()
    {
        ShootingMethod.GetComponent<Shoot>().shoot(method, Arrow, transform, damage);
    }
    // Update is called once per frame
    void OnGUI()
    {
        GUIStyle fontStyle = new GUIStyle();
        fontStyle.normal.background = null;  
        fontStyle.normal.textColor = new Color(1, 1, 1);
        fontStyle.fontSize = 40;
        fontStyle.font = font;
        GUI.Label(new Rect(0, 0, 100, 30), "HP " + HP.ToString(), fontStyle);
    }

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
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = 360 - Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}