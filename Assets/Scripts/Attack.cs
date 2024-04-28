using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private GameObject _house;
    [SerializeField] private AudioClip _alarmSound;
    [SerializeField] private float _maxVolumeAlarm;
    [SerializeField] private float _duration;

    private Transform _player;
    private AudioSource _alarm;
    private bool _playerInHouse;
    private float _runningTime;

    private void Start()
    {
        _player = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _player.position.x == _door.position.x && _playerInHouse == false)
            Hacking();

        if (Input.GetKeyDown(KeyCode.E) && _player.position.x == _door.position.x && _playerInHouse)
            Escape();

        if (_playerInHouse && _runningTime <= _duration)
        {
            _runningTime += Time.deltaTime;

            float normalizeRunningTime = _runningTime / _duration;

            _alarm.volume = Mathf.Lerp(_alarm.volume, _maxVolumeAlarm, normalizeRunningTime);
            _alarm.Play();
        }
    }

    private void Hacking()
    {
        _house.SetActive(true);
        _playerInHouse = true;
    }

    private void Escape()
    {
        _house.SetActive(false);
        _playerInHouse = false;
    }
}
