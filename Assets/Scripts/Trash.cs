using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
   private Transform childObject;

    private void Update()
    {
        if (transform.childCount > 0)
        {
            childObject = transform.GetChild(0);

            // Move child object down the z-axis
            childObject.transform.position -= new Vector3(0f, 0f, 0.001f);

            // Scale down child object over time
            float scaleFactor = 0.95f;
            childObject.transform.localScale *= scaleFactor;

            // Destroy child object after half second
            float destroyDelay = 0.5f;
            Destroy(childObject.gameObject, destroyDelay);
        }
    }
}