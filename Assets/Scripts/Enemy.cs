using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    public int health = 3;
    public float moveRange = 4;
    public float attackRange = 1.3f;
    public float attackCooldown = 2;
    public float coroutineRefresh = 1;
    public AudioSource hit;
    public AudioSource deathsound;

    private bool coroutineRunning;
    private string enemyType;
    private GameObject player;
    private GameObject basicEnemyAttack;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] spawnedAttacks = GameObject.FindGameObjectsWithTag("basicEnemyAttack");
        basicEnemyAttack = spawnedAttacks[spawnedAttacks.Length - 1];
        basicEnemyAttack.SetActive(false);

        // todo: random number generator for enemy type?
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(death());
        }

        if (!coroutineRunning)
        {
            Vector2 playerPosition = player.GetComponent<Rigidbody2D>().position;
            float distanceFromPlayer = Vector2.Distance(rigidBody.position, playerPosition);

            if (distanceFromPlayer < attackRange + 1.5)
            {
                // attack
                StartCoroutine(attack());
            }
            else
            {
                // approach player
                StartCoroutine(move('f'));
            }
        }
    }

    public IEnumerator death()
    {
        // stop
        rigidBody.velocity = Vector2.zero;

        deathsound.Play();
        float elapsed = 0f;
        while (elapsed < 0.5f)
        {
            elapsed += Time.deltaTime;

            yield return null;
        }
        Destroy(this.gameObject);

        coroutineRunning = false;
    }


    IEnumerator attack()

    {
        coroutineRunning = true;

        // stop
        rigidBody.velocity = Vector2.zero;

        basicEnemyAttack.SetActive(true);

        float timer = 0;
        float attackTime = 0.2f;

        while (timer < attackTime)
        {
            timer += Time.deltaTime;

            yield return null;
        }

        basicEnemyAttack.SetActive(false);

        while (timer - attackTime < attackCooldown)
        {
            timer += Time.deltaTime;

            yield return null;
        }

        coroutineRunning = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "light")
        {
            hit.Play();
            health--;
        }
    }

    IEnumerator move(char direction)
    {
        coroutineRunning = true;

        switch (direction)
        {
            default:
                // idle
                rigidBody.velocity = Vector2.zero;

                break;

            case 'l':
                // move left
                spriteRenderer.flipX = true;
                rigidBody.velocity = Vector2.left;

                break;

            case 'r':
                // move right
                spriteRenderer.flipX = false;
                rigidBody.velocity = Vector2.right;

                break;

            case 'f':
                // "follow" player (move left or right depending on player position)
                Vector2 playerPosition = player.GetComponent<Rigidbody2D>().position;

                // if player is to the right of the enemy
                if (playerPosition.x > rigidBody.position.x)
                {
                    // move right
                    spriteRenderer.flipX = false;
                    rigidBody.velocity = Vector2.right;
                }
                else
                {
                    // move left
                    spriteRenderer.flipX = true;
                    rigidBody.velocity = Vector2.left;
                }

                break;
        }


        yield return new WaitForSecondsRealtime(coroutineRefresh);


        coroutineRunning = false;
    }
}