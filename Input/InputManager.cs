using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private InputScript inputScript;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeInput();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeInput()
    {
        inputScript = new InputScript();
        inputScript.Enable();
        //inputScript.Player.Shot.performed += context => Debug.Log("Shot");
    }

    public InputScript GetInputScript()
    {
        return inputScript;
    }
}
