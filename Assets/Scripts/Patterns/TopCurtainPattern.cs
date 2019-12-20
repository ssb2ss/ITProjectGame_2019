using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCurtainPattern : Pattern
{

    protected override void Initialize()
    {
        StartCoroutine(Timer());
    }

    protected override void PatternUpdate()
    {
        GameObject bullet = BulletManager.GetInstance().NewItem();

        int isLeft = Random.Range(0, 2);
        if(isLeft == 1)
            bullet.GetComponent<Bullet>().SetBullet(0, 5.2f, Random.Range(180f, 266.5f), 10);
        else
            bullet.GetComponent<Bullet>().SetBullet(0, 5.2f, Random.Range(273.5f, 360f), 10);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(10f);
        GameManager.GetInstance().SetPattern();
        yield return null;
    }

}
