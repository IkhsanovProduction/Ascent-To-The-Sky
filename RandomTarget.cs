using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTarget : MonoBehaviour
{
    [Header("Random target coordinates(Min and Max)")]
    [SerializeField] private int _moveSpotMin;
    [SerializeField] private int _moveSpotMax;
    [SerializeField] private float _startWaitTime;
    [SerializeField] private int _distanceToRandomTarget = 20;
    private float _waitTime;

    public void DistanceCheck(GameObject _character)
    {
        if (Vector3.Distance(_character.transform.position, transform.position) < _distanceToRandomTarget)
        {
            if (_waitTime <= 0)
            {
                transform.position = new Vector3(Random.Range(_moveSpotMin, _moveSpotMax),
                                         transform.position.y, Random.Range(_moveSpotMin, _moveSpotMax));
                _waitTime = _startWaitTime;
            }

            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }
}
