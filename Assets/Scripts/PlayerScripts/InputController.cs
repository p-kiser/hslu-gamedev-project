using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public float GetXMovementAxis()
    {
        return Input.GetAxis("Horizontal");
    }

    public float GetYMovementAxis()
    {
        return Input.GetAxis("Vertical");
    }

    public float GetXRotationAxis()
    {
        return Input.GetAxis("Mouse X");
    }

    public float GetYRotationAxis()
    {
        return Input.GetAxis("Mouse Y");
    }

    // Running key bindings
    public bool Running()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            return true;
        } else {
            return false;
        }
        
    }

    // Jumping key bindings
    public bool Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            return true;
        } else
        {
            return false;
        }
    }

    // Dashing key bindings
    public bool Dashing()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            return true;
        } else
        {
            return false;
        }
    }

    public bool RestartKey()
    {
        //if (Input.GetKeyDown(KeyCode.R) && PlayerStatus.instance.AllKeysCollected())
        if (Input.GetKeyDown(KeyCode.R))
        {
            return true;
        } else
        {
            return false;
        }
    }

    public bool ResetKey()
    {
        return Input.GetKeyDown(KeyCode.Return);
    }

}
