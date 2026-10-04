using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private float horizontal = 0;
    private float vertical = 0;

    public Rigidbody2D rb;

    public Animator anim;

    public SpriteRenderer sr;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector3(horizontal * moveSpeed, vertical * moveSpeed);

        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        if (horizontal < 0)
        {
            sr.flipX = false;
        }
        else if (horizontal > 0)
        {
            sr.flipX = true;
        }
        


    }
}
