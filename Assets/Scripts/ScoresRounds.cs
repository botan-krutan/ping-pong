using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoresRounds : MonoBehaviour
{
    public static ScoresRounds instance;
    public int numberOfRounds;
    public int[] playerScores = new int[2];
    TextMeshProUGUI scoreText, roundsText, resultsText;
    
    // Start is called before the first frame update
    
    void Start()
    {
        if (instance == null) instance = this;
        if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().name == "Results")
        {
            if (playerScores[0] > playerScores[1])
            {
                FindObjectOfType<Results>().p1wins = 1;
            }
            else if (playerScores[1] > playerScores[0])
            {
                FindObjectOfType<Results>().p1wins = -1;
            }
            else if (playerScores[1] == playerScores[0]) FindObjectOfType<Results>().p1wins = 0;
            playerScores[0] = 0;
            playerScores[1] = 0;
        }
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
            roundsText = GameObject.Find("Rounds").GetComponent<TextMeshProUGUI>();
            roundsText.text = $"Rounds Left: {numberOfRounds}";
        }


    }
    public void LoadNextScene()
    {
        IEnumerator ReloadAfterSeconds()
        {
            yield return new WaitForSeconds(1.5f);
            FindObjectOfType<ScenesManager>().LoadScene("Game Scene");
        }
        if(numberOfRounds == 1)
        {   
            FindObjectOfType<ScenesManager>().LoadScene("Results");
        }
        else
        {
            numberOfRounds--;
            StartCoroutine(ReloadAfterSeconds());
        }

    }
}
