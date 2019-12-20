using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InATrapPattern : Pattern
{
    protected override void Initialize()
    {
        StartCoroutine(Timer());



        for (float i = -5; i < 5; i= i+0.1f)
        {
            GameObject bullet = BulletManager.GetInstance().NewItem();
            bullet.GetComponent<Bullet>().SetBullet(-9, i, 0, 3);
            
        }

        for (float i = -5; i < 5; i = i + 0.1f)
        {
            GameObject bullet2 = BulletManager.GetInstance().NewItem();
            bullet2.GetComponent<Bullet>().SetBullet(9, i, 180, 3);
        }
        for (float i = -9; i < 9; i = i + 0.1f)
        {
            GameObject bullet3 = BulletManager.GetInstance().NewItem();
            bullet3.GetComponent<Bullet>().SetBullet(i, 5, 270, 3);
        }



    }

    protected override void PatternUpdate()
    { 
      

    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(2.7f);
        BulletManager.GetInstance().ClearItem();
        GameManager.GetInstance().SetPattern();
        yield return null;
    }
}
