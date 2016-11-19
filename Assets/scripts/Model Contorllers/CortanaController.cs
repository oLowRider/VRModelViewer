using UnityEngine;
using System.Collections;

public class CortanaController : MonoBehaviour {

    public Animator CortanaAnimator;

	void Start ()
    {
	
	}

    public void CortanaChangeToPose1(bool value)
    {
        if (value)
        {
            CortanaAnimator.SetBool("Cortanapose1isTicked", true);
            CortanaAnimator.SetBool("Cortanapose2isTicked", false);
            CortanaAnimator.SetBool("Cortanapose3isTicked", false);
        }
    }

    public void CortanaChangeToPose2(bool value)
    {
        if (value)
        {
            CortanaAnimator.SetBool("Cortanapose1isTicked", false);
            CortanaAnimator.SetBool("Cortanapose2isTicked", true);
            CortanaAnimator.SetBool("Cortanapose3isTicked", false);
        }
    }

    public void CortanaChangeToPose3(bool value)
    {
        if (value)
        {
            CortanaAnimator.SetBool("Cortanapose1isTicked", false);
            CortanaAnimator.SetBool("Cortanapose2isTicked", false);
            CortanaAnimator.SetBool("Cortanapose3isTicked", true);
        }
    }
}
