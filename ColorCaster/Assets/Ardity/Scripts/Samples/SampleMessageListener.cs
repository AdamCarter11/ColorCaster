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
    //public ScoringSystem ScoringRef;

    //List<string> colorSequence;
    string[] colorSeqArr = {"", "", ""};
    
    //[SerializeField] Enemies enemyScript;
    GameObject[] enemies;
    bool canAdd = true;
    int reds, greens, blues;

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
        if(red > green + 65 && red > blue + 65 && canAdd){
            //Instantiate(projectile, transform.position, Quaternion.identity);
            //red has been seen
            
            //ScoringRef.resetMulti();
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
        else if(green > red + 30 && green > blue + 30 && canAdd){
            //green has been seen
            
            //ScoringRef.resetMulti();
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
        else if(blue > red + 30 && blue > green + 30 && canAdd){
            //blue has been seen
            
            //ScoringRef.resetMulti();
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
            foreach(string colorString in colorSeqArr){
                if(colorString == "r"){
                    reds++;
                }
                if(colorString == "g"){
                    greens++;
                }
                if(colorString == "b"){
                    blues++;
                }
            }
            if(reds >= 3){
                //  rrr
                GameObject spawnProj = Instantiate(projs[0], launcher.transform.position, launcher.transform.rotation);
            }
            if(greens >= 3){
                //  ggg
                GameObject spawnProj = Instantiate(projs[1], launcher.transform.position, launcher.transform.rotation);
            }
            if(blues >= 3){
                //  bbb
                GameObject spawnProj = Instantiate(projs[2], launcher.transform.position, launcher.transform.rotation);
            }
            if(blues == 2 && greens == 1){
                //  bbg
                GameObject spawnProj = Instantiate(projs[3], launcher.transform.position, launcher.transform.rotation);
            }
            if(greens == 2 && blues == 1){
                //  ggb
                GameObject spawnProj = Instantiate(projs[4], launcher.transform.position, launcher.transform.rotation);
            }
            if(reds == 2 && greens == 1){
                //  rrg
                GameObject spawnProj = Instantiate(projs[5], launcher.transform.position, launcher.transform.rotation);
            }
            if(blues == 2 && reds == 1){
                //  bbr
                GameObject spawnProj = Instantiate(projs[6], launcher.transform.position, launcher.transform.rotation);
            }
            if(greens == 2 && reds == 1){
                //  ggr
                GameObject spawnProj = Instantiate(projs[7], launcher.transform.position, launcher.transform.rotation);
            }
            if(reds == 2 && blues == 1){
                //  rrb
                GameObject spawnProj = Instantiate(projs[8], launcher.transform.position, launcher.transform.rotation);
            }
            if(reds == 1 && greens == 1 && blues == 1){
                //  rgb
                GameObject spawnProj = Instantiate(projs[9], launcher.transform.position, launcher.transform.rotation);
            }

            //for now to test, this will work
            //GameObject tempProj = Instantiate(projs[0], launcher.transform.position, Quaternion.identity);
            //Destroy(tempProj, 5f);
            for(int i = 0; i < colorSeqArr.Length; i++){
                colorSeqArr[i] = "";
            }
            reds = 0;
            greens = 0;
            blues = 0;
            
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
