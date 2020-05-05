using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public Font font;
    public GameObject MC;
    public volatile int score = 0;
    private GUIStyle fontStyle = new GUIStyle();
    public volatile int HP;

    // Start is called before the first frame update
    void Start()
    {
        fontStyle.normal.background = null;
        fontStyle.normal.textColor = new Color(1, 1, 1);
        fontStyle.fontSize = 40;
        fontStyle.font = font;
    }
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 40), "HP " + HP.ToString(), fontStyle);
        GUI.Label(new Rect(0, 40, 100, 40), "Score " + score.ToString(), fontStyle);
        if (HP <= 0)
        {
            GUI.Label(new Rect(Screen.width * 0.4f, Screen.height * 0.4f, Screen.width * 0.2f, Screen.height * 0.2f), "Game Over", fontStyle);
            Time.timeScale = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Main"))
            HP = MC.GetComponent<MC>().HP;
        else
            HP = 0;
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