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

    // Read Inputs
    public float GetXMovementAxis() { return Input.GetAxis("Horizontal"); }
    public float GetYMovementAxis() { return Input.GetAxis("Vertical"); }
    public float GetXRotationAxis() { return Input.GetAxis("Mouse X"); }
    public float GetYRotationAxis() { return Input.GetAxis("Mouse Y"); }

    // Running key bindings
    public bool Running() { return (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));  }

    // Jumping key bindings
    public bool Jumping() { return Input.GetKeyDown(KeyCode.Space);  }

    // Dashing key bindings
    public bool Dashing() { return Input.GetKeyDown(KeyCode.Tab);  }

    // Restart Key bindings
    public bool RestartKey() {return Input.GetKeyDown(KeyCode.R); }

    // Reset Player to last Respawn point (for debugging)
    public bool ResetKey() { return Input.GetKeyDown(KeyCode.Return); }

    // Reset Player to last Respawn point (for debugging)
    public bool GibKey() { return Input.GetKeyDown(KeyCode.K); }
}
