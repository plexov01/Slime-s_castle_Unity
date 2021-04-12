using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    public float speed = 5.0F;
    public float PowerJump = 11.0F;

    public bool onGround;
    public Transform GroundCheck;

    public float checkRadiusGround = 0.05f;
    public LayerMask Platforms;


    public Rigidbody2D RigidBody;
    public Animator Anim;
    public Vector2 moveVector;

    public bool faceRight = true;

    public bool stuckLeft = false; //Прилип к левой стене
    public bool stuckRight = false; //Прилип к правой стене
    public bool stuckTop = false; //прилип к потолку

    public float RotZ = 0.0f;
    public bool roll = false;

    // Переменные для правильной смены анимаций
    public bool moveFloor;



    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        // print(RigidBody);

    }


    void FixedUpdate()
    {



    }

    void Update()
    {


        CheckingOnGround();
        CheckingLeft();
        CheckingRight();
        CheckingTop();

        Reflect();
        Jump();
        SlimeMove();

        // print(transform.rotation.z);
        // print(stuckRight);
        // print(RigidBody.gravityScale);

    }


    void Reflect()
    {
        if (onGround)
        {
            if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
            {
                transform.localScale *= new Vector2(-1, 1);

                faceRight = !faceRight;

            }
        }

        if (stuckTop)
        {
            if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
            {
                transform.localScale *= new Vector2(-1, 1);

                faceRight = !faceRight;

            }
        }

        if (stuckRight)
        {
            if ((moveVector.y > 0 && !faceRight) || (moveVector.y < 0 && faceRight))
            {
                transform.localScale *= new Vector2(-1, 1);

                faceRight = !faceRight;
            }

        }
        if (stuckLeft)
        {
            if ((moveVector.y > 0 && faceRight) || (moveVector.y < 0 && !faceRight))
            {
                transform.localScale *= new Vector2(-1, 1);

                faceRight = !faceRight;

            }
        }




    }

    public Vector2 FinalVectorValue;
    // Рабочий метод
    void SlimeMove()
    {

        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        // moveVector.x = -1;
        // moveVector.y = 1;

        // moveVector.y = -1;

        // moveVector.x=1;









        Anim.SetBool("onGround", onGround);
        Anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        Anim.SetFloat("moveY", Mathf.Abs(moveVector.y));

        // Anim.SetBool("Right", Right);

        // Anim.SetBool("stuckRight",stuckRight);
        // Anim.SetBool("stuckLeft",stuckLeft);
        // Anim.SetBool("stuckTop",stuckTop);

        // Anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        // if()
        if ((moveVector.x != 0 || moveVector.y != 0 || RigidBody.velocity.y != 0 || RigidBody.velocity.x != 0))
        {
            Anim.SetBool("stay", false);

        }
        if ((onGround || stuckTop) && transform.eulerAngles.z == 0)
        {
            if (moveVector.x == 0)
            {
                Anim.SetBool("stay", true);
            }
        }

        if (stuckRight && transform.eulerAngles.z == 90)
        {
            if (moveVector.y == 0)
            {
                Anim.SetBool("stay", true);
            }
        }

        if (stuckLeft && transform.eulerAngles.z == 270)
        {
            if (moveVector.y == 0)
            {
                Anim.SetBool("stay", true);
            }
        }

        // print(Anim.GetBool("moveFloor"));

        // Правая стенка
        if (moveVector.x > 0)
        {
            if (Right)
            {
                stuckRight = true;

                if (RigidBody.gravityScale != 0)
                {
                    RigidBody.gravityScale = 0;
                }
                if (transform.eulerAngles.z == 0)
                {
                    RotZ = 90.0f;
                    if (Anim.GetBool("moveFloor"))
                    {
                        if (onGround)
                        {
                            transform.position = transform.position + new Vector3(0.12f, 0.1f, 0);
                        }
                        if (Top)
                        {
                            transform.position = transform.position + new Vector3(0.12f, -0.1f, 0);
                        }
                    }
                    else if (Anim.GetBool("Jump"))
                    {
                        transform.position = transform.position + new Vector3(0.1f, 0, 0);
                    }


                }

            }
            else
            {
                stuckRight = false;

                if (RigidBody.gravityScale != 1)
                {
                    RigidBody.gravityScale = 1;
                }

                if (transform.eulerAngles.z != 0)
                {
                    RotZ = 0.0f;

                }
            }

        }
        else
        {
            stuckRight = false;
        }



        // Левая стенка
        if (moveVector.x < 0)
        {
            if (Left)
            {
                stuckLeft = true;

                if (RigidBody.gravityScale != 0)
                {
                    RigidBody.gravityScale = 0;
                }
                if (transform.eulerAngles.z == 0)
                {
                    RotZ = 270.0f;
                    if (Anim.GetBool("moveFloor"))
                    {   
                        if(onGround){
                            transform.position = transform.position + new Vector3(-0.12f, 0.1f, 0);
                        }
                        if(Top){
                            transform.position = transform.position + new Vector3(-0.12f, -0.1f, 0);
                        }
                    }
                    else if (Anim.GetBool("Jump"))
                    {
                        transform.position = transform.position + new Vector3(-0.1f, 0, 0);
                    }


                }

            }
            else
            {
                stuckLeft = false;

                if (RigidBody.gravityScale != 1)
                {
                    RigidBody.gravityScale = 1;
                }

                if (transform.eulerAngles.z != 0)
                {
                    print("Rotz="+RotZ);
                    RotZ = 0.0f;

                }
            }

        }
        else
        {
            stuckLeft = false;
        }

        
        if (moveVector.x == 0)
        {
            stuckRight = false;
            stuckLeft = false;

            if (transform.eulerAngles.z != 0)
            {
                RotZ = 0;

            }
        }



        // Потолок
        if (Top && !(stuckRight || stuckLeft))
        {
            if (moveVector.y > 0)
            {
                stuckTop = true;
                RigidBody.AddForce(new Vector2(0, 5), ForceMode2D.Force);
                if (transform.localScale.y != -1)
                {
                    roll = true;
                    // transform.localScale*=new Vector2(1,-1);
                }

            }
            else
            {
                stuckTop = false;
                if (transform.localScale.y != 1)
                {
                    roll = false;
                    // transform.localScale*=new Vector2(1,-1);
                }
            }
        }
        else
        {
            stuckTop = false;
            roll = false;
        }


        // Поворот слизня
        if (transform.eulerAngles.z != RotZ)
        {
            transform.rotation = Quaternion.Euler(0, 0, RotZ);
        }

        if (roll)
        {
            if (transform.localScale.y != -1)
            {
                transform.localScale *= new Vector2(1, -1);
            }
        }
        else
        {
            if (transform.localScale.y != 1)
            {
                transform.localScale *= new Vector2(1, -1);
            }
        }

        if (stuckRight)
        {
            RigidBody.gravityScale = 0;
            RigidBody.AddForce(new Vector2(6, 0), ForceMode2D.Force);

            RigidBody.velocity = new Vector2(0, moveVector.y * speed);

        }
        if (stuckLeft)
        {
            RigidBody.gravityScale = 0;
            RigidBody.AddForce(new Vector2(-6, 0), ForceMode2D.Force);
            // RigidBody.velocity.x
            RigidBody.velocity = new Vector2(0, moveVector.y * speed);
        }
        if (stuckTop)
        {
            RigidBody.gravityScale = -1;
            RigidBody.velocity = new Vector2(moveVector.x * speed, RigidBody.velocity.y);

        }

        if (transform.eulerAngles.z == 0 && transform.localScale.y == 1)
        {
            RigidBody.gravityScale = 1;
            RigidBody.velocity = new Vector2(moveVector.x * speed, RigidBody.velocity.y);

        }




        if (((stuckTop || onGround) && moveVector.x != 0) || ((stuckLeft || stuckRight) && moveVector.y != 0))
        {
            Anim.SetBool("moveFloor", true);
        }
        else
        {
            Anim.SetBool("moveFloor", false);
        }

        if ((stuckRight && ((onGround && moveVector.y < 0) || (Top && moveVector.y > 0)) || (stuckLeft && ((onGround && moveVector.y < 0) || (Top && moveVector.y > 0)))))
        {
            if(Top&&!Anim.GetBool("Corner")){
                transform.position = transform.position + new Vector3(0, 0.05f, 0);
            }
            if(onGround&& !Anim.GetBool("Corner")){
                transform.position = transform.position + new Vector3(0, -0.05f, 0);
            }
            Anim.SetBool("Corner", true);
            
        }
        else
        {
            Anim.SetBool("Corner", false);
        }

        // if((Right&&onGround&&moveVector.x>0)||(Right&&Top&&moveVector.x>0&&moveVector.y>0)||(Left&&onGround&&moveVector.x<0)||(Left&&Top&&moveVector.x<0&&moveVector.y>0)){
        //     Anim.SetBool("Corner",true);
        // } else{
        //     Anim.SetBool("Corner",false);
        // }

        Anim.SetBool("Right", Right);

        Anim.SetBool("stuckRight", stuckRight);
        Anim.SetBool("stuckLeft", stuckLeft);
        Anim.SetBool("stuckTop", stuckTop);



        // stuckRight=false;
        // stuckLeft=false;
        // stuckTop=false;


        if (!stuckLeft && !stuckRight && !stuckTop)
        {
            RigidBody.gravityScale = 1;
        }






        // RigidBody.AddForce(moveVector*speed);


    }


    // Input.GetKeyDown(KeyCode.Space)
    void Jump()
    {
        // Anim.SetFloat("Jump", Input.GetAxis("Jump") );
        if (!onGround && !stuckLeft && !stuckRight && !stuckTop)
        {
            Anim.SetBool("Jump", true);
        }
        else
        {
            Anim.SetBool("Jump", false);
        }
        if (onGround)
        {
            if (Input.GetAxis("Jump") > 0)
            {
                RigidBody.velocity = new Vector2(moveVector.x, PowerJump);
            }
        }

        // if (onGround){


        //     if (Input.GetAxis("Jump") > 0 && !stuckLeft && !stuckRight && !stuckTop){
        //     RigidBody.velocity = new Vector2(moveVector.x, PowerJump);
        //     Anim.SetBool("stay",false);
        //     }
        //     // print(Input.GetKeyDown(KeyCode.Space));
        // }
        // else{
        //     // if();
        //     // transform.rotation = Quaternion.Euler (0,0,0);

        // }

    }

    public Collider2D GroundCheck1;
    // public Vector2 GroundCheckXY=new Vector2(GroundCheck1.transform.x,GroundCheck1.transform.y);
    // public Vector2 GroundCheckAB = new Vector2(GroundCheck1.transform.x-GroundCheck1.size()[0], GroundCheck.transform.y-GroundCheck.size()[1]);

    public bool Left;
    public Transform LeftCheck;

    public bool Right;
    public Transform RightCheck;

    public bool Top;
    public Transform TopCheck;

    void CheckingOnGround()
    {
        // onGround = Physics2D.OverlapArea(GroundCheckXY, GroundCheckAB, Platforms);
        if (transform.eulerAngles.z == 0 && transform.localScale.y == 1)
        {
            onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 0 && transform.localScale.y == -1)
        {
            onGround = Physics2D.OverlapCircle(TopCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 90 && transform.localScale.x == 1)
        {
            onGround = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 90 && transform.localScale.x == -1)
        {
            onGround = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 270 && transform.localScale.x == 1)
        {
            onGround = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 270 && transform.localScale.x == -1)
        {
            onGround = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
        }


        // onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadiusGround, Platforms);
    }



    void CheckingLeft()
    {
        if (transform.eulerAngles.z == 0 && transform.localScale.x == 1)
        {
            Left = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
            // print("+");
        }
        if (transform.eulerAngles.z == 0 && transform.localScale.x == -1)
        {
            Left = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);
            // print("+");
        }
        if (transform.eulerAngles.z == 90)
        {
            Left = Physics2D.OverlapCircle(TopCheck.position, checkRadiusGround, Platforms);
        }

        if (transform.eulerAngles.z == 270)
        {
            Left = Physics2D.OverlapCircle(GroundCheck.position, checkRadiusGround, Platforms);
        }


        // Left= Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
    }



    void CheckingRight()
    {
        // Right=false;
        if (transform.eulerAngles.z == 0 && transform.localScale.x == 1)
        {
            Right = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);

        }
        if (transform.eulerAngles.z == 0 && transform.localScale.x == -1)
        {
            Right = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
        }

        if (transform.eulerAngles.z == 90)
        {
            // print(Right);
            Right = Physics2D.OverlapCircle(GroundCheck.position, checkRadiusGround, Platforms);
            // print(Right);
        }

        if (transform.eulerAngles.z == 270)
        {
            Right = Physics2D.OverlapCircle(TopCheck.position, checkRadiusGround, Platforms);

        }
        // print(transform.eulerAngles.z);


        // Right= Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);

    }



    void CheckingTop()
    {
        // print(transform.eulerAngles.z);
        if (transform.eulerAngles.z == 0 && transform.localScale.y == 1)
        {
            Top = Physics2D.OverlapCircle(TopCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 0 && transform.localScale.y == -1)
        {
            Top = Physics2D.OverlapCircle(GroundCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 90 && transform.localScale.x == 1)
        {
            Top = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 90 && transform.localScale.x == -1)
        {
            Top = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 270 && transform.localScale.x == 1)
        {
            Top = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 270 && transform.localScale.x == -1)
        {
            Top = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);
        }
        // Top = Physics2D.OverlapCircle(TopCheck.position, checkRadiusGround, Platforms);
    }

}
