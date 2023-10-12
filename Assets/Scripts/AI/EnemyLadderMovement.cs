using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLadderMovement : MonoBehaviour
{
    /*private float speed = 3f;
    private bool isClimbing = false;
    private Vector2 ladderDirection;

    private Rigidbody2D rb;
    private MeleeEnemyAI enemyAI;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAI = GetComponent<MeleeEnemyAI>();
    }

    void Update()
    {
        if (isClimbing)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime * ladderDirection.y, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder") && !isClimbing)
        {
            if (enemyAI.ShouldClimbLadder())
            {
                StartClimbing(collision.transform);
            }
        }
    }

    private void StartClimbing(Transform ladderTransform)
    {
        isClimbing = true;
        rb.gravityScale = 0;
        ladderDirection = (ladderTransform.position.y > transform.position.y) ? Vector2.up : Vector2.down;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.gravityScale = 1;
        }
    }*/
}
