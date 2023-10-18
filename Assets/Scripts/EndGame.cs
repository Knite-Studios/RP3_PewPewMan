using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class EndGame : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    private string mainMenuSceneName = "MainMenu";

    void Update()
    {
        if(playerData.player.health <= 0)
        {
            LoadMainMenu();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LoadMainMenu();
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
