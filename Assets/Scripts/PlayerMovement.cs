using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class PlayerMovement : MonoBehaviour
{
    public Dictionary<string, float> speeds = new Dictionary<string, float>
    {
        { "Slow", 0.06f },
        { "Normal", 10.4f },
        { "Medium", 12.96f },
        { "Fast", 15.6f }
    };

    public Transform player;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public string currentSpeed = "Normal";
    Rigidbody2D rb2d;
    public float jumpForce = 100f;
    public float rotationForce = 360f;
    public bool isJumping = false;
    Animator anim;

    public float gravityScale = 8;
    public float fallGravityScale = 15;
    public float jumpHeight = 5;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Constant Speed - Time.detlaTime represneta el tiempo en segundos
        player.position = new Vector3(player.position.x + speeds[currentSpeed] *Time.deltaTime, player.position.y, player.position.z);
        //float movimiento = Input.GetAxis("Horizontal"); //Nombre del eje
        //if (movimiento != 0)
        //{
        //    player.position = new Vector3(player.position.x + (speeds[currentSpeed] * movimiento), player.position.y, player.position.z);
        //    Debug.Log(movimiento);
        //}

        Jump();
    }

    void Jump()
    {
        isJumping = !IsGrounded();
        //Debug.Log("IsGrounded: " + !isJumping);
        if (Input.GetMouseButton(0) && IsGrounded())
        {
            // Reducir la velocidad en el eje X
            Vector2 reducedVelocity = rb2d.velocity;
            reducedVelocity.x *= 0.5f;
            rb2d.velocity = reducedVelocity;

           // jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb2d.gravityScale * -2)) * rb2d.mass;
            rb2d.AddForce(player.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            //anim.SetTrigger("isJumping");
        }

        if (rb2d.velocity.y > 0f)
        {
            rb2d.gravityScale = gravityScale;
        }
        else
        {
            rb2d.gravityScale = fallGravityScale;
        }

    }

    public bool IsGrounded()
    {
        //Debug.Log("IS GROUNDED");
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        //return Physics2D.OverlapBox(groundCheck.position, Vector2.right * 1.1f + Vector2.up * groundCheckRadius, 0, groundLayer);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Spike");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Collision PORTAL");
            SceneManager.LoadScene("GameOver");
        }
        else if (other.gameObject.CompareTag("Block"))
        {
            foreach(ContactPoint2D hitPos in other.contacts)
            {
                if (!(hitPos.normal.y > 0f))
                {
                    Debug.Log("HIT Y: " + hitPos.normal.y + ", X: " + hitPos.normal.x);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

            }

        }


    }

}


