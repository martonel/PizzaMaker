using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropp : MonoBehaviour
{
    private GameObject grabbedObject;
    private GameObject releaseObject;
    private bool isInGrabPoint ;
    private bool isInReleasePoint ;
    private bool isGrabbed;

    public MixObjects mixObjects;

    private string nextName;

    public Animator cookAnim;


    public Transform grabPoint;
    void Start(){
        isInGrabPoint = false;
        isInReleasePoint = false;
        isGrabbed = false;
        nextName = "";

    }

     void Update()
    {
        if(isInGrabPoint &&  (Input.GetButtonDown("Fire1") ||Input.GetKeyDown(KeyCode.Space)) && !isGrabbed && grabbedObject!=null)
        {
            Debug.Log("isGrabbed");
            isGrabbed = true;
            grabbedObject.transform.SetParent(transform,true);
            grabbedObject.transform.position = grabPoint.position;
            cookAnim.Play("GrabFood");
            
        }
        else if(isInReleasePoint == true && (Input.GetButtonDown("Fire1") ||Input.GetKeyDown(KeyCode.Space))){
            if(releaseObject!=null && releaseObject.transform.childCount > 0){
                if(isGrabbed && grabbedObject!=null && releaseObject.transform.GetChild(0).gameObject.tag == grabbedObject.gameObject.tag){
                    //Debug.Log("return");
                    return;
                }
                else if(!isGrabbed && releaseObject.transform.GetChild(0).childCount != 0){
                    //nincs nálunk semmi, és van valami az asztalon.
                    grabbedObject = releaseObject.transform.GetChild(0).gameObject;
                    grabbedObject.transform.SetParent(transform,true);
                    grabbedObject.transform.position = grabPoint.position;
                    isGrabbed = true;
                    cookAnim.Play("GrabFood");
                }
                else{
                    //van nálunk valami, és az asztalon is van egy olyan ami különbözik a miénktõl
                    nextName = mixObjects.checkDroppedObject(grabbedObject,releaseObject.transform.GetChild(0).gameObject);
                    Debug.Log("nextName: " + nextName);
                    if(nextName!=""){
                        grabbedObject.transform.SetParent(releaseObject.transform,true);
                        grabbedObject.transform.position = releaseObject.transform.position;
                        
                        isGrabbed = false;
                        cookAnim.Play("Optional");
                    }
                }
            }else if(grabbedObject!=null){
                Debug.Log("isReleased " + releaseObject);
                grabbedObject.transform.SetParent(releaseObject.transform,true);
                grabbedObject.transform.position = releaseObject.transform.position;

                isGrabbed = false;
                cookAnim.Play("Optional");
            }

        }
    }

    private void OnTriggerEnter(Collider other){
      if (other.CompareTag("Fruit") && !isGrabbed){
        isInGrabPoint = true;
        if(other.gameObject.transform.childCount > 0 && grabbedObject == null){
            grabbedObject = other.gameObject.transform.GetChild(0).gameObject;
        }
      }

      if (other.CompareTag("PlatingPoint")){
        isInReleasePoint = true;
        isInGrabPoint = true;
        releaseObject = other.transform.GetChild(0).gameObject;
        if(releaseObject.transform.childCount > 0 && grabbedObject == null){
            grabbedObject = releaseObject.transform.GetChild(0).gameObject;
        }
      }  
    }

    private void OnTriggerExit(Collider other){
      if (other.CompareTag("Fruit")){
        if(!isGrabbed){
            grabbedObject = null;
        }
        isInGrabPoint = false;
      }
      if (other.CompareTag("PlatingPoint")){
        isInReleasePoint = false;
        isInGrabPoint = false;
        if(!isGrabbed){
            grabbedObject = null;
        }
        releaseObject = null;
      }  
    }

    public void setGrabbedObject(GameObject obj){
        grabbedObject = obj;
        isGrabbed = false;
    }

    public string getNextName(){
        return nextName;
    }
    public void setNextNameToNull(){
        nextName = "";
    }

    public bool GetGrabbed(){
        return grabbedObject !=null;
    }
}




