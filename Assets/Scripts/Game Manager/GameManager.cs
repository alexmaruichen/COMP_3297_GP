using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void OnStart()
    {
        SceneManager.LoadScene("Chapter1");
    }
    public void OnResume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void OnExit()
    {
        Application.Quit(); 
    }
}