using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unity101_CharacterController : MonoBehaviour
{
    [Header("Walk / Run Setting")] public float walkSpeed;
    public float runSpeed;

    [Header("Jump Force")] public float playerJumpForce;

    [Header("Double Jump")] public bool doubleJumpEnabled;


    private Collider col;
    private Rigidbody rb;

    private float distToGround;
    private bool playerIsJumping;
    private float currentSpeed;
    private float xAxis;
    private float zAxis;
    private bool leftShiftPressed;
    private int jumpCounter = 0;
    private float jumpDelay = 0.05f;
    private float timer = 0f;
    private bool jumpingHighSpeed;
      
    private Animator anim;
    private float animSpeed;



    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        if (col == null) { Debug.LogError("Collision component missing"); enabled = false; }
        rb = GetComponent<Rigidbody>();
        if (rb == null) { Debug.LogError("Physic body component missing"); enabled = false; }

        // To assert character doesn't fall on the side
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        distToGround = col.bounds.extents.y;

        anim = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        // Walk
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        currentSpeed = (leftShiftPressed && !playerIsJumping) || jumpingHighSpeed ? runSpeed : walkSpeed;

        if (xAxis != 0 || zAxis != 0)
        {
            if (zAxis > 0)
            {
                anim.SetFloat("Direction", 1f);
            }
            else
            {
                anim.SetFloat("Direction", -1f);
            }
            animSpeed = (currentSpeed == walkSpeed) ? 0.5f : 1f;
        }
        else
        {
            anim.SetFloat("Direction", 1f);
            animSpeed = 0f;
        }
        anim.SetFloat("Speed", animSpeed);


        // Run
        leftShiftPressed = Input.GetKey(KeyCode.LeftShift);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentSpeed == runSpeed)
            {
                jumpingHighSpeed = true;
            }

            //Simple jump
            if (IsGrounded() && !playerIsJumping && jumpCounter < 1)
            {
                rb.velocity = Vector3.up * playerJumpForce;
                //jumpCounter++;
                playerIsJumping = true;
                anim.SetBool("isJumping", true);
            }
            // Double jump
            //else if (playerIsJumping && (doubleJumpEnabled && jumpCounter < 2))
            //{
            //    rb.velocity = Vector3.up * playerJumpForce;
            //    jumpCounter++;
            //    anim.SetBool("isJumping", true);
            //}
        }

        //Danse
        if (FindObjectOfType<EndZone>().isArrived())
        {
            anim.SetBool("Victory", true);
        }

        if (playerIsJumping)
        {
            timer += Time.deltaTime;
        }

        if (IsGrounded() && playerIsJumping && timer > jumpDelay)
        {
            playerIsJumping = false;
            anim.SetBool("isJumping", false);
            jumpCounter = 0;
            timer = 0f;
            jumpingHighSpeed = false;
        }
    }

    // Fixed Update is called once per frame, at fixed time
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + Time.deltaTime * currentSpeed * transform.TransformDirection(xAxis, 0f, zAxis));
    }


    // Check the distance between the player and a ground surface : try to make it more easy to jump on the ledge 
    private bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.05f) ||
            Physics.Raycast(transform.position, -Vector3.left, distToGround + 0.05f) ||
            Physics.Raycast(transform.position, -Vector3.right, distToGround + 0.05f) ||
            Physics.Raycast(transform.position, -Vector3.down, distToGround + 0.05f))
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
