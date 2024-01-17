using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestKnob : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        text.text = transform.rotation.eulerAngles.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowRotation()
    {
        text.text = transform.rotation.eulerAngles.ToString();
    }
}
