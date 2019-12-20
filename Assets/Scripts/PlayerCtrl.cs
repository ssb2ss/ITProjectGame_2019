using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    private Rigidbody2D rb;
    private int jumpCount;
    private KeyCode jumpKey;

    public float moveSpeed;
    public float jumpSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 2;
        jumpKey = KeyCode.UpArrow;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        
        transform.Translate(h * moveSpeed * Time.deltaTime, 0, 0);

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    private void Jump()
    {
        if (   ( Input.GetKeyDown(jumpKey) || Input.GetKeyDown(KeyCode.Space) )&& jumpCount > 0)
        {
            jumpCount--;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }

        if (Input.GetKeyUp(jumpKey) && rb.velocity.y > 0)
        {
            rb.velocity *= new Vector2(1f, 0.45f);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            jumpCount = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Obstacle")&&GameManager.curState ==1)
        {
            GameManager.curState = 2;
            GameManager.cnt = 1;
            Destroy(this);
            Debug.Log("Damaged");
        }
    }

}
