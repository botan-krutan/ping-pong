using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class RainbowBG : MonoBehaviour
{
    [SerializeField]  Color firstColor, secondColor;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RawImage>().DOColor(secondColor, 3).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
