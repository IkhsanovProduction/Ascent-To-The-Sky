using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : MonoBehaviour
{
    [Header("Helmet's material")]
    [SerializeField] private Material _redMaterial;
    [SerializeField] private Material _blackMaterial;
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private Material _yellowMaterial;
    [SerializeField] private Material _glitchMaterial;
    [SerializeField] private Material _forceMaterial;

    private enum Helmets
    {
        Red,
        Black,
        Green,
        Yellow,
        Glitch,
        Force
    }

    public void ChangeHelmet(Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material; 
    }

    public void ParseHelmets(string myString)
    {
        try
        {
            Helmets enumerable = (Helmets)System.Enum.Parse(typeof(Helmets), myString);

            switch (enumerable)
            {
                case Helmets.Red:
                    ChangeHelmet(_redMaterial);
                    PlayerPrefs.SetString("Helmet", "RED");
                    break;
                case Helmets.Black:
                    ChangeHelmet(_blackMaterial);
                    PlayerPrefs.SetString("Helmet", "BLACK");
                    break;
                case Helmets.Green:
                    ChangeHelmet(_greenMaterial);
                    PlayerPrefs.SetString("Helmet", "GREEN");
                    break;
                case Helmets.Yellow:
                    ChangeHelmet(_yellowMaterial);
                    PlayerPrefs.SetString("Helmet", "YELLOW");
                    break;
                case Helmets.Glitch:
                    ChangeHelmet(_glitchMaterial);
                    PlayerPrefs.SetString("Helmet", "GLITCH");
                    break;
                case Helmets.Force:
                    ChangeHelmet(_forceMaterial);
                    PlayerPrefs.SetString("Helmet", "FORCE");
                    break;
                default:
                    Debug.Log("Default Settings");
                    break;
            }
        }
        catch (System.Exception)
        {
            Debug.LogErrorFormat("Error of converting.", myString);
        }
    }
}
