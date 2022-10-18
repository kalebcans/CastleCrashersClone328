using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleController : MonoBehaviour
{
    public string newScene;
    private bool clicked = false;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (other.gameObject.tag == "light")
        {
            anim.SetTrigger("doorTrigger");
            clicked = true;
        }
    }
}
