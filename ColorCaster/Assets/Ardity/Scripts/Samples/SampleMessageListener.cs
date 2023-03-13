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

    //List<string> colorSequence;
    string[] colorSeqArr = {"", "", ""};
    
    //[SerializeField] Enemies enemyScript;
    GameObject[] enemies;
    bool canAdd = true;

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
        //print(red + " " + green + " " + blue);

        
        //the 50 would be the threshold
        if(red > green + 35 && red > blue + 35 && canAdd){
            //Instantiate(projectile, transform.position, Quaternion.identity);
            //red has been seen
            
            ScoringRef.resetMulti();
            /*
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject enemy in enemies){
                enemy.GetComponent<Enemies>().TriggerColorAction("red");
                
            }
            */
            for(int i = 0; i < colorSeqArr.Length && canAdd; i++){
                if(colorSeqArr[i] == ""){
                    colorSeqArr[i] = "r";
                    //have to use a delay approach because the base color won't always be the same
                    StartCoroutine(colorPickDelay());
                    break;
                }
            }
            //enemyScript.TriggerColorAction("red");
        }
        else if(green > red + 35 && green > blue + 35 && canAdd){
            //green has been seen
            
            ScoringRef.resetMulti();
            /*
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject enemy in enemies){
                enemy.GetComponent<Enemies>().TriggerColorAction("green");
                
            }
            */
            for(int i = 0; i < colorSeqArr.Length && canAdd; i++){
                if(colorSeqArr[i] == ""){
                    colorSeqArr[i] = "g";
                    StartCoroutine(colorPickDelay());
                    break;
                }
            }
            //enemyScript.TriggerColorAction("green");
        }
        else if(blue > red + 35 && blue > green + 35 && canAdd){
            //blue has been seen
            
            ScoringRef.resetMulti();
            /*
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject enemy in enemies){
                enemy.GetComponent<Enemies>().TriggerColorAction("blue");
                
            }
            */
            for(int i = 0; i < colorSeqArr.Length && canAdd; i++){
                if(colorSeqArr[i] == ""){
                    colorSeqArr[i] = "b";
                    StartCoroutine(colorPickDelay());
                    break;
                }
            }
            //enemyScript.TriggerColorAction("blue");
        }
        //print(colorSequence.Count);
        
        if(colorSeqArr[2] != ""){
            
            print("FIRST:" + colorSeqArr[0] + " SECOND: " + colorSeqArr[1] + " THIRD: " + colorSeqArr[2]);
            if(colorSeqArr[0] == "r" && colorSeqArr[1] == "r" && colorSeqArr[2] == "r"){
                //cast fireball
                //  aoe, low damage, damage overtime, medium speed
            }
            if(colorSeqArr[0] == "g" && colorSeqArr[1] == "g" && colorSeqArr[2] == "g"){
                //cast vine pierce
                // slow, piercing, medium damage straight line
            }
            if(colorSeqArr[0] == "b" && colorSeqArr[1] == "b" && colorSeqArr[2] == "b"){
                //cast ice spear
                //  fast, high damage, single target
            }
            if(colorSeqArr[0] == "r" && colorSeqArr[1] == "g" && colorSeqArr[2] == "g"){
                //cast poison cloud
                //  aoe, damage overtime in an area, low damage, slow
            }
            if(colorSeqArr[0] == "r" && colorSeqArr[1] == "b" && colorSeqArr[2] == "b"){
                //cast lightning bolt
                //  fast, chains, low damage
            }
            if(colorSeqArr[0] == "g" && colorSeqArr[1] == "b" && colorSeqArr[2] == "b"){
                //cast snowball
                //  piercing, high damage, slow (rolls)
            }
            if(colorSeqArr[0] == "r" && colorSeqArr[1] == "g" && colorSeqArr[2] == "b"){
                //cast rainbow blast
                //  damage overtime, piercing, fast
            }
            // rrr, ggg, bbb, rgg, rbb, gbb, rgb

            //for now to test, this will work
            //GameObject tempProj = Instantiate(projs[0], launcher.transform.position, Quaternion.identity);
            //Destroy(tempProj, 5f);
            for(int i = 0; i < colorSeqArr.Length; i++){
                colorSeqArr[i] = "";
            }
            
        }
        
        player.GetComponent<SpriteRenderer>().color = new Color((float)red/255, (float)green/255, (float)blue/255);
        //print(player.GetComponent<SpriteRenderer>().color.r);
        //square.GetComponent<SpriteRenderer>().color = new Color(180,0,180);
    }
    IEnumerator colorPickDelay(){
        canAdd = false;
        yield return new WaitForSeconds(1f);
        canAdd = true;
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
