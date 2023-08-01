using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Animator myAnim;
    private Rigidbody2D rb;

    public AudioSource JumpSound;
    public AudioSource GunSound;

    public float speedX;
    public float jumpForce;

    private bool canJump = false;

    // Start is called before the first frame update
    void Start()
    {

        myAnim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        WASD();
        LRArrowSpace();
        shooting();
        if(transform.localPosition.y <= -5)
        {
            transform.localPosition = new Vector2(0, 3);
        }

    }

    void WASD()
    {
        if (Input.GetKey(KeyCode.A))    //IDLE TO RUNNING
        {
            myAnim.SetInteger("State", 2);

            rb.velocity = new Vector2(-speedX, rb.velocity.y);

            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(-.4f, transform.localScale.y);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            myAnim.SetInteger("State", 2);

            rb.velocity = new Vector2(speedX, rb.velocity.y);

            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector2(.4f, transform.localScale.y);
            }
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            myAnim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.W) && canJump)    //IDLE TO JUMPING
        {
            JumpSound.Play();

            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);

            canJump = false;

            myAnim.SetInteger("State", 3);
        }
        if (Input.GetKeyUp(KeyCode.W))      //JUMPING TO IDLE
        {
            myAnim.SetInteger("State", 0);
        }

    }
    void LRArrowSpace()
    {
        if (Input.GetKey(KeyCode.LeftArrow))    //IDLE TO RUNNING
        {
            myAnim.SetInteger("State", 2);

            rb.velocity = new Vector2(-speedX, rb.velocity.y);

            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(-.4f, transform.localScale.y);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myAnim.SetInteger("State", 2);

            rb.velocity = new Vector2(speedX, rb.velocity.y);

            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector2(.4f, transform.localScale.y);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            myAnim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)    //IDLE TO JUMPING
        {
            JumpSound.Play();

            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);

            canJump = false;

            myAnim.SetInteger("State", 3);
        }
        if (Input.GetKeyUp(KeyCode.Space))      //JUMPING TO IDLE
        {
            myAnim.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)    //IDLE TO JUMPING
        {
            JumpSound.Play();

            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);

            canJump = false;

            myAnim.SetInteger("State", 3);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))      //JUMPING TO IDLE
        {
            myAnim.SetInteger("State", 0);
        }
    }
    void shooting()
    {
        if (Input.GetKeyDown(KeyCode.G) && canJump)    //IDLE TO SHOOTING
        {
            GunSound.Play();

            myAnim.SetInteger("State", 5);
        }
        if (Input.GetKeyUp(KeyCode.G))      //JUMPING TO IDLE
        {
            myAnim.SetInteger("State", 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stage"))
        {
            canJump = true;

            myAnim.SetInteger("State", 0);
        }
    }

}
