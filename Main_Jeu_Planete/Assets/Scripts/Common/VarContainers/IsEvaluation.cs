using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class IsEvaluation : MonoBehaviour
{
    public Button evalStarter;
    private bool eval;
    
    // Start is called before the first frame update
    void Start()
    {
        eval = false;
        if (evalStarter == null)
        {
            enabled = false;
        }
        else
        {
            // Add event listener on start evaluation button to change eval to true on clicked. Players cannot go back to discovery phase after clicking the evaluation button.
            evalStarter.onClick.AddListener( () => {
                eval = true;
            });
        }
    }

    public bool IsEvalBool()
    {
        return eval;
    }
    
    public int IsEvalInt()
    {
        if (eval) return 1;
        return 0;
    }
    
}
