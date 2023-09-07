using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _direction;

    public float _gravity = -9.81f;

    public float strengt = 5f;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            _direction = Vector3.up * strengt;
        }

        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) 
            {
                _direction = Vector3.up * strengt;
            }
        }

        _direction.y += _gravity * Time.deltaTime;
        transform.position += _direction * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (collision.gameObject.tag == "Score") 
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }

    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        _direction = Vector3.zero;
    }
}
