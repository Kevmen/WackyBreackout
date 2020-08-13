using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block
{
    [SerializeField]
    Sprite prefabFreezeBlock;
    [SerializeField]
    Sprite prefabSpeedUpBlock;
    [SerializeField]
    GameObject prefabFreeze;
    [SerializeField]
    GameObject prefabSpeedup;

    private Sprite spriteUsed;

    private PickupEffect _effect;

    float freeze;

    protected FreezerEffectActivated freezerEffectActivated = new FreezerEffectActivated();

    public string Effect
    {
        get { return _effect.ToString(); }
        set
        {
            if (value == "Freezer")
            {
                _effect = PickupEffect.Freezer;
                spriteUsed = prefabFreezeBlock;
                freeze = ConfigurationUtils.FreezerEffect;
                Debug.Log("freeze");
                GetComponent<SpriteRenderer>().sprite = prefabFreezeBlock;
                //EventManager.AddListener();
                //Instantiate(prefabFreeze, transform.position, Quaternion.identity);
            }
            else if(value == "Speedup")
            {
                _effect = PickupEffect.Speedup;
                spriteUsed = prefabSpeedUpBlock;
                Debug.Log("speedup");
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ball"))
        {
            EventManager.HUDModification(points);
            spawnEffectObjectEvent();
            Destroy(this.gameObject);
        }
    }

    void spawnEffectObjectEvent()
    {
        if(_effect.ToString() == "Freezer")
        {
            Instantiate(prefabFreeze, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(prefabSpeedup, transform.position, Quaternion.identity);
        }
        
    }

    public void OnDisable()
    {
        
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        points = 10;
        int randomVar = Random.Range(0, 2);
        if (randomVar == 0)
        {
            Effect = "Freezer";

        }
        else
        {
            Effect = "Speedup";
        }

        //EventManager.AddInvoker(this);
        //var test = Effect;
        //freeze = ConfigurationUtils.FreezerEffect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void freezeEffectActivatedListener(UnityAction<float> listener)
    //{
    //    freezerEffectActivated.AddListener(listener);
    //}

}
