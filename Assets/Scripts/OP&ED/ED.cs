using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ED : MonoBehaviour
{
    // Start is called before the first frame update
    private float s_time;
    public GameObject TextA;
    public GameObject TextB;
    void Start()
    {
        s_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - s_time >= 5 && Time.time - s_time <= 10)
        {
            TextA.SetActive(false);
            TextB.SetActive(true);
        }
        else if (Time.time - s_time > 10)
            SceneManager.LoadScene("Main Menu");
    }
}
