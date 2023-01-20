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
            if(value < 0.0f)
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
    Collider playerCollider;
    [SerializeField] Vector2 turn;
    public Vector2 Turn
    {
        get { return turn; }
        set { turn = value; }
    }
    protected bool isGrounded = true;
    [SerializeField] bool activePlayer;
    public bool ActivePlayer { 
        get { return activePlayer; } 
        set { activePlayer = value; }
    }
    float groundGap = 0.01f;
    [SerializeField] float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
    }

    void LateUpdate()
    {
        if (activePlayer)
        {
            Move();
            Rotate();
            Jump();
            SpecialAbility();
        } else
        {
            playerRb.velocity = new Vector3(0,playerRb.velocity.y,0);
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveVector = transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput).normalized);
        playerRb.velocity = new Vector3(moveVector.x * speed, playerRb.velocity.y, moveVector.z * speed);
    }

    virtual protected void Jump()
    {     
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        CheckGrounded();
    }

    void Rotate()
    {
        turn.x += Input.GetAxis("Mouse X") * rotationSpeed;
        // turn.y += Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
    }

    protected bool CheckGrounded()
    {
        if(Physics.BoxCast(transform.position, new Vector3(playerCollider.bounds.extents.x, groundGap, playerCollider.bounds.extents.z), Vector3.down, transform.rotation, playerCollider.bounds.extents.y + groundGap))
        {
            isGrounded = true;
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
