using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource dead;
    public int health = 100;
    public GameObject deatheffect;
    public float delayTime = 0.5f;
    public float transparency = 0.5f;
    private int i = 0;
    public int maxhealth;
    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        maxhealth = health;
        healthBar.UpdateHealthBar(maxhealth, health);
    }
    private void Update()
    {
        healthBar.UpdateHealthBar(maxhealth, health);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (i < 1)
        {
            if (health <= 0)
            {
                Die();
                i++;
            }
        }
        
    }
    void Die()
    {
        Instantiate(deatheffect, transform.position, Quaternion.identity);
        
        dead.Play();
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            Material material = renderer.material;
            Color color = material.color;
            color.a = transparency;
            material.color = color;
        }
        Destroy(gameObject, delayTime);
        i = 0;
    }

    public bool isDead()
    {
        if (health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
