using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInGameCustomization : MonoBehaviour
{
    [Header("Helmet's material")]
    [SerializeField] private Material _redMaterial;
    [SerializeField] private Material _blackMaterial;
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private Material _yellowMaterial;
    [SerializeField] private Material _glitchMaterial;
    [SerializeField] private Material _forceMaterial;
    
    void ChangeHelmet(Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
    }

    void Awake()
    {
        switch (PlayerPrefs.GetString("Helmet"))
        {
            case "RED":
                ChangeHelmet(_redMaterial);
                break;
            case "BLACK":
                ChangeHelmet(_blackMaterial);
                break;
            case "GREEN":
                ChangeHelmet(_greenMaterial);
                break;
            case "YELLOW":
                ChangeHelmet(_yellowMaterial);
                break;
            case "GLITCH":
                ChangeHelmet(_glitchMaterial);
                break;
            case "FORCE":
                ChangeHelmet(_forceMaterial);
                break;
        }
    }
}
