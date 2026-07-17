using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    public int hp = 3;

    public int damage = 1;
    public float attackCooldown = 1f;

    private Rigidbody2D rb;
    private float attackTimer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }


    private void FixedUpdate()
    {
        if (player == null)
            return;

        Vector2 direction = (player.position - transform.position).normalized;

        rb.linearVelocity = direction * speed;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

                if (health != null)
                {
                    health.TakeDamage(damage);
                }

                attackTimer = attackCooldown;
            }
        }
    }


    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}