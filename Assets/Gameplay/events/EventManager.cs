using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EventManager : MonoBehaviour
{
    //public delegate void ballCollision();
    //public static event ballCollision blockResponse;
    public static Action<int> HUDModification;
    public static Action SpeedupAction;
    static List<PickupBlock> invokers = new List<PickupBlock>();
    static List<UnityAction<float>> listeners = new List<UnityAction<float>>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (HUDModification != null)
        {
            int points = 0;
            HUDModification(points);
            
        }
        if (SpeedupAction != null)
        {
            SpeedupAction();
        }
    }
}
