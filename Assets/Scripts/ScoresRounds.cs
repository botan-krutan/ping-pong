using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoresRounds : MonoBehaviour
{
    public static ScoresRounds instance;
    public int[] playerScores = new int[2];
    TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    
    void Start()
    {
        if (instance == null) instance = this;
        if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

    }
    public void ChangeScore(int playerIndex)
    {
        playerScores[playerIndex]++;
    }
    // Update is called once per frame
    void Update()
    {   
        if(SceneManager.GetActiveScene().name == "Game Scene")
        {
            scoreText = GameObject.Find("Scores").GetComponent<TextMeshProUGUI>();
            scoreText.text = $"{playerScores[0]}:{playerScores[1]}";
            return;
        }
        if (SceneManager.GetActiveScene().name == "Results")
        {
            if (playerScores[0] == 0 && playerScores[1] == 0) return;
            if (playerScores[0] == 5)
            {
                FindObjectOfType<Results>().p1wins = 1;
            }
            else if (playerScores[1] == 5) 
            {
                FindObjectOfType<Results>().p1wins = -1;
            }
            playerScores[0] = 0;
            playerScores[1] = 0;
        }

    }
    public void LoadNextScene()
    {
        IEnumerator ReloadAfterSeconds()
        {
            yield return new WaitForSeconds(1.5f);
            FindObjectOfType<ScenesManager>().LoadScene("Game Scene");
        }
        if(playerScores[0] == 5 || playerScores[1] == 5)
        {   
            FindObjectOfType<ScenesManager>().LoadScene("Results");
        }
        else
        {
            StartCoroutine(ReloadAfterSeconds());
        }

    }
}
