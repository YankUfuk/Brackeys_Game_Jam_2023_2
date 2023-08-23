using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //movement on x and y axis.
    [SerializeField] float moveForce = 10f;
    private float movementX;
    private float movementY;
    private float gravity = -0.1f;

    //other components
    [SerializeField] private Rigidbody2D myBody;
    private SpriteRenderer sr;
    
    //mouselook
    public Camera cam;
    UnityEngine.Vector2 movement, mousePos;

    //player's health
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMoveKeyboard();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        MouseLook();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");
        transform.position += new UnityEngine.Vector3(movementX, movementY + gravity, 0f) * Time.deltaTime * moveForce;
    }

    void MouseLook()
    {
        UnityEngine.Vector2 lookDir = mousePos - myBody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        myBody.rotation = angle;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
