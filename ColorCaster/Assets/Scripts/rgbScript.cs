using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rgbScript : MonoBehaviour
{
    private void Start() {
        StartCoroutine(colorChanging());
    }
    IEnumerator colorChanging(){
        while(true){
            this.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
            yield return new WaitForSeconds(.1f);
        }
    }
}
