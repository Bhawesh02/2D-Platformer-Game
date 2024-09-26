using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOnGround : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private PlayerControler playerController;
    private Animator playerAnimator;
    private void Awake()
    {
        playerController = player.GetComponent<PlayerControler>();
        playerAnimator = player.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController.CanDoubleJump = true;
        if (playerController.IsFalling)
            playerAnimator.SetBool("HasLanded", true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            playerController.OnGround = true;
            playerAnimator.SetBool("onGround", true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            playerController.OnGround = false;
            playerAnimator.SetBool("onGround", false);
            playerAnimator.SetBool("HasLanded", false);
        }
    }

}