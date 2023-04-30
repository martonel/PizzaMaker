using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTwoObjectToOne : MonoBehaviour
{
    public Transform replacementTransform;

    public List<GameObject> replacementObjectList;




    void Update()
    {
        if (transform.GetChild(0).transform.childCount == 2)
        {   
            Debug.Log("Destroy");
            Destroy(transform.GetChild(0).GetChild(0).gameObject);
            Destroy(transform.GetChild(0).GetChild(1).gameObject);

            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0].gameObject;
            string nextName = player.GetComponent<DragAndDropp>().getNextName();
            player.GetComponent<DragAndDropp>().setNextNameToNull();
            Debug.Log("next value name: " + nextName);

            foreach(GameObject replacementObj in replacementObjectList){
                if(replacementObj.transform.tag == nextName){
                    GameObject newObject = Instantiate(replacementObj, transform.position, Quaternion.identity);
                    Debug.Log(newObject);
                    newObject.transform.SetParent(transform.GetChild(0));
                    player.GetComponent<DragAndDropp>().setGrabbedObject(newObject);
                    if (replacementTransform != null)
                    {
                        newObject.transform.position = replacementTransform.position;
                    }    
                }
            }
            
        }
    }
}