using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC : MonoBehaviour
{
    public GameObject arrow;
    private Rigidbody2D rb;
    private Vector2 v;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
        if (Input.GetKeyDown("space"))
        {
            Instantiate(arrow, transform.position, transform.rotation);
        }
    }
}