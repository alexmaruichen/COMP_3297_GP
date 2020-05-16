using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int method;
    public AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        string name = obj.gameObject.name;
        if (name == "Main")
        {
            AudioSource.PlayClipAtPoint(AS.clip, transform.position);
            Destroy(gameObject);
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
