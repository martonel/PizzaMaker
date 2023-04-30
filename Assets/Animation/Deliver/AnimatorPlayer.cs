using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{

    public Animator animator;

    // Update is called once per frame
    public void PlayAnimation(string name)
    {
        if(name != ""){
            animator.Play(name);
            name = "";
        }
    }
}
