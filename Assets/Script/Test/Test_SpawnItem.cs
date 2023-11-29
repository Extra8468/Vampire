using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_SpawnItem : TestBase
{
    public GameObject item;
    protected override void Test1(InputAction.CallbackContext context)
    {
        for(int i = 0; i < 10; i++)
        {
            Instantiate(item);
            item.transform.position = new Vector3(i, 0, 0);
            i++;
        }
    }
}
