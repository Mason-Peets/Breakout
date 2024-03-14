using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBrick : BrickParent
{


    public override void TakeDamage(int damageAmount)
    {
        DamageBrick();
    }
}
