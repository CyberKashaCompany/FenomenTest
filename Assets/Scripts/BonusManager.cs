using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public GameObject rewardPrefab;

    public Sprite[] possibleRewards;

    [SerializeField]
    private int maxItemCount = 0;


    void Start()
    {
        
        int a = Random.Range(0, possibleRewards.Length);
        for (int i=0;i<=a;i++)
        {
            GameObject item = Instantiate(rewardPrefab, gameObject.transform);
            int randomCount = Random.Range(1, maxItemCount);
            item.GetComponent<BonusItem>().UpdateItemInfo(possibleRewards[i], randomCount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
