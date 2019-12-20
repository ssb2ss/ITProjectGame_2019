using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{

    public bool isInit, isReady;

    private void Awake()
    {
        isInit = false;
        isReady = false;
    }

    private void Update()
    {
        if (isInit)
        {
            Initialize();
            isInit = false;
            isReady = true;
        }
        if(isReady)
        {
            PatternUpdate();
        }
    }

    protected virtual void Initialize() { }

    protected virtual void PatternUpdate() { }

    //총알 생성할 때
    //GameObject bullet = BulletManager.GetInstance().NewItem();
    //bullet.GetComponent<Bullet>().SetBullet(x, y, _angle, _speed[, angleRate, speedRate]);

}
