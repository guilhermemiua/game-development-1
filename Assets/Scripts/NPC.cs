using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float VEL = 1;
    private Rigidbody2D rbd;
    public LayerMask mask;

    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rbd.velocity = new Vector2(VEL, 0);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 0.4f, mask);

        if (hit.collider != null)
        {
            VEL = VEL * -1;
            rbd.velocity = new Vector2(VEL, 0);
            transform.Rotate(new Vector2(0, 180));
        }
    }
}
