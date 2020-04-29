using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // method 1 : normal
    // method 2 : wide
    // method 3 : double speed
    public void shoot(int method, GameObject GO, Transform GO_Transform, int damage)
    {
        GameObject instance = Instantiate(GO, GO_Transform.position, GO_Transform.rotation);
        instance.GetComponent<Arrow>().damage = damage;
        if (method == 0) ;
        if (method == 1)
        {
            Vector3 euler = GO_Transform.eulerAngles;
            euler.z += 30;
            GO_Transform.eulerAngles = euler;
            instance = Instantiate(GO, GO_Transform.position, GO_Transform.rotation);
            instance.GetComponent<Arrow>().damage = damage;
            euler.z += 300;
            GO_Transform.eulerAngles = euler;
            instance = Instantiate(GO, GO_Transform.position, GO_Transform.rotation);
            instance.GetComponent<Arrow>().damage = damage;
        }
        if (method == 2)
            instance.GetComponent<Arrow>().speed *= 2;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
