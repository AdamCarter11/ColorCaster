/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;

/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class SampleMessageListener : MonoBehaviour
{

    [SerializeField] GameObject square;

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        string[] splitRGBVals = msg.Split(",");
        //print(splitRGBVals[0]);
        //Debug.Log("Message HEHE: " + msg);
        //print(splitRGBVals[0] + " " + splitRGBVals[1] + " " + splitRGBVals[2]);
        int red = int.Parse(splitRGBVals[0]);
        int green = int.Parse(splitRGBVals[1]);
        int blue = int.Parse(splitRGBVals[2]);
        print(red + " " + green + " " + blue);
        square.GetComponent<SpriteRenderer>().color = new Color((float)red/255, (float)green/255, (float)blue/255);
        print(square.GetComponent<SpriteRenderer>().color.r);
        //square.GetComponent<SpriteRenderer>().color = new Color(180,0,180);
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
