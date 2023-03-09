/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class SampleMessageListener : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject launcher;
    [SerializeField] GameObject[] projs;
    public ScoringSystem ScoringRef;

    List<string> colorSequence;
    
    //[SerializeField] Enemies enemyScript;
    GameObject[] enemies;

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

        //the 50 would be the threshold
        if(red > green + 35 && red > blue + 35){
            //Instantiate(projectile, transform.position, Quaternion.identity);
            //red has been seen
            ScoringRef.resetMulti();
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject enemy in enemies){
                enemy.GetComponent<Enemies>().TriggerColorAction("red");
                colorSequence.Add("r");
            }
            
            //enemyScript.TriggerColorAction("red");
        }
        else if(green > red + 35 && green > blue + 35){
            //green has been seen
            ScoringRef.resetMulti();
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject enemy in enemies){
                enemy.GetComponent<Enemies>().TriggerColorAction("green");
                colorSequence.Add("g");
            }
            
            //enemyScript.TriggerColorAction("green");
        }
        else if(blue > red + 35 && blue > green + 35){
            //blue has been seen
            ScoringRef.resetMulti();
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject enemy in enemies){
                enemy.GetComponent<Enemies>().TriggerColorAction("blue");
                colorSequence.Add("b");
            }
            
            //enemyScript.TriggerColorAction("blue");
        }
        if(colorSequence.Count >= 3){
            if(colorSequence[0] == "r" && colorSequence[1] == "r" && colorSequence[2] == "r"){
                //cast fireball
                //  aoe, low damage, damage overtime, medium speed
            }
            if(colorSequence[0] == "g" && colorSequence[1] == "g" && colorSequence[2] == "g"){
                //cast vine pierce
                // slow, piercing, medium damage straight line
            }
            if(colorSequence[0] == "b" && colorSequence[1] == "b" && colorSequence[2] == "b"){
                //cast ice spear
                //  fast, high damage, single target
            }
            if(colorSequence[0] == "r" && colorSequence[1] == "g" && colorSequence[2] == "g"){
                //cast poison cloud
                //  aoe, damage overtime in an area, low damage, slow
            }
            if(colorSequence[0] == "r" && colorSequence[1] == "b" && colorSequence[2] == "b"){
                //cast lightning bolt
                //  fast, chains, low damage
            }
            if(colorSequence[0] == "g" && colorSequence[1] == "b" && colorSequence[2] == "b"){
                //cast snowball
                //  piercing, high damage, slow (rolls)
            }
            if(colorSequence[0] == "r" && colorSequence[1] == "g" && colorSequence[2] == "b"){
                //cast rainbow blast
                //  damage overtime, piercing, fast
            }
            // rrr, ggg, bbb, rgg, rbb, gbb, rgb

            //for now to test, this will work
            GameObject tempProj = Instantiate(projs[0], launcher.transform.position, Quaternion.identity);
            Destroy(tempProj, 5f);
            colorSequence.Clear();
        }

        player.GetComponent<SpriteRenderer>().color = new Color((float)red/255, (float)green/255, (float)blue/255);
        print(player.GetComponent<SpriteRenderer>().color.r);
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
