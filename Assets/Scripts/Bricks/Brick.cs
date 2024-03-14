using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : BrickParent
{

    [SerializeField] Transform brickExplosion;
    [SerializeField] Transform contents;
    public override void TakeDamage(int damageAmount)
    {
        print("Taking Damage in child");
        hitPoints -= damageAmount;
        if(hitPoints <= 0)
        {
            ApplyBrickEffect();
            DestroyBrick();
            
        }
        else
        {
            DamageBrick();
        }

        base.TakeDamage(damageAmount);

    }
   void ApplyBrickEffect()
    {
        if (Random.Range(0f, 1f) > .5)
        {
            Instantiate(contents, transform.position, Quaternion.identity);
        }
    }
    void DestroyBrick()
    {
        GameManager.i.UpdateNumberOfBricks();
        GameManager.i.UpdateScore(pointValue);
        var go = Instantiate(brickExplosion, transform.position, transform.rotation);

        Destroy(go.gameObject, 2.25f);
        Destroy(gameObject);
    }
}
