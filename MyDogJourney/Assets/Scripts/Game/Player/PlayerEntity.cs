using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private int jumpCount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        rb.velocity = new Vector3(speed * PlayerInputSystem.Inst.axis.x, rb.velocity.y);
        if (PlayerInputSystem.Inst.isSpace)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (jumpCount > 0) return;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpCount++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 offset = (Vector3)collision.GetContact(0).point - transform.position;
        if(Vector3.Angle(offset, Vector3.down) < 2f)
        {
            jumpCount = 0;
        }
    }
}
