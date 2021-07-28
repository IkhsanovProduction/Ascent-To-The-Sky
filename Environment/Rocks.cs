using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    [SerializeField] private int _minResourceValue;
    [SerializeField] private int _maxResourceValue;

    [SerializeField] private GameObject _resource;
    [SerializeField] private GameObject _decomposeEffect;
    [SerializeField] private GameObject _attackingEffect;

    [SerializeField] private int _endurance = 5;
    
    private void TakeDamage()
    {
        _endurance -= 1;
        Instantiate(_attackingEffect, transform.position, transform.rotation);
    }

    private void Decompose()
    {
        Instantiate(_decomposeEffect, transform.position, transform.rotation);
        Destroy(_decomposeEffect, 2);

        for(int i = 0; i < Random.Range(_minResourceValue, _maxResourceValue); i++)
        {
            Instantiate(_resource, transform.position, Quaternion.identity);
        }

        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1);
        DestroyImmediate(gameObject, true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet") )
        {
            TakeDamage();

            DecomposeCheck();
        }
    }

    private void DecomposeCheck()
    {
        if (_endurance <= 0)
        {
            Decompose();
        }
    }
}
