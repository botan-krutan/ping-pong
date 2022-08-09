using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackgroundMus : MonoBehaviour
{
    public static BackgroundMus instance;
    [SerializeField] AudioClip menu, game, results;
    string currrentScene;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (currrentScene != SceneManager.GetActiveScene().name)
        {
            currrentScene = SceneManager.GetActiveScene().name;
            switch(currrentScene)
            {
                case "Menu":
                    ChangeMusic(menu);
                    break;
                case "Game Scene":
                    ChangeMusic(game);
                    break;
                case "Results":
                    ChangeMusic(results);
                    break;
            }
        }
    }
    public void ChangeMusic(AudioClip clip)
    {
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
    }
}
