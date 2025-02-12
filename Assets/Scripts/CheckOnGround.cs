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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            playerController.onGround = true;
            playerAnimator.SetBool("onGround", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            playerController.onGround = false;
            playerAnimator.SetBool("onGround", false);
        }
    }

}
