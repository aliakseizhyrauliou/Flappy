using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    private SpriteRenderer _currentWingsSprite;
    public Sprite[] _wingsSprites;
    private int _wingsIndex = 0;
    public Rigidbody2D _currentRigidbody;
    private float _rotation = 30f;

    private void Awake()
    {
        _currentWingsSprite = GetComponent<SpriteRenderer>();  
    }

    void Start()
    {
        InvokeRepeating(nameof(ChangeWingsSprite), 0.15f, 0.15f);
    }


    void ChangeWingsSprite() 
    {
        _wingsIndex++;

        if (_wingsIndex > _wingsSprites.Count() - 1) 
        {
            _wingsIndex = 0;
        }

        _currentWingsSprite.sprite = _wingsSprites[_wingsIndex];
    }
/*
    void Update()
    {

        float tiltAngle = 0.0f;
        if (_currentRigidbody.velocity.y > 0)
        {
            // Если птица двигается вверх, устанавливаем угол наклона вверх
            tiltAngle = -_rotation;
        }
        else if (_currentRigidbody.velocity.y < 0)
        {
            // Если птица двигается вниз, устанавливаем угол наклона вниз
            tiltAngle = _rotation;
        }

        Quaternion targetRotation = Quaternion.Euler(tiltAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);
    }*/
}
