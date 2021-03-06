
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    private bool grounded;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    { 
        //parametri animazione
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);

    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        float localScaleX = transform.localScale.x;
        //cambia la posizione tra destra e sinistra
        if (horizontalInput > 0.01f)
        {
            if (localScaleX < 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInput < -0.01f)
        {
            if (localScaleX > 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        if(wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

            if(onWall() && !grounded)
            {
                body.gravityScale = 2;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 7;
            }

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }
    }

    private void Jump()
    {
        if(grounded)
        {
            if(!onWall())
            {
                body.velocity = new Vector2(body.velocity.x, jumpPower);
                grounded = false;
                anim.SetBool("grounded", grounded);
            }
            else
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }

        }
        else if (onWall() && !grounded)
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 10);

            wallJumpCooldown = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Train")
            grounded = true;

        if (collision.gameObject.tag == "Buca")
            body.transform.localPosition = new Vector3(body.transform.localPosition.x, body.transform.localPosition.y - 9, body.transform.localPosition.z);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}
