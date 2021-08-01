using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public enum Environments
    {
        TransferCenter,
        FirstAid,
        OxygenBag,
        Car,
        RoboHelper,
        Farm,
        LightCenter,
        RoboSuper,
        Droid
    }

    [SerializeField] private GameObject _tranferCenter;
    [SerializeField] private GameObject _car;
    [SerializeField] private GameObject _roboHelper;

    [SerializeField] private GameObject _first;
    [SerializeField] private GameObject _oxygenBag;
    [SerializeField] private GameObject _farm;
    [SerializeField] private GameObject _lightCenter;
    [SerializeField] private GameObject _roboSuper;
    [SerializeField] private GameObject _droid;
 
    [SerializeField] private Transform _thisTransform;
    
    public void InstantiateObject(GameObject objectForInstantiate)
    {
        _thisTransform.position = new Vector3(GameManager.Instance.Player.transform.position.x + 1, GameManager.Instance.Player.transform.position.y + 1,
                                             GameManager.Instance.Player.transform.position.z + 1 );
        Instantiate(objectForInstantiate, _thisTransform.position, Quaternion.identity);
    }

    public void Parse(string myString)
    {
        try
        {
            Environments enumerable = (Environments)System.Enum.Parse(typeof(Environments), myString);

            switch (enumerable)
            {
                case Environments.TransferCenter:
                    InstantiateObject(_tranferCenter);
                    break;
                case Environments.FirstAid:
                    InstantiateObject(_first);
                    break;
                case Environments.OxygenBag:
                    InstantiateObject(_oxygenBag);
                    break;
                case Environments.Car:
                    InstantiateObject(_car);
                    break;
                case Environments.RoboHelper:
                    InstantiateObject(_roboHelper);
                    break;
                case Environments.Farm:
                    InstantiateObject(_farm);
                    break;
                case Environments.LightCenter:
                    InstantiateObject(_lightCenter);
                    break;
                case Environments.RoboSuper:
                    InstantiateObject(_roboSuper);
                    break;
                case Environments.Droid:
                    InstantiateObject(_droid);
                    break;
                default:
                    Debug.Log("Default Settings");
                    break;
            }
        }
        catch (System.Exception)
        {
            Debug.LogErrorFormat("Parse: Can't convert {0} to enum, please check the spell.", myString);
        }
    }
}
