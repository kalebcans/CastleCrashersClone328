using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleController : MonoBehaviour
{
    public string newScene;
    private bool clicked = false;
    public Animator anim;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "light" && clicked ==true)
        {
            SceneManager.LoadScene(newScene);
        }
        if (other.gameObject.tag == "light" && player.GetComponent<player_controller>().killCount > player.GetComponent<player_controller>().killGoal)
        {
            anim.SetTrigger("doorTrigger");
            clicked = true;
        }
    }
}
