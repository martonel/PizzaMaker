using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedOrders : MonoBehaviour
{

    public List<string> orders; 
    public Animator levelEndAnim;
    public Animator anim;
    public GameObject childObj;
    private int counter = 1;
    public int orderCounter = 1;
    public Animator deliveryAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (childObj.transform.childCount == 1 && orders.Count !=0)
        {   
            if(childObj.transform.GetChild(0).gameObject.tag == orders[0]){
                anim.Play("UpperPanelAnim"+ counter);
                deliveryAnim.SetBool("deliver",true);
                counter ++;
                orders.RemoveAt(0);
                StartCoroutine(WaitTime());
            }
            if(orderCounter +1 == counter){
                levelEndAnim.Play("LevelWinAnim");
                deliveryAnim.SetBool("isGameEnd",true);
            }
        }
    }


    
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.3f);
        Destroy(childObj.transform.GetChild(0).gameObject);
    }

}
