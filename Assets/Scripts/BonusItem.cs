using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BonusItem : MonoBehaviour
{
    public Image imageObj;
    
    public TMP_Text countTextObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateItemInfo(Sprite itemTexture, int itemCount)
    {
        imageObj.GetComponent<Image>().sprite = itemTexture;
        countTextObj.text = "x" + itemCount;
    }
}
