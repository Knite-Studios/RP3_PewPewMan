using UnityEngine;

public class MeleeEnemyAI : EnemyAI
{
    public float patrolDistanceLeft = 3f; // Distance to patrol to the left from the starting position.
    public float patrolDistanceRight = 3f; // Distance to patrol to the right from the starting position.
    private float leftBoundary;
    private float rightBoundary;
    private bool movingRight = true;
    public float moveSpeed = 1.5f;
    private Vector3 startingPosition;
    public int explosionDamage = 10;
    public ParticleSystem deathEffect;

    public Sprite normalSprite;
    public Sprite damagedSprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        startingPosition = transform.position;
        leftBoundary = startingPosition.x - patrolDistanceLeft;
        rightBoundary = startingPosition.x + patrolDistanceRight;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (movingRight && transform.position.x >= rightBoundary || 
            !movingRight && transform.position.x <= leftBoundary)
        {
            movingRight = !movingRight;
            Flip();
        }

        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * (movingRight ? 1 : -1));
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public override void TakeDamage(int damage)
    {
        if (health == 2)
        {
            spriteRenderer.sprite = damagedSprite;
        }

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackPlayer(collision);
            Die();
        }
    }

    void AttackPlayer(Collider2D collision)
    {
        PlayerData playerData = collision.gameObject.GetComponent<PlayerController>().playerData;
        if (playerData != null)
        {
            playerData.player.health -= explosionDamage;
            playerData.player.health = Mathf.Max(playerData.player.health, 0);
        }
    }
}
