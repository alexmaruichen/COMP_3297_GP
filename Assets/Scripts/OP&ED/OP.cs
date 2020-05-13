using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OP : MonoBehaviour
{
    private float s_time;

    // Start is called before the first frame update
    void Start()
    {
        s_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - s_time >= 5)
            SceneManager.LoadScene("Chapter1");
    }
}
