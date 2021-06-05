using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBet : EnemyController
{
    private int health = 1;

    private void Update()
    {
        if (hitboxChecker.IsEnemy && im.attack && health > 0 && hitboxChecker.HitCol.transform==transform)
        {
            health -= 1;

            if (health == 0)
            {
                Attacked();
            }
        }
    }
}
