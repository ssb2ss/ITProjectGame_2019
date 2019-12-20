using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPattern : Pattern
{

    GameObject[,] bullet;

    protected override void Initialize()
    {
        bullet = new GameObject[2, 63];

        StartCoroutine(Timer());
    }

    protected override void PatternUpdate()
    {

    }

    private IEnumerator Timer()
    {
        for (int i = 0; i < 63; i++)
        {
            float x = (2 * Mathf.Sin(3 * i / 10f) - 5 * Mathf.Sin(2 * i / 10f)) / 2f - 5f;
            float y = (5 * Mathf.Cos(2 * i / 10f) + 2 * Mathf.Cos(3 * i / 10f)) / 2f;

            bullet[0, i] = BulletManager.GetInstance().NewItem();
            bullet[0, i].GetComponent<Bullet>().SetBullet(x, y, 45, 0);

            x = (2 * Mathf.Sin(3 * i / 10f) - 5 * Mathf.Sin(2 * i / 10f)) / 2f + 5f;
            y = (5 * Mathf.Cos(2 * i / 10f) + 2 * Mathf.Cos(3 * i / 10f)) / 2f;

            bullet[1, i] = BulletManager.GetInstance().NewItem();
            bullet[1, i].GetComponent<Bullet>().SetBullet(x, y, 135, 0);

            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 2; i++) 
        {
            for (int j = 0; j < 63; j++)
            {
                bullet[i, j].GetComponent<Bullet>().SetSpeed(10);
                bullet[i, j].GetComponent<Bullet>().SetGravity(0.2f);
            }
        }
        yield return new WaitForSeconds(2f);
        GameManager.GetInstance().SetPattern();
        yield return null;
    }

}
