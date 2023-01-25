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
    [SerializeField] Vector2 turn;
    public Vector2 Turn
    {
        get { return turn; }
        set { turn = value; }
    }
    [SerializeField] protected bool isGrounded = true;
    [SerializeField] bool activePlayer;
    public bool ActivePlayer {
        get { return activePlayer; }
        set { activePlayer = value; }
    }
    float groundGap = 0.01f;
    float sizeGap = 0.999f;
    [SerializeField] float rotationSpeed;
    [SerializeField] LayerMask jumpableGround;
    [SerializeField] protected bool shouldJump;
    Vector3 moveVector;

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

    void CanMove()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        moveVector = transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput).normalized);
    }

    void Move()
    {
        playerRb.velocity = new Vector3(moveVector.x * speed, playerRb.velocity.y, moveVector.z * speed);
    }

    protected void CanJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shouldJump = true;
        }


    }

    virtual protected void Jump()
    {
        if (shouldJump && isGrounded)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    void Rotate()
    {
        turn.x += Input.GetAxis("Mouse X") * rotationSpeed;
        // turn.y += Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
    }

    protected bool CheckGrounded()
    {
        RaycastHit hitInfo;
        Bounds correctBounds = new Bounds(transform.position, transform.localScale);

        if (Physics.BoxCast(transform.position, new Vector3(correctBounds.extents.x, groundGap, correctBounds.extents.z)*sizeGap, Vector3.down, out hitInfo, transform.rotation, correctBounds.extents.y))
        {
            isGrounded = true;
            Debug.DrawRay(hitInfo.point, hitInfo.normal, Color.red, 1.0f);
            return true;

        } else
        {
            isGrounded = false;
            return false;
        }

    }


    protected virtual void SpecialAbility()
    {

    }



}
