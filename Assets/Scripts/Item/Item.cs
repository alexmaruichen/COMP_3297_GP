using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int method;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        string name = obj.gameObject.name;
        if (name == "Main")
            Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
