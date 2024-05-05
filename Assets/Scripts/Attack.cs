using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private GameObject _house;
    [SerializeField] private float _maxDelta;

    private Transform _player;
    private bool _playerInHouse;
    private Alarm _alarmSystem;

    private void Start()
    {
        _player = GetComponent<Transform>();
        _alarmSystem = new Alarm();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(_door.position, _player.position) <= _maxDelta)
        {
            if (_playerInHouse)
                Escape();
            else
                Hacking();
        }
    }

    private void Hacking()
    {
        _house.SetActive(true);
        _playerInHouse = true;

        //StartCoroutine(AlarmSystem());
    }

    private void Escape()
    {
        _house.SetActive(false);
        _playerInHouse = false;
    }
}
