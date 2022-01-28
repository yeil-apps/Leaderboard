using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActiveCheck : MonoBehaviour
{
    [SerializeField] private Text[] _anotherText;
    private Color _mainColor;
    private float _colorA;

    private void Start()
    {
        _mainColor = transform.gameObject.GetComponent<Image>().color;
        _colorA = _mainColor.a;

        CheckAnotherText();
    }
    public void CheckAnotherText()
    {
        bool filled = true;

        foreach (Text txt in _anotherText)
        {
            if (txt.text == "") 
            {
                filled = false;
            }
        }

        if (filled == true)
        {
            transform.gameObject.GetComponent<Button>().enabled = true;
            _mainColor = new Vector4(_mainColor.r, _mainColor.b, _mainColor.g, _colorA);
        }
        else
        {
            transform.gameObject.GetComponent<Button>().enabled = false;
            _mainColor = new Vector4(_mainColor.r, _mainColor.b, _mainColor.g, _colorA/2);
            
        }

        transform.gameObject.GetComponent<Image>().color = _mainColor;
    }
}
