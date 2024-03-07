/*
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Selected : MonoBehaviour
{
    private bool _selected;
    private TextMeshProUGUI _value;
    private Image _image;
    private Color _selectedColor = Color.yellow;
    private Color _defaultColor;

    private void Start()
    {
        _selected = false;
        _value = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        _image = gameObject.GetComponent<Image>();
        if (_image != null)
        {
            _defaultColor = _image.color;
        }
    }

    public bool IsSelected()
    {
        return _selected;
    }

    public void SetSelected(bool val)
    {
        _selected = val;
        ChangeColorImage();
    }

    public void Selection()
    {
        _selected = !_selected;
        ChangeColorImage();
    }

    public string GetStringValue()
    {
        if (_value == null) return null;
        return _value.text;
    }

    public void ChangeColorImage(Color color)
    {
        if (_image != null)
        {
            _image.color = color;
        }
    }

    public void ChangeColorImage()
    {
        if (_image != null)
        {
            if (_selected)
            {
                _image.color = _selectedColor;
            }
            else
            {
                _image.color = _defaultColor;
            }
        }
    }
}
*/
