using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterSpawnSpiralTurnPattern : Pattern
{

    protected override void Initialize()
    {
        StartCoroutine(Timer());
    }

    protected override void PatternUpdate()
    {

    }

    private IEnumerator Timer()
    {
        for (int i = 0; i < 100; i++) 
        {
            for (int j = 0; j < 360; j += 45) 
            {
                GameObject bullet = BulletManager.GetInstance().NewItem();
                bullet.GetComponent<Bullet>().SetBullet(0, 0, j + ((i - 31) * 0.25f), 8.5f, 1.5f, 0);
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        GameManager.GetInstance().SetPattern();
        yield return null;
    }

}
