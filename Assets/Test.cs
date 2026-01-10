using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnLook(InputValue value)
    {
        Vector2 lookDelta = value.Get<Vector2>();
        Debug.Log($"Look Delta: {lookDelta}");
    }
}
