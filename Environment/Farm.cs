using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    [SerializeField] private GameObject _energyPrefab;
    private Vector3 _newTransform;

    public void GiveEnergy()
    {
        Instantiate(_energyPrefab, _newTransform, Quaternion.identity);
        
    }

    void Start()
    {
        _newTransform = new Vector3 (transform.position.x + Random.Range(1,3), transform.position.y + Random.Range(1, 3), transform.position.z + Random.Range(1, 3));
        InvokeRepeating("GiveEnergy", 5f, 10f);
    }
}
