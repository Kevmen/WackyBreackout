using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    /// <summary>
    /// this script manage the ball
    /// </summary>
    /// 
    Timer timer;
    Timer timerMove;
    Camera mainCamera;
    float speedBallEvent = 1.0f;
    bool isDestroyed = false;

    GameObject[] ball;


    private void OnEnable()
    {
        EventManager.SpeedupAction += ballSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        timerMove = gameObject.AddComponent<Timer>();
        timerMove.Duration = 1;
        timerMove.Run();
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = ConfigurationUtils.BallLifeTime;
        timer.Run();
        mainCamera = Camera.main;

        

    }

    public void SetDirection(Vector2 direction)
    {
        Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D>();
        float velocity = rb2d.velocity.magnitude;
        rb2d.velocity = (direction * velocity);
        
        //rb2d.MovePosition(direction * velocity * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerMove.Running && !timerMove.stopValue)
        {
            Vector3 angle = Quaternion.AngleAxis(90, Vector3.forward) * Vector3.right;
            gameObject.GetComponent<Rigidbody2D>().AddForce(angle * ConfigurationUtils.BallImpulseForce * speedBallEvent, ForceMode2D.Impulse);
            timerMove.Stop();
        }
        if (!timer.Running)
        {
            Destroy(gameObject);
            isDestroyed = true;
            
        }
        ball = GameObject.FindGameObjectsWithTag("Ball");
        if (isDestroyed && ball == null)
        {
            mainCamera.GetComponent<BallSpawner>().Spawner();
            isDestroyed = false;
        }
        
    }

    void ballSpeed()
    {
        float timePassed = 0.0f;
        if (timePassed < ConfigurationUtils.FreezerEffect)
        {
            timePassed += Time.deltaTime;
            speedBallEvent = 2.0f;
        }
        else
        {
            speedBallEvent = 1.0f;
        }
    }

    void OnBecameInvisible()
    {
        if(mainCamera != null)
        {
            Destroy(this.gameObject);
            mainCamera.GetComponent<BallSpawner>().Spawner();
            HUD.BallManager();
        }
    }

    private void OnDisable()
    {
        EventManager.SpeedupAction -= ballSpeed;
    }
}
