using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public LayerMask jumpOnMask;

    public int health;
    public int maxHealth = 3;

    private Rigidbody2D rb;
    private int jumpCount;
    private bool jumpLock;

    private LevelEntity Level => LevelSystem.Inst.CurLevel;
    private PlayerInputSystem Inputs => PlayerInputSystem.Inst;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    { 
        rb.velocity = new Vector3(speed * Inputs.axis.x, rb.velocity.y);
        if (Inputs.isJump)
        {
            Jump();
        }

        if (Inputs.isCapture)
        {
            CaptureSystem.Inst.CreateCapture(this);
        }

        if (transform.position.y < -7f)
        {
            Die();
        }
    }

    public void Die()
    {
        health--;
        HeartPanel.Inst.SetHeart(health);
        if(health <= 0)
        {
            Level.ResetLevel(this);
        }
        else
        {
            Level.Respawn(this);
        }
    }

    public void OnRespawn()
    {
        rb.velocity = Vector2.zero;
    }

    public void OnLevelReset()
    {
        health = maxHealth;
        HeartPanel.Inst.SetHeart(health);
    }

    private void Jump()
    {
        if (jumpCount > 0) return;
        if (jumpLock) return;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpCount++;
        jumpLock = true;
        TimingSystem.Inst.RunOnce("jumplock", 0.5f, () =>
        {
            jumpLock = false;
        });
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (jumpLock) return;
        bool isHit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, jumpOnMask);
        if (isHit)
        {
            jumpCount = 0;
        }
    }
}
