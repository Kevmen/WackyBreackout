using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    [SerializeField]
    Sprite standardSprite1;
    [SerializeField]
    Sprite standardSprite2;
    [SerializeField]
    Sprite standardSprite3;

    protected override void Start()
    {
        int spriteSelect = Random.Range(0, 3);
        if(spriteSelect == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = standardSprite1;
        }else if(spriteSelect == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = standardSprite2;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = standardSprite3;
        }
        points = 20;
        base.Start();
    }


}
