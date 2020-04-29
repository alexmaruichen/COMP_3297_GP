using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC : MonoBehaviour
{
    public GameObject arrow;
    public GameObject EnemyArrow;
    private Rigidbody2D rb;
    private Vector2 v;
    public int HP;

    // Start is called before the first frame update
    void Start()
    {
        HP = 5;
    }

    // Update is called once per frame
    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 90), HP.ToString());
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
        else if (tag == "enemy")
        {
            HP -= 1;
        }
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
        v.x = Input.GetAxis("Horizontal") * 2;
        v.y = Input.GetAxis("Vertical") * 2;
        rb.velocity = v;
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = 360 - Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
        if (Input.GetMouseButtonDown(0))
        {
            GameObject instance = Instantiate(arrow, transform.position, transform.rotation);
            instance.GetComponent<Arrow>().damage = 1;
        }
    }
}