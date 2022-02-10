using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCntrlsAnim : MonoBehaviour
{
    private Animator mator;

    private void Awake()
    {
        mator = gameObject.GetComponent<Animator>();
    }
    public void PlayAnimation()
    {
        mator.SetBool("PlayAnim", true);
    }
}
