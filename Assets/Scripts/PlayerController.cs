using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public bool isFacingLeft;

    //FIX LATER: should be sending unity buttons rather than keycodes

    // Update is called once per frame
    private void FixedUpdate() {
        SendInputToServer();
    }

    private void Update() {
        UpdateAnimationParams();
        spriteRenderer.flipX = isFacingLeft;
    }

    private void UpdateAnimationParams() {
        animator.SetBool("isWalkingDown", false);
        animator.SetBool("isWalkingUp", false);
        animator.SetBool("isWalkingSide", false);

        //Input order matters as to which direction plays if multiple inputs are down
        if (Input.GetKey(KeyCode.S)) {
            animator.SetBool("isWalkingDown", true);
        } else if (Input.GetKey(KeyCode.W)) {
            animator.SetBool("isWalkingUp", true);
        } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {

            if (Input.GetKey(KeyCode.A))
                isFacingLeft = true;
            else if (Input.GetKey(KeyCode.D)) 
                isFacingLeft = false;

            animator.SetBool("isWalkingSide", true);
        }
    }

    private void SendInputToServer() {
        bool[] _inputs = new bool[] {
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.D),
        };

        ClientSend.PlayerMovement(_inputs);
    }
}
