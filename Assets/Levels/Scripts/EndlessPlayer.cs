
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndlessPlayer: MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    private bool grounded;

    public float maxAcceleration;
    public float acceleration = 10;
    public float maxXVelocity;
    public GameObject RestartBO; 
    public GameObject MenuBO;



    private void Awake()
    {
        RestartBO.SetActive(false);
        MenuBO.SetActive(false);
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        //parametri animazione
        anim.SetBool("run", grounded);
 

        if (wallJumpCooldown > 0.2f)
        {

            if (onWall() && !grounded)
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
        if (grounded)
        {
            if (!onWall())
            {
                body.velocity = new Vector2(body.velocity.x, jumpPower);
                anim.SetTrigger("jump");
                grounded = false;
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
        else
        {
            if (collision.gameObject.tag == "Trap") { 
                die();
                RestartBO.SetActive(true);
                MenuBO.SetActive(true);
            }
            else
            {
                if (collision.gameObject.tag == "Biglietto")
                {
                    Destroy(collision.gameObject);
                    GameObject.Find("Punteggi").GetComponent<ScoreManager>().aggiornaBiglietti();
                }
            }
        }
        
        

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

    private void die()
    {
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene("EndlessMode");
        Time.timeScale = 1;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("ModeMenu");
        Time.timeScale = 1;
    }
}
