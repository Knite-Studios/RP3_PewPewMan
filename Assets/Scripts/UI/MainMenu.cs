using System;
using UnityEngine;

public class MainMenu : Singleton<MainMenu>
{
    public GameObject mainMenu;
    public GameObject warningMenu;
    public float waitTime = 5f;
    float timer = 0;

    private int loadingSceneIndex = 1;

    void Start()
    {
        mainMenu.SetActive(false);
        warningMenu.SetActive(true);
    }

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
            UnityEngine.SceneManagement.SceneManager.LoadScene(loadingSceneIndex);
        }
    }
}
