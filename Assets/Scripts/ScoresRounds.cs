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
        scoreText.text = $"{playerScores[0]}:{playerScores[1]}";
    }
    // Update is called once per frame
    void Update()
    {
        scoreText = GameObject.Find("Scores").GetComponent<TextMeshProUGUI>();
        scoreText.text = $"{playerScores[0]}:{playerScores[1]}";
    }
    public void ReloadScene()
    {
        IEnumerator ReloadAfterSeconds()
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("Game Scene");
        }
        StartCoroutine(ReloadAfterSeconds());
    }
}
