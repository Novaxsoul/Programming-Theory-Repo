using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;
    public float Speed
    {
        get { return speed; }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("Cant put negative speed");
            }
            else
            {
                speed = value;
            }
        }
    }
    [SerializeField] float jumpForce = 5.0f;
    public float JumpForce
    {
        get { return jumpForce; }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("Cant put negative jump force");
            }
            else
            {
                jumpForce = value;
            }
        }
    }
    protected Rigidbody playerRb;
    BoxCollider playerCollider;
    Vector2 turn;
    public Vector2 Turn
    {
        get { return turn; }
        set { turn = value; }
    }
    protected bool isGrounded = true;
    bool activePlayer;
    public bool ActivePlayer {
        get { return activePlayer; }
        set { activePlayer = value; }
    }
    float groundGap = 0.01f;
    float sizeGap = 0.999f;
    [SerializeField] float rotationSpeed;
    [SerializeField] float maxYrotation;
    protected bool shouldJump;
    Vector3 moveVector;
    bool offsetFlag = true;
    [SerializeField] Vector3 offset1;
    [SerializeField] Vector3 offset2;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (activePlayer)
        {
            Rotate();
            CanJump();
            CanMove();
            SpecialAbility();
            CheckGrounded();
            switchFPOffset();
        }

    }

    void FixedUpdate()
    {
        if (activePlayer)
        {
            Move();
            Jump();

            shouldJump = false;
            moveVector = new Vector3(0, 0, 0);

        } else
        {
            playerRb.velocity = new Vector3(0, playerRb.velocity.y, 0);
        }
    }

    // Function to check if player is trying to move using the arrow keys. Store the new position in a vector that will be use on Move function
    void CanMove()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        moveVector = transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput).normalized);
    }

    // Function to move the player using the vector filled on CanMove function
    void Move()
    {
        playerRb.velocity = new Vector3(moveVector.x * speed, playerRb.velocity.y, moveVector.z * speed);
    }

    // Function to check if player is trying to jump
    protected void CanJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shouldJump = true;
        }


    }

    // Function to make the player jump
    virtual protected void Jump()
    {
        if (shouldJump && isGrounded)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    // Function to rotate the player using mouse axis
    void Rotate()
    {
        turn.x += Input.GetAxis("Mouse X") * rotationSpeed;
        float yaxis = Input.GetAxis("Mouse Y") * rotationSpeed;

        if(turn.y + yaxis >= 0f && turn.y + yaxis < maxYrotation)
        {
            turn.y += yaxis;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        } else
        {
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
        
    }

    // Function to reset the player vertical rotation
    public void ResetRotation()
    {
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        turn.y = 0;
    }

    // Function to check if player is touching the ground
    protected bool CheckGrounded()
    {
        RaycastHit hitInfo;
        // Get new bounds according to player position and scale so the size of the boxcast dont get bigger when player rotate
        Bounds correctBounds = new Bounds(transform.position, transform.localScale);

        if (Physics.BoxCast(transform.position, new Vector3(correctBounds.extents.x, groundGap, correctBounds.extents.z)*sizeGap, Vector3.down, out hitInfo, transform.rotation, correctBounds.extents.y))
        {
            isGrounded = true;
            //Debug.DrawRay(hitInfo.point, hitInfo.normal, Color.red, 1.0f);
            return true;

        } else
        {
            isGrounded = false;
            return false;
        }

    }


    // Function to switch between First person view and Third person view
    private void switchFPOffset()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (offsetFlag)
            {
                gameObject.transform.GetChild(0).gameObject.transform.localPosition = offset2;
                offsetFlag = false;

            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.transform.localPosition = offset1;
                offsetFlag = true;
            }
        }
        
    }

    protected virtual void SpecialAbility()
    {

    }



}
