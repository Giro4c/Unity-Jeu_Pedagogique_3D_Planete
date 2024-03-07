using TMPro;
using UnityEngine;

public abstract class InformationDisplayer : MonoBehaviour
{

    [SerializeField] protected TextMeshProUGUI displayText;

    public abstract void Display();
    

}
