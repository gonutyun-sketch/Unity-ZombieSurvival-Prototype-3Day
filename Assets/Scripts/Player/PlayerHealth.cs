using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 10;

    public void TakeDamage(int damage)
    {
        hp -= damage;

        Debug.Log("Player HP : " + hp);

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Game Over");
    }
}