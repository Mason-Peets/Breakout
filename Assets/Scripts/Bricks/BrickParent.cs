using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickParent : MonoBehaviour
{
    [SerializeField] protected int hitPoints;
    [SerializeField] protected int pointValue;
    [SerializeField] protected List<Sprite> damageSprites = new List<Sprite>();
    [SerializeField] int currentIndex;

    public virtual void TakeDamage(int damageAmount)
    {
        print("Taking Damage in parent");

    }
    protected void DamageBrick()
    {
        currentIndex++;
        currentIndex %= damageSprites.Count;


        GetComponent<SpriteRenderer>().sprite = damageSprites[currentIndex];


        //scale the brick
    }
}

