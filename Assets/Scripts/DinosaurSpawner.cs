using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurSpawner : MonoBehaviour
{
    private float _maxTime;
    private float _timer;
    [SerializeField] private GameObject[] _dinosaurs;

    void Start()
    {
        _maxTime = 2f;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _maxTime)
        {
            GenerateDinosaur();
            _timer = 0;
        }
    }

    void GenerateDinosaur()
    {
        int randomNumber = Random.Range(0, _dinosaurs.Length);
        GameObject newDinosaur = Instantiate(_dinosaurs[randomNumber]);
    }
}
