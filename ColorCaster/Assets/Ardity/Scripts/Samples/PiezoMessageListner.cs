using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezoMessageListner : MonoBehaviour
{
    [SerializeField] private ForceField forceField_ref;


    void OnMessageArrived(string msg)
    {
        //print(msg.ToString().Length);
        if((msg.ToString().Length == 2 || msg.ToString().Length == 3) && forceField_ref.forceFieldTimer == 0)
        {
          forceField_ref.isForceField = true;

        }
        //else
        //{
        //    forceField_ref.isForceField = false;
        //}
    }

    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
