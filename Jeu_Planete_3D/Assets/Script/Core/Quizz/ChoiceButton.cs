using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Button))]
public class ChoiceButton : MonoBehaviour
{
    // Values
    public bool selected { get; private set; } = false;
    public Choice choice { get; set; } = new Choice("", false);
    
    // Visual
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _button;
    
    // Colors
    [SerializeField] private Color _selectedColor = Color.yellow;
    private Color _defaultColor = Color.white;
    
    private void Start()
    {
        _defaultColor = _image.color;
    }

    public void ActivationButton(bool activation)
    {
        _button.interactable = activation;
    }

    public void ResetSelection()
    {
        selected = false;
        if (_image != null)
        {
            ChangeColorImage(_defaultColor);
        }
    }
    
    public void Selection()
    {
        selected = !selected;
        if (_image != null)
        {
            ChangeColorImage();
        }
    }

    public TextMeshProUGUI GetText()
    {
        return _text;
    }

    public Button GetButton()
    {
        return _button;
    }

    public void ChangeColorImage(Color color)
    {
        _image.color = color;
    }

    private void ChangeColorImage()
    {
        if (selected)
        {
            _image.color = _selectedColor;
        }
        else
        {
            _image.color = _defaultColor;
        }
    }
}
