using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    public float speed =5.0F;
    public float PowerJump= 10.0F;

    public bool onGround;
    public Transform GroundCheck;

    public float checkRadiusGround = 0.05f;
    public LayerMask Platforms;


    public Rigidbody2D RigidBody;
    public Animator Anim;
    public Vector2 moveVector;

    public bool faceRight=true;




    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        // print(RigidBody);

    }

    
    void FixedUpdate(){
        
        
        
    }

    void Update(){
        SlimeMove();
        Jump();
        CheckingOnGround();
        CheckingLeft();
        CheckingRight();
        CheckingTop();
        Reflect();
        if(Left){
            print("Left");
        }
        if(Right){
            print("Right");
        }
        if(Top){
            print("Top");
        }
        
    }


    void Reflect(){
        if ((moveVector.x>0 && !faceRight)||(moveVector.x<0 && faceRight)){
            transform.localScale*= new Vector2(-1,1);
            // transform.Rotate (0,0,90);
            faceRight=!faceRight;
        }

    }


// Рабочий метод
    public void SlimeMove(){

        moveVector.x= Input.GetAxisRaw("Horizontal");
        Anim.SetBool("onGround", onGround);
        Anim.SetFloat("moveX",Mathf.Abs(moveVector.x));
        Anim.SetBool("Right", false);
        // Anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        if (moveVector.x!=0){
            Anim.SetBool("stay", false);
            Anim.SetBool("Right",Right);
        }
        if (moveVector.x==0){
            Anim.SetBool("stay", true);
        }
        
        
        RigidBody.velocity = new Vector2(moveVector.x*speed, RigidBody.velocity.y); 
        // if(onGround){
        //     RigidBody.velocity = new Vector2(moveVector.x*speed, 0); 

        // }
        // else{
            

        // }


        // RigidBody.AddForce(moveVector*speed);
    
        
            }

// Input.GetKeyDown(KeyCode.Space)
    public void Jump(){
        if (onGround){
            Anim.SetBool("Jump", false );

            if (Input.GetAxis("Jump") > 0){
            RigidBody.velocity = new Vector2(moveVector.x, PowerJump);
            }
            // print(Input.GetKeyDown(KeyCode.Space));
        }
        else{
            
            Anim.SetBool("Jump", true );
        }

    }

    public Collider2D GroundCheck1;
    // public Vector2 GroundCheckXY=new Vector2(GroundCheck1.transform.x,GroundCheck1.transform.y);
    // public Vector2 GroundCheckAB = new Vector2(GroundCheck1.transform.x-GroundCheck1.size()[0], GroundCheck.transform.y-GroundCheck.size()[1]);



    void CheckingOnGround(){
        // onGround = Physics2D.OverlapArea(GroundCheckXY, GroundCheckAB, Platforms);

        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadiusGround, Platforms);
    }

    public bool Left;
    public Transform LeftCheck;

    void CheckingLeft(){

        Left= Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
    }

    public bool Right;
    public Transform RightCheck;

    void CheckingRight(){

        Right= Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);
    }

    public bool Top;
    public Transform TopCheck;

    void CheckingTop(){

        Top= Physics2D.OverlapCircle(TopCheck.position, checkRadiusGround, Platforms);
    }

}
