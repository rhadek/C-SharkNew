using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource dead;
    public int health = 0;
    public GameObject deatheffect;
    public float delayTime = 0.5f;
    public float transparency = 0.5f;
    private int i = 0;
    public int maxhealth = 100;
    [SerializeField] private HealthBar healthBar;
    public GameObject player;
    public bool flip;
    public float speed;
    public float Startspeed;
    public Animator animator;
    public BoxCollider2D enemyCollider;
    public int damage = 30;
    private void Start()
    {
        health = maxhealth;
        healthBar.UpdateHealthBar(maxhealth, health);
        Startspeed = speed;
    }
    public void Update()
    {
        healthBar.UpdateHealthBar(maxhealth, health);
        Vector3 scale = transform.localScale;
        if (Mathf.Abs(player.transform.position.x - transform.position.x) > 0.1f)
        {
            if (player.transform.position.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
                transform.Translate(speed * Time.deltaTime, 0, 0);
                animator.SetFloat("Run", 1);
            }
            else
            {
                scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
                transform.Translate(speed * Time.deltaTime * -1, 0, 0);
                animator.SetFloat("Run", 1);
            }
            transform.localScale = scale;
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") /*&& other.GetType() == typeof(CapsuleCollider2D*//*)*/)
        {
            // Destroy the enemy game object
            if (enemyCollider.enabled == true)
            {

                PlayerHealth player = other.GetComponent<PlayerHealth>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }
            }

        }
    }
    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetFloat("Attack", 0);
        speed = Startspeed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {

            Rigidbody2D playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                speed = 0f;
                animator.SetFloat("Attack", 1);
                StartCoroutine(ResetAttack());
            }
        }
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
        animator.SetFloat("Death", 1);
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
