using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public bool OnGround;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private GameObject gameOverUi;


    [SerializeField]
    private BoxCollider2D playerBoxCollider;
    private int score = 0;

    private int health = 3;
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRenderer;
    public bool IsFalling = false;
    public bool CanDoubleJump = true;
    private void Awake()
    {
        playerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        PrintScore();
        PrintHealth();
    }

    public void DecreaseHealth()
    {
        health -= 1;

        PrintHealth();
        if (health == 0)
        {
            PlayedDied();
        }

    }
    private void PrintHealth()
    {
        healthText.text = "Health: " + health;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        bool jumpInput = (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow));
        PlayerAnimation(horizontalInput, jumpInput);
        PlayerMovement(horizontalInput, jumpInput);

    }


    public void PlayedDied()
    {

        gameOverUi.SetActive(true);
        playerAnimator.SetFloat("Speed", 0); /*Run idle animation for now later can change to death animation*/

        AudioManager.Instance.PlaySfxMusic(SoundType.PlayerDeath);
        this.enabled = false;
    }

    public void IncreaseScore(int additionScore)
    {
        score += additionScore;
        PrintScore();
    }

    private void PrintScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void PlayerMovement(float horizontalInput, bool jumpInput)
    {
        PlayerHorizontalMovement(horizontalInput);
        PlayerJumpMovement(jumpInput);
    }

    private void PlayerJumpMovement(bool jumpInput)
    {
        if (!(jumpInput))
            return;
        if (OnGround || CanDoubleJump)
        {
            if (!OnGround)
                CanDoubleJump = false;

            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);


        }
    }

    private void PlayerHorizontalMovement(float horizontalInput)
    {
        if (horizontalInput == 0)
            return;
        Vector3 playerPosition = transform.position;
        playerPosition.x += (speed * horizontalInput * Time.deltaTime);
        transform.position = playerPosition;
        if (AudioManager.Instance != null)
            if (!AudioManager.Instance.audioSfx.isPlaying && OnGround)
                AudioManager.Instance.PlaySfxMusic(SoundType.PlayerMovement);
    }

    private void PlayerAnimation(float horizontalInput, bool jumpInput)
    {
        PlayerHorizontalMovementAnimation(horizontalInput);
        PlayerJumpAnimation(jumpInput);
        PlayerCrouchAnimation();
        PlayerFaillingAnimation();
    }

    private void PlayerFaillingAnimation()
    {
        if (playerRigidBody.velocity.y < 0)
        {
            IsFalling = true;
            playerAnimator.SetBool("IsFalling", true);
        }
        else
        {
            IsFalling = false;
            playerAnimator.SetBool("IsFalling", false);
        }
    }

    private void PlayerCrouchAnimation()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            bool isCourching = playerAnimator.GetBool("Crouch");
            playerAnimator.SetBool("Crouch", !isCourching);
            isCourching = playerAnimator.GetBool("Crouch");
            Vector2 size = playerBoxCollider.size;
            Vector2 offset = playerBoxCollider.offset;
            if (isCourching)
            {
                size.y /= 2f;
                offset.y /= 2f;
            }
            else
            {
                size.y *= 2f;
                offset.y *= 2f;
            }
            playerBoxCollider.size = size;
            playerBoxCollider.offset = offset;
        }
    }

    private void PlayerJumpAnimation(bool jumpInput)
    {
        if (jumpInput)
        {
            playerAnimator.SetBool("Jump", true);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);

        }
    }

    private void PlayerHorizontalMovementAnimation(float horizontalInput)
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        if (horizontalInput < 0)
        {
            playerSpriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            playerSpriteRenderer.flipX = false;
        }
    }


}