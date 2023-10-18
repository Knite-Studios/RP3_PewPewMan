using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLevel : MonoBehaviour
{
    [SerializeField] private int levelNum;
    [SerializeField] private bool endgame = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !endgame)
        {
             SceneManager.LoadScene(levelNum);
        }
        else if (collision.CompareTag("Player") && endgame)
        {
            EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
