using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Transform startPoint;
    Camera camera;
    Rigidbody2D rb;
    bool movePlayer = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    private void OnMouseDrag()
    {
        if(movePlayer)
            rb.position = camera.ScreenToWorldPoint(Input.mousePosition);

    }
    private void OnMouseUp()
    {
        movePlayer = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "wall")
        {
            transform.position = startPoint.position;
            movePlayer = false;
        }
        
        if(col.tag == "background")
        {
            movePlayer = false;
        }
    }
}
