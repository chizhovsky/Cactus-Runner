using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusBehaviourScript : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _isJumping;
    [SerializeField] private GameObject _cactus;
    [SerializeField] private GameObject _crouchingCactus;
    [SerializeField] private Animator _anim;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _isJumping = false;
        _anim = GetComponent<Animator>();        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            GetComponent<AudioSource>().Play();
            _rb.velocity = new Vector3(0, 20, 0);
            _isJumping = true;
        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !_isJumping && !GameManager.Instance.gameIsOver)
        {
            _crouchingCactus.SetActive(true);
            _cactus.SetActive(false);
        }
        if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) && !_isJumping && !GameManager.Instance.gameIsOver)
        {
            _crouchingCactus.SetActive(false);
            _cactus.SetActive(true);
        }
        if (GameManager.Instance.gameIsOver)
        {
            _anim.SetTrigger("Dead");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isJumping = false;
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Dinosaur")
        {
            GameManager.Instance.GameOver();
        }
    }
}