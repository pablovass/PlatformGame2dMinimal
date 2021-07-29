using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]  float speed=8f;
    [SerializeField]  float speedJump=300f;
    [SerializeField]  Rigidbody2D playerRb;
    bool isGrounded = true;
    [SerializeField]  Animator anim;
    private Vector3 moveDirection;
    float h;
  

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        moveDirection.x = h;

        //move the character from left to right with speed
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);
        // new stile move
        transform.position += moveDirection * Time.deltaTime * speed;

        if (Input.GetAxis("Horizontal")<0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }else if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //condicional jump
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(Vector2.up * speedJump);
                isGrounded = false;
                anim.SetTrigger("Jump");
            }

        }

        anim.SetFloat("Speed", moveDirection.magnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
