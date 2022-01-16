using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    private bool isGroundedOnJumpPlatform;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsDoubleJump;
    private float f;

    private int extraJumps;
    public int extraJumpValue;

    public Swipe swipeControls;

    public bool gameEnded;


    void Start() {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate(){

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isGroundedOnJumpPlatform = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsDoubleJump);
      
        moveInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            f = -0.075f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            f = 0.075f;
        }
        if (swipeControls.SwipeLeft)
        {
            f = -0.075f;
        }
        if (swipeControls.SwipeRight)
        {
            f = 0.075f;
        }
        gameObject.transform.localPosition = new Vector3(
                gameObject.transform.localPosition.x + f,
                gameObject.transform.localPosition.y,
                gameObject.transform.localPosition.z);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0) {
            Flip();
        }
        if (facingRight == false && swipeControls.SwipeRight)
        {
            Flip();
        }
        else if (facingRight == true && swipeControls.SwipeLeft)
        {
            Flip();
        }
    }

    void Update()
    {

        if (isGroundedOnJumpPlatform == true) {
            extraJumps = extraJumpValue;
        }

        if ((swipeControls.SwipeUp || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded == true) {
            rb.velocity = Vector2.up * jumpForce;
        }
        //if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        if ((Input.GetKeyDown(KeyCode.UpArrow ) || swipeControls.SwipeUp) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || swipeControls.SwipeUp) && extraJumps == 0 && isGrounded == true) {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip(){

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Spikes" || collision.tag == "Laser")
        {
            //gameObject.SetActive(false);
            //Time.timeScale = 0f;
            SceneManager.LoadScene(2);
        }
    }
}