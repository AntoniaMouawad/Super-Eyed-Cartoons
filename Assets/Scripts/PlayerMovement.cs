using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 11f;
    

    private string RUNNING_FLAG = "isRunning";
    private string JUMPING_FLAG = "isJumping";
    
    private Animator anim;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private float movementX;
    


    private void Awake()
    { 
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        AnimatePlayer();
        JumpPlayer();
    }

    private void MovePlayer()
    {
        movementX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    private void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(RUNNING_FLAG, true);
            sr.flipX = false;

        }
        else if (movementX < 0)
        {
            anim.SetBool(RUNNING_FLAG, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(RUNNING_FLAG, false);
        }
        
        if (myBody.velocity.y > 0.01f)
        {
            anim.SetBool(JUMPING_FLAG, true);
        }

        else if (myBody.velocity.y < -3f)
        {
            anim.SetBool(JUMPING_FLAG, false);
        }
    }

    private void JumpPlayer()
    {
        if (Input.GetButtonDown("Jump"))
        {
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            
        }
    }


}
