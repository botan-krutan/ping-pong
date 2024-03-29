using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerController : MonoBehaviour
{   
    Camera _camera;
    public Color _currentColor;
    [SerializeField] List<Color> colors;
    int colorIndex;
    [SerializeField] KeyCode moveUp, moveDown, colorUp, colorDown;
    [SerializeField] float movementSpeed;
    [SerializeField] AudioClip sw;
    // Start is called before the first frame update
    void Start()
    {
        if (colors.Count > 0) ChangeColor(colors[0]);

        _camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        Color();
    }
    void Movement()
    {
        if (Input.GetKey(moveUp) && transform.position.y < 3.5)
        { 
            //Debug.Log("AEYEYA");
            transform.Translate(movementSpeed * Vector2.up * Time.deltaTime);
        }
        if (Input.GetKey(moveDown) && transform.position.y > -3.5)
        {
            transform.Translate(movementSpeed * Vector2.down * Time.deltaTime);
        }
    }
    void Color()
    {
        if (Input.GetKeyDown(colorUp))
        {
            if (colorIndex + 1 == colors.Count)
            {
                colorIndex = 0;
            }
            else colorIndex++;

            ChangeColor(colors[colorIndex]);
            transform.DORewind();
            transform.DOShakeScale(0.3f, 0.3f, 9, 60);
            AudioPlayer.Instance.PlayAudio(sw);
        }
        if (Input.GetKeyDown(colorDown))
        {
            if (colorIndex - 1 == -1)
            {
                colorIndex = colors.Count - 1;
            }
            else colorIndex--;

            ChangeColor(colors[colorIndex]);
            transform.DORewind();
            transform.DOShakeScale(0.3f, 0.3f, 9, 60);
            AudioPlayer.Instance.PlayAudio(sw);
        }
    }
    void ChangeColor(Color changeColor)
    {   
        
        _currentColor = changeColor;
        GetComponent<SpriteRenderer>().DOColor(_currentColor, 0.2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            if (collision.gameObject.GetComponent<Ball>()._currentColor == _currentColor)
            {
                transform.DOShakeScale(0.5f, 0.5f, 9, 60);
                return;
            }
            StartCoroutine(DisableCollison(2));
        }
    }
    IEnumerator DisableCollison(int delay)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(delay);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
