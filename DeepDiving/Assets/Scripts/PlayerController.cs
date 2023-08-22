using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveForce = 10f;
    private float movementX;
    private float movementY;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private float gravity = -0.1f;
    private bool isFacingRight = true;

    private void Awake()
    {

        myBody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        PlayerMoveKeyboard();
        //Flip();

        if(movementX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if(movementX < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        transform.position += new UnityEngine.Vector3(movementX, movementY + gravity, 0f) * Time.deltaTime * moveForce;
    }

    private void Flip()
    {
        







        //if(isFacingRight && movementX < 0f || !isFacingRight && movementX > 0f)
        //{
            isFacingRight = !isFacingRight;
            //UnityEngine.Vector3 localScale = transform.localScale;
            //localScale.x *= -1;
            //transform.localScale = localScale;
            transform.Rotate(0f, 180f, 0f);
        //}
        
    }
}
