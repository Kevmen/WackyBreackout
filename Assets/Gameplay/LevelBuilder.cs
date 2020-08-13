using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject paddle;
    [SerializeField]
    GameObject prefabStandardBlock;
    [SerializeField]
    GameObject prefabBonusBlock;
    [SerializeField]
    GameObject prefabPickupBlock;


    float blockheight;
    float blockwidth;
    float counter = 0;
    int sum = 0;

    float border;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(paddle);
        GameObject prefabstandard = Instantiate(prefabStandardBlock);
        blockwidth = prefabstandard.GetComponent<BoxCollider2D>().size.x;
        blockheight = prefabstandard.GetComponent<BoxCollider2D>().size.y;
        Destroy(prefabstandard);
        float sizeScreen = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        for(counter = 0; counter < sizeScreen; counter += blockwidth)
        {
            border = (sizeScreen - counter) / 2;
            sum++;
        }

        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < sum; i++)
            {
                GameObject selection = placedBlock();
                Instantiate(selection, new Vector3(ScreenUtils.ScreenLeft + border + (i * blockwidth), ScreenUtils.ScreenTop - 2-(j*blockheight), 0), Quaternion.identity);
            }
        }
        
        
    }

    GameObject placedBlock()
    {
        GameObject selection;
        int maxNumber = 100;
        float standardpos = maxNumber * ConfigurationUtils.StandardProbability;
        float bonusPos = maxNumber * ConfigurationUtils.BonusProbability;
        float pickupProbability = maxNumber * ConfigurationUtils.PickupProbability;
        int selector = Random.Range(0, maxNumber);
        if (selector < standardpos)
        {
            selection = prefabStandardBlock;
        }
        else if(selector > standardpos && selector < standardpos + bonusPos)
        {
            selection = prefabBonusBlock;
        }
        else
        {
            selection = prefabPickupBlock;
        }

        return selection;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
        
    }
}
