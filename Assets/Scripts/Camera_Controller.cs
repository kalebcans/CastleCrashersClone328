using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public int start;
    public int end;
    public float y;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > start && player.transform.position.x < end)
        {
            transform.position = new Vector3(player.transform.position.x,y,-10.0f);
        }

        
    }
}
