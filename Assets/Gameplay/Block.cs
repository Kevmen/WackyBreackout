using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Block : MonoBehaviour
{
    protected int points = 20;

    

    // Start is called before the first frame update
    virtual protected void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.collider.CompareTag("Ball"))
        {
            //HUD.ScoreManager(points);
            EventManager.HUDModification(points);
            Destroy(this.gameObject);
            
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
