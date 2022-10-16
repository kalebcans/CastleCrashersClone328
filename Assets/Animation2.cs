using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation2 : MonoBehaviour
{
 /*   public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyUp("space"))
        {
            anim.Play("Jump");
        } 
        if (Input.GetKeyUp("d"))
        {
            anim.Play("Walk");
        }
        if (Input.GetKeyUp("a"))
        {
            anim.Play("Walk");
        }
         if (Input.GetKeyUp("j"))
        {
            anim.Play("LightAttack");
        }
    } */
    public Animator anim;
  // Use this for initialization
  void Start2()
  {
      anim = gameObject.GetComponent<Animator>();
  }
  // Update is called once per frame
  void Update2()
  {
     if (Input.GetKeyDown(KeyCode.RightShift))
          anim.Play("Jump2");
     if (Input.GetKeyDown(KeyCode.LeftArrow))
          anim.Play("Walk2");
     if (Input.GetKeyDown(KeyCode.RightArrow))
          anim.Play("Walk2");
     if (Input.GetKeyDown(KeyCode.Slash))
          anim.Play("LightAttack2");
  }
} 
