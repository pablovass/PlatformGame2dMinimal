using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    Rigidbody2D enemyRb;

    private float timeBeforeChange;

    [SerializeField]  float delay = .5f;
    [SerializeField]  float speed = .3f;
    private SpriteRenderer enemySpriteRenderer;

    private Animator enemyAnim;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //se voltea
        if (speed>0)
        {
            enemySpriteRenderer.flipX = false;
        }
        else if(speed<0)
        {
            enemySpriteRenderer.flipX = true;
        }
        //MOVE ENEMY
        enemyRb.velocity = Vector2.right * speed;
        //CADA 5 SEGUNDO CAMINA DE UN LADO AL OTRO
        if (timeBeforeChange < Time.time)
        {
            speed *= -1;
            timeBeforeChange = Time.time + delay;
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (transform.position.y +.03f < collision.transform.position.y)
            {
                enemyAnim.SetBool("isDead",true);
            }
        }
    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
