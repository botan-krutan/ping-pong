using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Results : MonoBehaviour
{
    public int p1wins = 0;
    [SerializeField] TextMeshProUGUI results, ask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (p1wins)
        {
            case 0:
                results.text = "A TIE!";
                ask.text = "Players, want to play again?";
                break;
            case 1:
                results.text = "P1 WINS!";
                ask.text = "P2, want to get your revenge?";
                break;
            case -1:
                results.text = "P2 WINS!";
                ask.text = "P1, want to get some sweet revenge?";
                break;
        }
    }
}
