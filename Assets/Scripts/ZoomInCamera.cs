using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInCamera : MonoBehaviour
{
    private GameObject jen;
    private Animator dialogueAnimator;

    // Start is called before the first frame update
    void Start()
    {
        jen = GameObject.Find("Jen");
        dialogueAnimator = jen.GetComponent<Animator>();
    }

    public void ZoomIn()
    {
        dialogueAnimator.Play("Jen_dialogue");
    }

    public void ZoomOut()
    {
        dialogueAnimator.Play("Jen_idle");
    }
}
