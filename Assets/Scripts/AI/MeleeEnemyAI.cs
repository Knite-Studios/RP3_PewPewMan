using UnityEngine;

public class MeleeEnemyAI : EnemyAI
{
    public float moveSpeed = 1.5f;
    public float detectionRadius = 5f;
    public float explosionRadius = 1f;
    private bool isFacingRight = true;

    private Transform player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;

    private float groundDetectionDistance = 0.5f;
    private float wallDetectionDistance = 0.5f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Player detection
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= explosionRadius)
        {
            // Get the PlayerHealth component and deal damage
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);//damage amount
            }

            Die();
        }
        else if (distanceToPlayer <= detectionRadius)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * (isFacingRight ? 1 : -1));

        // Ground and wall detection for turning around
        bool groundAhead = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDetectionDistance, LayerMask.GetMask("Ground"));
        bool wallAhead = Physics2D.Raycast(wallCheck.position, transform.right, wallDetectionDistance, LayerMask.GetMask("Wall"));

        if (!groundAhead || wallAhead)
        {
            Flip();
        }
    }

    private void ChasePlayer()
    {
        if (player.position.x > transform.position.x && !isFacingRight)
        {
            Flip();
        }
        else if (player.position.x < transform.position.x && isFacingRight)
        {
            Flip();
        }
        
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), moveSpeed * Time.deltaTime);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
