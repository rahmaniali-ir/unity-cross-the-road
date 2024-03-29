using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 0.05f;
    [SerializeField] Animator animator;
    [SerializeField] bool playable = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StopWalking();
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Walk(0, speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Walk(0, -speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Walk(speed, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Walk(-speed, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Vehicle"))
        {
            GameManager.instance.GameOver();
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.instance.LevelCompleted();
        }
    }

    void Walk(float xOffset = 0, float yOffset = 0)
    {
        if (!playable) return;

        Vector3 position = transform.position;

        // GameManager.instance.walking = true;
        if (yOffset != 0)
            animator.SetBool("Walking", true);
        else if (xOffset != 0)
            animator.SetBool("SideWalking", true);

        spriteRenderer.flipY = yOffset < 0;
        spriteRenderer.flipX = xOffset < 0;

        transform.position = new Vector3(position.x + xOffset, position.y + yOffset, position.z);
    }

    void StopWalking()
    {
        // GameManager.instance.walking = false;
        animator.SetBool("Walking", false);
        animator.SetBool("SideWalking", false);
    }

    public void ActivatePlayer()
    {
        playable = true;
    }

    public void DeactivatePlayer()
    {
        playable = false;
    }
}
