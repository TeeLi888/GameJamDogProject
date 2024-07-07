using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public LayerMask jumpOnMask;

    public AudioSource audioSource;
    public List<AudioClip> clips = new List<AudioClip>();

    public int health;
    public int maxHealth = 3;

    private Rigidbody2D rb;
    private int jumpCount;
    private bool jumpLock;

    private Animator animator;
    private SpriteRenderer spriteRd;

    private Frame frame;

    private LevelEntity Level => LevelSystem.Inst.CurLevel;
    private PlayerInputSystem Inputs => PlayerInputSystem.Inst;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRd = animator.GetComponent<SpriteRenderer>();
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
            PlayAudio(0);

            UISystem.Inst.PlayCutPictureEffect();
            CaptureSystem.Inst.CreateCapture(this);
            if (frame)
            {
                frame.Activate(true);
            }
        }

        if (transform.position.y < -5.5f)
        {
            Die();
        }

        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.25f;
        animator.SetBool("IsRunning", isRunning);

        if (isRunning)
        {
            spriteRd.flipX = Mathf.Sign(rb.velocity.x) < 0;
        }
    }

    private void PlayAudio(int index)
    {
        if (clips[index])
        {
            audioSource.clip = clips[index];
            audioSource.Play();
        }
    }

    private void StopAudio()
    {
        audioSource.Stop();
    }
    public void Die()
    {
        PlayAudio(1);
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

    public void OnSavePoint()
    {
        health = maxHealth;
        HeartPanel.Inst.SetHeart(health);
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

    public Sprite GetSprite()
    {
        return spriteRd.sprite;
    }

    public Vector3 GetSpritePos()
    {
        return spriteRd.transform.position;
    }

    public void OnEnterFrame(Frame frame)
    {
        this.frame = frame;
    }

    public void OnExitFrame(Frame frame)
    {
        this.frame = null;
    }

    public void Freeze()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        animator.speed = 0;
    }

    private void Jump()
    {
        PlayAudio(2);
        if (jumpCount > 0) return;
        if (jumpLock) return;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpCount++;
        jumpLock = true;

        animator.SetBool("IsGround", false);

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
            animator.SetBool("IsGround", true);
            jumpCount = 0;
        }
    }
}
