using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed;

    float edge = 3.9f;

    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * paddleSpeed);

        if (transform.position.x < -edge)
        {
            transform.position = new Vector2(-edge, transform.position.y);
        }
        if (transform.position.x > edge)
        {
            transform.position = new Vector2(edge, transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUps"))
        {
            other.GetComponent<ExtraLife>().ApplyPowerUp();
            Destroy(other.gameObject);
        }
    }
}
