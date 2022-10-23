using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public Rigidbody2D m_RigidBody;
    public GameObject lightAttack;
    bool attackDelay = false;
    public SpriteRenderer sr;
    public ParticleSystem dust;
    public int hp;
    public bool dead = false;
    public Sprite deadSprite;
    public DialogueTrigger deathDialogue;
    public DialogueTrigger castleUnlockedDialogue;
    public DialogueTrigger startDialogue;
    public bool called = false;
    public int killCount = 0;
    public int killGoal;
    public float damageCooldown = 2.0f;

    public AudioSource hit;
    public AudioSource deathsound;

    public float jumpforce = 10.0f;
    public GameObject ground;
    public float offset;

    public Animator anim;

    private bool invincible;

    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        offset = (transform.position.y - ground.transform.position.y) + 0.1f;
        anim = gameObject.GetComponent<Animator>();
        startDialogue.TriggerDialogue();
        invincible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (hp <= 0 && !dead)
        {
            StartCoroutine(death());     
        }
        if(dead)
        {
            anim.enabled = (false);
            sr.sprite = deadSprite;
        }
        if (Input.GetKey(KeyCode.A) && !dead)
        {
            m_RigidBody.velocity = new Vector2(-movementSpeed, 0);
            if (sr.flipX == false)
            {
                CreateDust();
                sr.flipX = true;
            }

            anim.Play("Walk");
        }
        else if (Input.GetKey(KeyCode.D) && !dead)
        {
            m_RigidBody.velocity = new Vector2(movementSpeed, 0);
            if (sr.flipX == true)
            {
                CreateDust();
                sr.flipX = false;
            }
            anim.Play("Walk");
        }
        else
            m_RigidBody.velocity = new Vector2(0, 0);

        if(Input.GetKey(KeyCode.J) && !attackDelay && !dead)
        {
            attackDelay = true;
            StartCoroutine(lightAtk());
            anim.Play("Full_Attack");
        }
    }

    IEnumerator invincibility (float seconds)
    {
        invincible = true;

        float timer = seconds;

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            yield return null;
        }

        invincible = false;

        yield return null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "basicEnemyAttack" && invincible == false)
        {
            hit.Play();
            hp--;

            StartCoroutine(invincibility(damageCooldown));
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y - ground.transform.position.y < offset)
        {
            if (Input.GetButtonDown("Jump") && !dead)
            {
                m_RigidBody.AddForce(new Vector2(0, jumpforce));
                anim.Play("Jump");
            }
        }
        if(killCount == killGoal && called == false){
            called = true;
            castleUnlockedDialogue.TriggerDialogue();
        }
    }
    void CreateDust()
    {
        dust.Play();
    }

    public IEnumerator death()
    {
        // stop
        m_RigidBody.velocity = Vector2.zero;
        anim.Play("Death");
        deathDialogue.TriggerDialogue();
        deathsound.Play();
        float elapsed = 0f;
        while (elapsed < 0.5f)
        {
            elapsed += Time.deltaTime;

            yield return null;
        }
        dead = true;
    }

    public IEnumerator lightAtk()
    {
        lightAttack.gameObject.SetActive(true);
        float elapsed = 0.0f;
        while (elapsed < 0.2f)
        {
            elapsed += Time.deltaTime;

            yield return null;
        }
        lightAttack.gameObject.SetActive(false);

        elapsed = 0.0f;
        while (elapsed < 0.3f)
        {
            elapsed += Time.deltaTime;

            yield return null;
        }
        attackDelay = false;
    }

    /*
    public IEnumerator heavyAtk()
    {
        heavyAttack.gameObject.SetActive(true);
        float elapsed = 0.0f;
        while (elapsed < 0.7f)
        {
            elapsed += Time.deltaTime;

            yield return null;
        }
        heavyAttack.gameObject.SetActive(false);

        elapsed = 0.0f;
        while (elapsed < 0.5f)
        {
            elapsed += Time.deltaTime;

            yield return null;
        }
        attackDelay = false;
    }
    */
}