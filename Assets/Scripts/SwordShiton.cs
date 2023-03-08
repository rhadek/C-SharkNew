using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordShiton : MonoBehaviour
{
    // Reference to the player's capsule collider
    public CapsuleCollider2D playerCollider;
    public int damage = 80;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is an enemy with a capsule collider
        if (other.CompareTag("Enemy") /*&& other.GetType() == typeof(CapsuleCollider2D*//*)*/)
        {
            // Destroy the enemy game object
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
