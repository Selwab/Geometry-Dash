using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerMovement : MonoBehaviour
{
    public Dictionary<string, float> speeds = new Dictionary<string, float>
    {
        { "Slow", 1.6f },
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
        player.position = new Vector3(player.position.x + speeds[currentSpeed] * Time.deltaTime, player.position.y, player.position.z);
 

        Jump();
        //if (Input.GetKeyDown("space"))
        //{
        //    Debug.Log("SPACE: " + IsGrounded());
        //    rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce * Time.deltaTime);
        //    //rb2d.AddForce(player.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        //}
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Debug.Log("***********DETECT SPACE");

            // Reducir la velocidad en el eje X
            Vector2 reducedVelocity = rb2d.velocity;
            reducedVelocity.x *= 0.5f; // Reducción a la mitad, puedes ajustar este valor según tus necesidades

            rb2d.velocity = reducedVelocity;

            rb2d.AddForce(player.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            //anim.SetTrigger("isJumping");
        }

    }

    public bool IsGrounded()
    {
        //Debug.Log("IS GROUNDED");
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
 
    
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    Debug.Log("Collision Listener");
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        Debug.Log("Is Jumping False");
    //        isJumping = false;
    //    }
    //}

}
