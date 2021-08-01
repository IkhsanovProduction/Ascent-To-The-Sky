using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBlock : Supplies
{
    [SerializeField] private int _powerValue = 5;
    private GameObject _energyCopy;

    private MeshRenderer _energyMeshRenderer;
    private int value;

    public override GameObject Copy { get { return _energyCopy; }  set { _energyCopy = value; } }

    public override int PowerValue { get { return _powerValue; } set { _powerValue = value; } }
    
    public override void AddValueToPlayer()
    {
        value = PlayerPrefs.GetInt("Supplier");
        value += 1;
        PlayerPrefs.SetInt("Supplier", value);
    }

    void Start()
    {
        _energyMeshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        PlayerPrefs.SetInt("Supplier", 0);
    }

    public void AddToPlayerBack()
    {
        _energyCopy = GameObject.FindWithTag("En");

        if (_energyCopy != null)
        {
            _energyMeshRenderer.enabled = false;
            _energyCopy.SetActive(true);
            _energyCopy.GetComponent<MeshRenderer>().enabled = true;

            GameManager.Instance.Player.IsHaveSupplier = true;
        }
    }

    public override void OnInteract()
    {
        if(GameManager.Instance.Player.IsHaveSupplier != true)
        {
            AddToPlayerBack();
        }

        else
        {
            InteractText = "You have a supplier, please go to Center";
        }
    }

    public void GiveToCenter()
    {
        if (GameManager.Instance.Player.IsHaveGiveToCenter == true)
        {
            _energyCopy.GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject);

            AddValueToPlayer();
            GameManager.Instance.Player.IsHaveGiveToCenter = false;
            
        }
    }

    void Update()
    {
        GiveToCenter();
    }
}
