using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Animator animator;

    public void Shake()
    {
        animator.SetTrigger("Shake");
    }
}
