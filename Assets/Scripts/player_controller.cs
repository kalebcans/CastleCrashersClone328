using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public Rigidbody2D m_RigidBody;
    public GameObject lightAttack;
    public GameObject heavyAttack;
    bool attackDelay = false;
    public SpriteRenderer sr;
    public ParticleSystem dust;

    public float jumpforce = 10.0f;
    public GameObject ground;
    public float offset;
        
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        offset = (transform.position.y - ground.transform.position.y) + 0.1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            m_RigidBody.velocity = new Vector2(-movementSpeed, 0);

            if(sr.flipX == false)
            {
                CreateDust();
                sr.flipX = true;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_RigidBody.velocity = new Vector2(movementSpeed, 0);
            
            if(sr.flipX == true)
            {
                CreateDust();
                sr.flipX = false;
            }
        }
        else
            m_RigidBody.velocity = new Vector2(0, 0);

        if(Input.GetKey(KeyCode.J) && !attackDelay)
        {
            attackDelay = true;
            StartCoroutine(lightAtk());
        }

    }

    void FixedUpdate()
    {
        if(transform.position.y - ground.transform.position.y < offset)
        {
            if(Input.GetButtonDown("Jump"))
            {
                m_RigidBody.AddForce(new Vector2(0, jumpforce));
            }
        }
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

    void CreateDust() 
    {
        dust.Play();
    }
}