using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMovementScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] public float _screenStart;
    [SerializeField] public float _screenEnd;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);
        if (transform.position.x <= _screenEnd)
        {
            if (gameObject.tag == "Dinosaur")
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = new Vector2(_screenStart, transform.position.y);
            }
        }
    }
}
