using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Paddle : MonoBehaviour
{

    /// <summary>
    /// this code move the paddle in game
    /// </summary>
    /// 
    //declare a rigidbody field to store rb attached on GO paddle
    Rigidbody2D rbPaddle;

    //store the collider 
    BoxCollider2D boxCollider;

    float halfColliderWidth;
    float halfColliderHeight;
    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;
    float translation;


    bool blockedActive = false;
    float timePassed = 0.0f;
    float freeze = 1;


    bool paddleFreezed = false;

    // Start is called before the first frame update
    public void Start()
    {
        rbPaddle = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        halfColliderWidth = boxCollider.size.x / 2;
        halfColliderHeight = boxCollider.size.y / 2;

    }
    
    //fixed update to manage physics
    void FixedUpdate()
    {
        translation = Input.GetAxis("Horizontal");
        if (translation != 0)
        {
            Vector2 move = new Vector2(ConfigurationUtils.PaddleMoveUnitsPerSecond, 0);
            Vector2 velocity = new Vector2(1.75f, 1.1f);
            float xPosition = rbPaddle.transform.position.x;
            xPosition = CalculateClampedX(xPosition);
            //rbPaddle.transform.position = (Vector2 )
            //rbPaddle.transform.position = (rbPaddle.position + move * Time.fixedDeltaTime * translation);
            rbPaddle.MovePosition(new Vector2(xPosition,rbPaddle.position.y) + move*Time.fixedDeltaTime*translation*freeze);
        }
    }

    public float CalculateClampedX(float xPosition)
    {
        float left = ScreenUtils.ScreenLeft;
        float right = ScreenUtils.ScreenRight;

        if (xPosition < left + halfColliderWidth)
        {
            xPosition = left + halfColliderWidth;
        }
        else if (xPosition > right - halfColliderWidth)
        {
            xPosition = right - halfColliderWidth;
        }
        return xPosition;
    }


    public bool TopCollider(Collision2D ball)
    {
        float contactX = ball.transform.position.x;
        float paddleX = transform.position.x;
        float tolerance = 0.05f;
        if(contactX < (paddleX + halfColliderWidth - tolerance) || contactX > (paddleX - halfColliderWidth + tolerance))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        bool topcollider = TopCollider(coll);

        if (coll.gameObject.CompareTag("Ball") && topcollider)
        {
            
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
        if(coll.gameObject.layer == 10)
        {
            Destroy(coll.gameObject);
            paddleFreezed = !paddleFreezed;
            blockedActive = !blockedActive;
        }else if(coll.gameObject.layer == 11)
        {
            Destroy(coll.gameObject);
            EventManager.SpeedupAction();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (blockedActive)
        {
            if (timePassed < ConfigurationUtils.FreezerEffect)
            {
                timePassed += Time.deltaTime;
                freeze = 0;
            }
            else
            {
                blockedActive = false;
                freeze = 1;
            }
        }
        if (timePassed > ConfigurationUtils.FreezerEffect && !blockedActive)
        {
            timePassed = 0.0f;
        }
    }

}
