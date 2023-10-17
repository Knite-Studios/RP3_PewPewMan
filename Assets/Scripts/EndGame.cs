using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EndGame : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
      if(playerData.player.health <= 0)
        {
        Application.Quit();
        EditorApplication.isPlaying = false;
      }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Application.Quit();
            EditorApplication.isPlaying = false;
        }
    }
}