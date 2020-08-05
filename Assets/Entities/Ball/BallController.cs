using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    GameObject poundCloud;
    GameObject bounceRing;
    GameObject paddle;
    Rigidbody2D myBody;
    Animator anim;
    Vector2 storedVelocity;
    PaddleController paddleController;
    CameraShake cameraShake;

    public float ballSpeed = 10f;
    public float maxVelocity = 60f;
    int jumpHash = Animator.StringToHash("Jump");
    int poundHash = Animator.StringToHash("Pound");
    bool gameStarted = false;
    float constantSpeed = 8.0f;

    void Start () {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        paddle = GameObject.Find("Paddle");
        transform.position = new Vector2(paddle.transform.position.x + 0.4f, paddle.transform.position.y);
        paddleController = FindObjectOfType<PaddleController>();
        cameraShake = FindObjectOfType<CameraShake>();
    }

    void Awake()
    {
        poundCloud = GameObject.Find("Pound Cloud");
        bounceRing = GameObject.Find("Bounce Ring");
    }

    // Update is called once per frame
    void Update () {

        if (!gameStarted)
        {
            StartTheGame();
        }
        else
        { 
            CheckIfStuckAndGetUnstuck();

            if (Input.GetButtonDown("Fire 1"))    ///JUMP!
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                    anim.SetTrigger(jumpHash);
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
                {
                    anim.SetTrigger(poundHash);
                    cameraShake.shakeCamera = true;
                }
            }

            if (Input.GetButtonDown("Fire 2"))
            {
                myBody.velocity *= 0;
                myBody.velocity = new Vector2(0f, 30f);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
                gameObject.layer = 9;
            else
                gameObject.layer = 13;

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Ground Pound"))
            {
                myBody.velocity *= 0f;
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < .25f) {
                    poundCloud.transform.position = new Vector3(transform.position.x, transform.position.y);
                    poundCloud.SetActive(true);
                    bounceRing.transform.position = new Vector3(transform.position.x, transform.position.y);
                    bounceRing.SetActive(true);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        bool stuckOnYAxis = colInfo.collider.tag == "Wall" && Mathf.Abs(myBody.velocity.x) <= 0.5f;
        bool stuckOnXAxis = colInfo.collider.tag == "Wall" && Mathf.Abs(myBody.velocity.y) <= 0.01f;

        if (stuckOnXAxis)
        {
            GetUnstuckFromXAxis();
        }
        else if (stuckOnYAxis)
        {
            GetUnstuckFromYAxis();
        }
    }

    void GetUnstuckFromXAxis()
    {
        myBody.velocity = new Vector2(myBody.velocity.x, myBody.velocity.y + 3f);
    }

    void GetUnstuckFromYAxis()
    {
        if (myBody.velocity.x == 0f)
            myBody.velocity = new Vector2(myBody.velocity.x - 3f, myBody.velocity.y);
        else
            myBody.velocity = new Vector2(myBody.velocity.x * 6f, myBody.velocity.y);
    }

    void StartTheGame()
    {
        Debug.Log(paddle.transform.position);
        transform.position = new Vector2(paddle.transform.position.x + 0.4f, paddle.transform.position.y);
        if (Input.GetButtonDown("Fire 1"))
        {
            myBody.AddForce(Vector2.right * ballSpeed * Time.deltaTime);
            gameStarted = true;
        }
    }

    void CheckIfStuckAndGetUnstuck()
    {
        bool ballIsAtZeroVelocity = (myBody.velocity == Vector2.zero);
        bool ballIsHittingThePaddle = (paddleController.hittingPaddle);

        if (ballIsAtZeroVelocity)
        {
            if (!ballIsHittingThePaddle && !anim.GetCurrentAnimatorStateInfo(0).IsName("Ground Pound"))
                myBody.velocity = storedVelocity;   
        }
        else
            storedVelocity = myBody.velocity;

    }

    void MaintainVelocity()
    {
        if (myBody.velocity.sqrMagnitude > maxVelocity)
        {
            //smoothness of the slowdown is controlled by the 0.99f, 
            //0.5f is less smooth, 0.9999f is more smooth
            myBody.velocity *= 0.99f;
        }
        else
        {
            myBody.velocity *= 1.01f;
        }
    }

    void MaintainVelocity2()
    {
        myBody.velocity = constantSpeed * (myBody.velocity.normalized);
    }

    void LateUpdate()
    {
        MaintainVelocity2();
    }
}
