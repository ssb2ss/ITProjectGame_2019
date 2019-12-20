using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float angle, angleRate;
    public float speed, speedRate;
    public float gravityScale, gravity, gravityAngle;

    public void SetBullet(float x, float y, float _angle, float _speed, float _angleRate = 0, float _speedRate = 0, float _gravity = 0, float _gravityAngle = 270)
    {
        float r = Random.Range(0.6f, 1);
        float g = Random.Range(0.6f, 1);
        float b = Random.Range(0.6f, 1);

        GetComponent<SpriteRenderer>().color = new Color(r, g, b, 1);
        transform.position = new Vector3(x, y);
        angle = _angle;
        speed = _speed;
        angleRate = _angleRate;
        speedRate = _speedRate;
        gravityScale = _gravity;
        gravity = 0;
        gravityAngle = _gravityAngle;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetSpeedRate(float speedRate)
    {
        this.speedRate = speedRate;
    }

    public void SetAngle(float angle)
    {
         this.angle = angle;
    }

    public void SetAngleRate(float angleRate)
    {
        this.angleRate = angleRate;
    }

    public void SetGravity(float gravity)
    {
        gravityScale = gravity;
    }

    private void Update()
    {
        float trad = Mathf.Deg2Rad * angle;

        float tx = Mathf.Cos(trad) * speed * Time.deltaTime;
        float ty = Mathf.Sin(trad) * speed * Time.deltaTime;

        transform.Translate(tx, ty , 0f);

        gravity += gravityScale;

        float grad = Mathf.Deg2Rad * gravityAngle;

        float gx = Mathf.Cos(grad) * gravity * Time.deltaTime;
        float gy = Mathf.Sin(grad) * gravity * Time.deltaTime;

        transform.Translate(gx, gy, 0f);

        angle += angleRate;
        speed += speedRate;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x > 1.1f || pos.x < -0.1f || pos.y > 1.1f || pos.y < -0.1f)
            BulletManager.GetInstance().RemoveItem(gameObject);
    }

}
