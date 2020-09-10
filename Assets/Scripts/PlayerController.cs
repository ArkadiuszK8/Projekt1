using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float[] playerSlots;

    public int defaultSlotIndex;

    public float speed;

    public float jumpForce;

    public SpriteRenderer spriteRenderer;

    public GameObject deathScreen;

    private int currentSlot;

    private bool jumpPossibility;

    void Start()
    {
        transform.position = new Vector2(playerSlots[defaultSlotIndex], transform.position.y);

        currentSlot = defaultSlotIndex;

        jumpPossibility = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        transform.position = Vector2.Lerp(transform.position, new Vector2(playerSlots[currentSlot], transform.position.y), speed);
    }

    public void MoveLeft()
    {
        if (currentSlot > 0)
        {
            currentSlot--;

            spriteRenderer.flipX = true;

            GetComponent<Animator>().SetTrigger("Run");
        }
    }

    public void MoveRight()
    {
        if (currentSlot < playerSlots.Length - 1)
        {
            currentSlot++;

            spriteRenderer.flipX = false;

            GetComponent<Animator>().SetTrigger("Run");
        }
    }

    public void Jump()
    {
        if (jumpPossibility)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);

            jumpPossibility = false;

            Invoke("EnableJump", 0.6f);
        }
    }

    private void EnableJump()
    {
        jumpPossibility = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") == true)
        {
            deathScreen.SetActive(true);

            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);

        Time.timeScale = 1;
    }
}
