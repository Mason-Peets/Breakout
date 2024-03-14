using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    [SerializeField] float fallSpeed;
    [SerializeField] float livesToAdd;

    private void Update()
    {
        FallDown();
    }
    void FallDown()
    {
        transform.Translate(Vector2.down * Time.deltaTime * fallSpeed);
    }
    public void ApplyPowerUp()
    {
        GameManager.i.UpdateNumberOfLives(1);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bottom Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}