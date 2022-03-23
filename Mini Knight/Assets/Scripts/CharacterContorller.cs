using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContorller : MonoBehaviour
{
    public float walkSpeed  = 2f;
    public float sprintSpeed = 4f;
    public float normalSpeed ;
    public float jumpForce = 2f;
    private int maxJumps = 2;

    public SpriteRenderer sp;
    
    void Start()
    {
        normalSpeed = walkSpeed;
    }

    
    void Update()
    {
        
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * normalSpeed * Time.deltaTime);
            sp.flipX = true;

        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * normalSpeed * Time.deltaTime);
            sp.flipX = false;
    
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

       if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            normalSpeed = sprintSpeed;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            normalSpeed = walkSpeed;
        }

    }

    public void Jump()
    {
        if(maxJumps > 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            maxJumps--;
        }
        if(maxJumps ==0)
        {
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            maxJumps = 2;
        }
    }
}
