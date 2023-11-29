using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBase : MonoBehaviour
{
    PlayerInputActions input;

    private void Awake()
    {
        input = new PlayerInputActions();
    }

    protected virtual void OnEnable()
    {
        input.Test.Enable();
        input.Test.Test1.performed += Test1;
        input.Test.Test2.performed += Test2;
        input.Test.Test3.performed += Test3;
        input.Test.Test4.performed += Test4;
        input.Test.Test5.performed += Test5;
        input.Test.TestClick.performed += TestClick;
    }

    protected virtual void OnDisable()
    {
        input.Test.TestClick.performed += TestClick;
        input.Test.Test5.performed += Test5;
        input.Test.Test4.performed += Test4;
        input.Test.Test3.performed += Test3;
        input.Test.Test2.performed += Test2;
        input.Test.Test1.performed += Test1;
        input.Test.Disable();
    }
    protected virtual void Test1(UnityEngine.InputSystem.InputAction.CallbackContext context) { }
    protected virtual void Test2(UnityEngine.InputSystem.InputAction.CallbackContext context) { }
    protected virtual void Test3(UnityEngine.InputSystem.InputAction.CallbackContext context) { }
    protected virtual void Test4(UnityEngine.InputSystem.InputAction.CallbackContext context) { }
    protected virtual void Test5(UnityEngine.InputSystem.InputAction.CallbackContext context) { }
    protected virtual void TestClick(UnityEngine.InputSystem.InputAction.CallbackContext context) { }
}
