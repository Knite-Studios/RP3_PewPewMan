using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Singleton<MainMenu>
{
    public GameObject mainMenu;
    public GameObject warningMenu;
    public float waitTime = 5f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(false);
        warningMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if(timer > waitTime)
        {
            mainMenu.SetActive(true);
            warningMenu.SetActive(false);
        }
     if(Input.GetKeyDown(KeyCode.J) && timer > waitTime)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}
