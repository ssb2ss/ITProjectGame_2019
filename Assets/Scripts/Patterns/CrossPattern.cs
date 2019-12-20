using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossPattern : Pattern
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
        for (int i = 0; i < 25; i++)
        {
            for (float x = -9f; x <= 9f; x += 2f)
            {
                GameObject bullet1 = BulletManager.GetInstance().NewItem();
                bullet1.GetComponent<Bullet>().SetBullet(x, 5.2f, 270, 4);
                GameObject bullet2 = BulletManager.GetInstance().NewItem();
                bullet2.GetComponent<Bullet>().SetBullet(x, -5.2f, 90, 4);
            }
            for (float y = -5f; y <= 5f; y += 2f)
            {
                GameObject bullet1 = BulletManager.GetInstance().NewItem();
                bullet1.GetComponent<Bullet>().SetBullet(-9.2f, y, 0, 4);
                GameObject bullet2 = BulletManager.GetInstance().NewItem();
                bullet2.GetComponent<Bullet>().SetBullet(9.2f, y, 180, 4);
            }
            yield return new WaitForSeconds(0.4f);
        }
        yield return new WaitForSeconds(1f);
        GameManager.GetInstance().SetPattern();
        yield return null;
    }

}
