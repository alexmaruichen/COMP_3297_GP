using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject p_menu;
    public GameObject g_menu;
    public GameObject StageClear;
    public Font font;
    public GameObject MC;
    public volatile int score = 0;
    private GUIStyle fontStyle = new GUIStyle();
    public volatile int HP;
    private float s_time = 0;

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
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            GUI.Label(new Rect(0, 0, 100, 40), "HP " + HP.ToString(), fontStyle);
            GUI.Label(new Rect(0, 40, 100, 40), "Score " + score.ToString(), fontStyle);
            if (HP <= 0)
            {
                g_menu.SetActive(true);
                Time.timeScale = 0;
            }
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
            p_menu.SetActive(true);
            Time.timeScale = 0;
        }
        if (p_menu.active == false)
            Time.timeScale = 1;
        if (! GameObject.FindGameObjectWithTag("Enemy"))
        {
            StageClear.SetActive(true);
            if (s_time == 0)
                s_time = Time.time;
            if (Time.time - s_time >= 3)
            {
                s_time = 0;
                string scene_name = SceneManager.GetActiveScene().name;
                char[] str = scene_name.ToCharArray();
                str[scene_name.Length - 1] = (char)((int)(str[scene_name.Length - 1]) + 1);
                scene_name = new string(str);
                SceneManager.LoadScene(scene_name);
            }
        }
    }
    public void OnStart()
    {
        SceneManager.LoadScene("Opening");
        Time.timeScale = 1;
    }
    public void OnResume()
    {
        p_menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        OnResume();
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