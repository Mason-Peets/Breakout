using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float ballSpeed = 500f;
    [SerializeField] Transform startPosition;

    bool inPlay = false;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!inPlay)
        {
            transform.position = startPosition.position;
        }
       if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * ballSpeed);

        }
    }

    public  void ResetBall()
    {
        transform.position = startPosition.position;
        inPlay = false;
        rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bottom Wall"))
        {
           ResetBall();
            GameManager.i.UpdateNumberOfLives(-1);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            other.gameObject.GetComponent<BrickParent>().TakeDamage(1);
        }
    }
}
