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

    private void Awake()
    {

        myBody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        PlayerMoveKeyboard();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        transform.position += new UnityEngine.Vector3(movementX, movementY + gravity, 0f) * Time.deltaTime * moveForce;
    }
}
