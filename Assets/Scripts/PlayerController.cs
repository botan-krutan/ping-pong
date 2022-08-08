using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera _camera;
    public Color _currentColor;
    [SerializeField] List<Color> colors;
    int colorIndex;
    [SerializeField] KeyCode moveUp, moveDown, colorUp, colorDown;
    [SerializeField] float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (colors.Count > 0) ChangeColor(colors[0]);

        _camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(moveUp))
        {
            //Debug.Log("AEYEYA");
            transform.Translate(movementSpeed * Vector2.up * Time.deltaTime);
        }
        if (Input.GetKey(moveDown))
        {
            transform.Translate(movementSpeed * Vector2.down * Time.deltaTime);
        }
        if (Input.GetKeyDown(colorUp))
        {
            if (colorIndex + 1 == colors.Count)
            {
                colorIndex = 0;
            }
            else colorIndex++;

            ChangeColor(colors[colorIndex]);
        }
        if (Input.GetKeyDown(colorDown))
        {
            if (colorIndex - 1 == -1)
            {
                colorIndex = colors.Count - 1;
            }
            else colorIndex--;

            ChangeColor(colors[colorIndex]);
        }
    }
    void ChangeColor(Color changeColor)
    {
        _currentColor = changeColor;
        GetComponent<SpriteRenderer>().color = _currentColor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            if (collision.gameObject.GetComponent<Ball>()._currentColor == _currentColor) return;
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
