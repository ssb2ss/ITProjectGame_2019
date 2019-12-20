using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowestExceptHorizontalLineShootPattern : Pattern
{

    float minGravity;
    float angleChange;


    protected override void Initialize()
    {
        minGravity = 0.01f;
        angleChange = 1f;

        StartCoroutine(Timer());
    }

    protected override void PatternUpdate()
    {
        GameObject bullet1 = BulletManager.GetInstance().NewItem();
        GameObject bullet2 = BulletManager.GetInstance().NewItem();
        angleChange += 1;
        if (angleChange >= 40)
            angleChange = 40;


        bullet1.GetComponent<Bullet>().SetBullet(-9, -3.5f, Random.Range(60f- angleChange, 60f+ angleChange), 10,  0,  0, 0.05f);
        bullet2.GetComponent<Bullet>().SetBullet(9, -3.5f, Random.Range(120f- angleChange, 120f+angleChange), 10, 0, 0, 0.05f);

    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(10f);
        GameManager.GetInstance().SetPattern();
        yield return null;
    }
}
