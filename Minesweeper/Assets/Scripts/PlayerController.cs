using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {


    public float health;
    public Text healthDisplay;
    //private Player player;

    //public float speed;
    //private Rigidbody2D rb;
    //private Animator anim;
    //private Vector2 moveVelocity;

    //private void Start()
    //{
    //    anim = GetComponent<Animator>();
    //    rb = GetComponent<Rigidbody2D>();
    //}

    private void Update()
    {

        healthDisplay.text = health.ToString();

        //Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //moveVelocity = moveInput.normalized * speed;

        //if (moveInput != Vector2.zero)
        //{
        //    anim.SetBool("isRunning", true);
        //}
        //else {
        //    anim.SetBool("isRunning", false);
        //}
    }

    //private void FixedUpdate()
    //{
    //    rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    //}
}
