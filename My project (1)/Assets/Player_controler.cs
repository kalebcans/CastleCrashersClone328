using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controler : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public Rigidbody2D m_RigidBody;
    public GameObject lightAttack;
    public GameObject heavyAttack;
    bool attackDelay = false;
        
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_RigidBody.velocity = new Vector2(0, movementSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_RigidBody.velocity = new Vector2(0, -movementSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            m_RigidBody.velocity = new Vector2(-movementSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_RigidBody.velocity = new Vector2(movementSpeed, 0);
        }
        else
            m_RigidBody.velocity = new Vector2(0, 0);

        if(Input.GetKey(KeyCode.J) && !attackDelay)
        {
            attackDelay = true;
            StartCoroutine(lightAtk());
        }
        if(Input.GetKey(KeyCode.K) && !attackDelay)
        {
            attackDelay = true;
            StartCoroutine(heavyAtk());
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
}
