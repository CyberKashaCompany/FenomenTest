using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContinueCost : MonoBehaviour
{
    [SerializeField]
    private int continueCost;

    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = continueCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
