using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }


    // Update is called once per frame
    void LateUpdate()
    { 
        if(player.transform.position.x >= -15f && player.transform.position.x <= 4.4f)
            transform.position = new Vector3(player.transform.position.x + offset.x, 2.5f, -10);
    }
}
