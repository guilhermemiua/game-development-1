using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D rbd;
    public LayerMask enemy;
    public LayerMask mask;
    public GameObject foot;
    private Animator anim;
    public float VEL = 5;
    public float JUMP = 300;
    private bool lookingRight = true;
    private bool floor = true;
    private float x;

    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        verifyFloor();
        move();
        jump();
        killEnemy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = null;
        }
    }

    private void move()
    {
        x = Input.GetAxis("Horizontal");

        rbd.velocity = new Vector2(x * VEL, rbd.velocity.y);
        anim.SetFloat("yVelocity", rbd.velocity.y);

        if (lookingRight && x < 0 || !lookingRight && x > 0)
        {
            transform.Rotate(new Vector2(0, 180));
            lookingRight = !lookingRight;
        }

        anim.SetFloat("velocity", Mathf.Abs(x));
    }

    private void verifyFloor()
    {
        RaycastHit2D hit = Physics2D.Raycast(foot.transform.position, -foot.transform.up, 0.1f, mask);

        if (hit.collider != null)
        {
            floor = true;
            anim.SetBool("floor", true);
        }
        else
        {
            floor = false;
            anim.SetBool("floor", false);
        }
    }

    private void jump()
    {
        if (floor && Input.GetKeyDown(KeyCode.Space))
        {
            rbd.AddForce(new Vector2(0, JUMP));
        }
    }

    private void killEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(foot.transform.position, -foot.transform.up, 0.1f, enemy);

        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
