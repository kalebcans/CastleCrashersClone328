using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudMovement : MonoBehaviour
{
    public float speed;
    public float rightBound;
    public float leftBound;

    // Update is called once per frame
    void Update()
    {
    //    _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    transform.position += new Vector3(-speed * Time.deltaTime,0);
    if(transform.position.x < leftBound)
    {
        transform.position = new Vector3(rightBound,transform.position.y);
    }
    }
}
