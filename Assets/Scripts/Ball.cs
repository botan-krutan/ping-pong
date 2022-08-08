using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Ball : MonoBehaviour
{
    Rigidbody2D _rb;
    Vector2 startingVelocity;

    public Color _currentColor;
    [SerializeField] List<Color> colors;
    [SerializeField] GameObject explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (colors.Count > 0) ChangeColor(colors[0]);
    }

    public void Go()
    {
        
        
        startingVelocity = new Vector2(Mathf.Sign(Random.Range(-2, 2)) * 6, Mathf.Sign(Random.Range(-2, 2)) * 3);
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

        if (other.gameObject.CompareTag("Respawn"))
        {
            Camera.main.DOShakeRotation(0.7f, 10, 10, 60);
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            if (other.gameObject.name == "Wall 1") ScoresRounds.instance.ChangeScore(1);
            else ScoresRounds.instance.ChangeScore(0);
            ScoresRounds.instance.ReloadScene();
            Destroy(gameObject);
            
        }
    }
}