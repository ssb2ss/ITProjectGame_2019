using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSproutPattern : Pattern
{

    protected override void Initialize()
    {
        StartCoroutine(Timer());
    }

    protected override void PatternUpdate()
    {
        GameObject bullet1 = BulletManager.GetInstance().NewItem();

        float angle = Random.Range(20f, 40f);
        float speed = Random.Range(12f, 18f);
        float gravity = Random.Range(0.2f, 0.3f);

        bullet1.GetComponent<Bullet>().SetBullet(-9f, 0, angle, speed, 0, 0, gravity);


        GameObject bullet2 = BulletManager.GetInstance().NewItem();

        angle = Random.Range(140f, 160f);
        speed = Random.Range(12f, 18f);
        gravity = Random.Range(0.2f, 0.3f);

        bullet2.GetComponent<Bullet>().SetBullet(9f, 0, angle, speed, 0, 0, gravity);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(10f);
        GameManager.GetInstance().SetPattern();
        yield return null;
    }
}
