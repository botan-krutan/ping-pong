using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class StartingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        transform.DOScale(1, 1).OnComplete(() =>
        {
            GetComponent<TextMeshProUGUI>().DOFade(0, 1).OnComplete(() => 
            {
                GameObject.Find("Ball").GetComponent<Ball>().Go();
                Destroy(gameObject);
            } );
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
