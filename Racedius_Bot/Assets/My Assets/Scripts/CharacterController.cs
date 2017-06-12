using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    // variable that decides how fast is the plater moving 
    public  float maxSpeed = 8f;

    // Boolean that says whether the player is facing in positive x direction 
    bool facingRight = true;

    // refers to a rigidbody2d component to be manipulated in by code 
    private Rigidbody2D rigi;

    // the animator tools
    Animator anim;

    // is the player grounded 
    bool grounded = false;

    // check if the player is on the ground 
    public Transform groundCheck;

    // when using ground check whats the radius of the circle that checks the ground
    float groundRadius = 0.2f;

    // defines what is the ground to the player 
    // in inspector it is everything that is NOT the player 

    public LayerMask whatIsGround;

    // what is the player jump force : determines jump height 
    public  float jumpForce = 700f;

    void Start()
    {
        // get the animator component 
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        // gronded is a circle that checks whether the player is on the ground 
        // grouded uses the criteria position of groundcheck , radius if check circle , layer mask what is ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        // animator to create a boolean called Ground equalling value of grounded 
        anim.SetBool("Ground", grounded);

        // movement is Input in the horizontal axis (left and right button) 
        float move = Input.GetAxis("Horizontal");

        // animator should set its speed to the rounded value of movement 
        anim.SetFloat("Speed", Mathf.Abs(move));

        // rigi is the getcomponent rigidbody2D of the GameObject this script is attached to (the player) 
        rigi = GetComponent<Rigidbody2D>();

        // the velocity of the player is the vector2D (x,) plane of the move times by maxSpeed and the velocity of the player in the Y direction
        rigi.velocity = new Vector2(move * maxSpeed, rigi.velocity.y);

        // if move is positive and is not facing right flip the player 
        if (move > 0 && !facingRight)
            Flip();

        // if the move is negative and is facing right flip the player 
        else if (move < 0 && facingRight)
            Flip();
    }
    void Update ()
    {
        // if the player is groundd and they press space 
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            // set the vSpeed (vertical speed) parameter in the animator to the y velocity  
            anim.SetFloat("vSpeed", rigi.velocity.y);

            // then set the animator grounded parameter to false 
            anim.SetBool("Grounded", false);

            // add the force to the player equal to the jumpforce 
            // this makes the player move in the y direction while also performing the animation 
            rigi.AddForce(new Vector2(0, jumpForce));
        }
    }

    // changes player direction
    // this is done so that the player doesn't need left and right sprites just the right but reverse the player
    void Flip()
    {
        // if facing right is not facing right (if the player changes direction) 
        facingRight = !facingRight;

        // the vector 3 theScale is the local scale of the game
        Vector3 theScale = transform.localScale;

        // negate the x value of theScale vector 
        theScale.x *= -1;

        // make this the new scale 
        transform.localScale = theScale;
    }
}
