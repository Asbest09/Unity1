using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmSound;
    [SerializeField] private float _maxVolumeAlarm;
    [SerializeField] private float _duration;

    private AudioSource _alarm;
    private float _runningTime;

    public IEnumerable AlarmSystem(int volumeMultiplier = 1)
    {
        if(_runningTime <= _duration && _runningTime >= 0)
        {
            _runningTime += Time.deltaTime;

            float normalizeRunningTime = _runningTime / _duration;

            _alarm.volume = Mathf.Lerp(_alarm.volume, _maxVolumeAlarm, normalizeRunningTime);
            _alarm.Play();

            yield return null;
        }
    }
}
