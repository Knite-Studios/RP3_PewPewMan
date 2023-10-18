using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
[RequireComponent(typeof(TilemapCollider2D),typeof(CompositeCollider2D))]
public class Spike : MonoBehaviour
{
    private void Awake()
    {
        TilemapCollider2D b = GetComponent<TilemapCollider2D>(); 
        b.usedByComposite = true;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        CompositeCollider2D a = GetComponent<CompositeCollider2D>();
        a.isTrigger = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(5);
        }   
    }
}
