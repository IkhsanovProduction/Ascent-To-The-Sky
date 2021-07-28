using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : InteractableItemBase
{
    [SerializeField] GameObject _carController;
    [SerializeField] Camera _carCamera;
    [SerializeField] Camera _playerCamera;
    [SerializeField] GameObject _carButton;

    void Start()
    {
        _carButton.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.Player.IsEnterToTransport)
        {
            SetEnterToCar(GameManager.Instance.Player);
        }
    }

    void SetEnterToCar(Character character)
    {
        Debug.Log("IsEnter");
        _carController.SetActive(true);
        _carCamera.enabled = true;
        _playerCamera.enabled = false;
        _carButton.SetActive(true);
        character.MeshRenderer.SetActive(false);
    }

    public void SetExitFromCar(Character character)
    {
        Debug.Log("Exit");
        character.IsEnterToTransport = false;
        character.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        character.MeshRenderer.SetActive(true);

        _carCamera.enabled = false;
        _playerCamera.enabled = true;
        _carController.SetActive(false);
        _carButton.SetActive(false);
    }

    public override void OnInteract()
    {
        GameManager.Instance.Player.IsEnterToTransport = true;
    }
}
