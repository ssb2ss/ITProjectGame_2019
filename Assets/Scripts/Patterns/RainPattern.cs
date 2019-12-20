using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainPattern : Pattern
{

    protected override void Initialize()
    {
        StartCoroutine(Timer());
    }

    protected override void PatternUpdate()
    {
        float x;

        int isLeft = Random.Range(0, 2);
        if (isLeft == 1)
            x = Random.Range(-8f, 0.9f);
        else
            x = Random.Range(2.2f, 10f);

        GameObject bullet = BulletManager.GetInstance().NewItem();
        bullet.GetComponent<Bullet>().SetBullet(x, 5.2f, 260, 10);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(10f);
        GameManager.GetInstance().SetPattern();
        yield return null;
    }
}
