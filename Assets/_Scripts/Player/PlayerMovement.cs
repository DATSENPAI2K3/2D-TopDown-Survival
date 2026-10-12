using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    Rigidbody2D rb;
    Vector2 getInput = new Vector2();
    public float Speed = 10f;
    private Animator animator;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        this.GetInput();
        this.UpdateAnimation();
    }
    private void FixedUpdate()
    {
        this.MovingPlayer();
    }
    void GetInput()
    {
    #if UNITY_ANDROID || UNITY_IOS
        // lay tu joystick
        this.getInput.x = this.joystick.Horizontal;
        this.getInput.y = this.joystick.Vertical;
    #else
        // lay tu ban phim
        this.getInput.x = Input.GetAxis("Horizontal");
        this.getInput.y = Input.GetAxis("Vertical");
    #endif
    }
    private void MovingPlayer()
    {
        rb.MovePosition(this.rb.position + getInput.normalized * Speed * Time.fixedDeltaTime);
        if(this.getInput.x < 0) spriteRenderer.flipX = false;
        else if (this.getInput.x > 0) spriteRenderer.flipX = true;
    }
    private void UpdateAnimation()
    {
        float SpeedAnimation = this.getInput.magnitude;
        this.animator.SetFloat("Speed", SpeedAnimation);
    }
}
