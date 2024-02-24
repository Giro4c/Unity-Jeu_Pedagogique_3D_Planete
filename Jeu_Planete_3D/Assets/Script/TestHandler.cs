using UnityEngine;
using UnityEngine.InputSystem;

public class TestHandler : MonoBehaviour
{

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        // Debug.Log(context.started);
        // Debug.Log(context.performed);
        // Debug.Log(context);
        if (!context.started) return;
        Vector3 pos = Mouse.current.position.ReadValue();
        // Debug.Log(pos);
        // Vector2 pos2 = Mouse.current.position.ReadValue();
        // Debug.Log(pos2);
    }
    
}
