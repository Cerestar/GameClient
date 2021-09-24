using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public bool isFacingLeft;

    bool[] isWalking = { false, false, false };
    

    private void Update() {
        UpdateAnimationParams();
        spriteRenderer.flipX = isFacingLeft;
    }

    private void UpdateAnimationParams() {
        animator.SetBool("isWalkingDown", isWalking[0]);
        animator.SetBool("isWalkingUp", isWalking[1]);
        animator.SetBool("isWalkingSide", isWalking[2]);

        //Input order matters as to which direction plays if multiple inputs are down
        if (Input.GetKey(KeyCode.S)) {
            animator.SetBool("isWalkingDown", isWalking[0]);
        } else if (Input.GetKey(KeyCode.W)) {
            animator.SetBool("isWalkingUp", isWalking[1]);
        } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {

            if (Input.GetKey(KeyCode.A))
                isFacingLeft = true;
            else if (Input.GetKey(KeyCode.D))
                isFacingLeft = false;

            animator.SetBool("isWalkingSide", isWalking[2]);
        }
    }
}
