using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D _rb;
    Vector2 startingVelocity;

    public Color _currentColor;
    [SerializeField] List<Color> colors;

    // Start is called before the first frame update
    void Start()
    {
        if (colors.Count > 0) ChangeColor(colors[0]);
        _rb = GetComponent<Rigidbody2D>();
        startingVelocity = new Vector2(8,4);
        _rb.velocity = startingVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        _rb.velocity *= 1.001f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeColor(colors[Random.Range(0, colors.Count)]);
    }
    
    void ChangeColor(Color changeColor)
    {
        _currentColor = changeColor;
        GetComponent<SpriteRenderer>().color = _currentColor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   

        if (other.gameObject.CompareTag("Respawn")) Destroy(gameObject);
    }
}