using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public Transform cam;
    public Vector2 speed;
    public float jumpForce;
    Rigidbody rb;


    public LayerMask ground;
    public Vector3 groundingOffset;
    public float groundCheckRadius = 1;
    public bool isGrounded;

    public Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.OverlapSphere(transform.position + groundingOffset, groundCheckRadius, ground).Length > 0;
        
        dir = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
            ).normalized;


        transform.rotation = Quaternion.Euler(transform.rotation.x, cam.rotation.eulerAngles.y, transform.rotation.z);

        Vector3 velChange = (transform.forward * dir.y * speed.y + transform.right * dir.x * speed.x);
        if (isGrounded)
        {
            rb.velocity = (velChange + Vector3.up * rb.velocity.y);


            //jumping
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x * 0.9f + velChange.x * 0.1f, rb.velocity.y, rb.velocity.z * 0.9f + velChange.z * 0.1f);
        }


        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + groundingOffset, groundCheckRadius);
    }
}
