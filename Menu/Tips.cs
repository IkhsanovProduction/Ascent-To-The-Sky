using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
    [SerializeField] private List<string> tips = new List<string>();
    [SerializeField] private Text _tipText; 
    private int _time = 1000;

    private string ReturnTip()
    {
        if(tips != null)
        {
            return tips[Random.Range(0, tips.Count)];
        }

        else
        {
            return null;
        }
    }

    void Update()
    {
        _time -= 1;

        if(_time == 0)
        {
            _tipText.text = ReturnTip().ToString();
            _time = 1000;
        }
        
    }

}
