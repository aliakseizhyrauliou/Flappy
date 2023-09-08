using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    private SpriteRenderer _currentWingsSprite;
    public Sprite[] _wingsSprites;
    private int _wingsIndex = 0;

    private Vector3 _previousPosition;
    public float downRotationAngle = -15f; // Угол поворота вниз
    public float upRotationAngle = 15f;

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

    private void Update()
    {
        var currentY = transform.position.y;

        if (currentY > _previousPosition.y)
        {
            // Птица движется вверх, поворачиваем вверх
            RotateBird(upRotationAngle);
        }
        else if (currentY < _previousPosition.y)
        {
            // Птица движется вниз, поворачиваем вниз
            RotateBird(downRotationAngle);
        }
        
        _previousPosition.y = currentY; 
    }

    private void RotateBird(float angle)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }
}
