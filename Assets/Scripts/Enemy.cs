using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;

    public AudioSource hit;
    public AudioSource deathsound;
    private bool coroutineRunning;
    public int health;
    private string enemyType;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // todo: random number generator for enemy type?
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            StartCoroutine(death());
            
        }
        // this can be enumerated
        if (!coroutineRunning)
        {
            switch (Random.Range(0, 3))
            {
                default:
                    // calls default idling behavior
                    StartCoroutine(move('i'));

                    break;

                case 1:
                    StartCoroutine(move('l'));

                    break;

                case 2:
                    StartCoroutine(move('r'));

                    break;
            }
        }
    }

    public IEnumerator death()
    {
        deathsound.Play();
        float elapsed = 0f;
        while (elapsed < 0.5f)
        {
            elapsed += Time.deltaTime;

            yield return null;
        }
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "light")
        {
            hit.Play();
            health--;
        }
    }

    IEnumerator move (char direction)
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
        }

        yield return new WaitForSecondsRealtime (4);

        coroutineRunning = false;
    }
}
