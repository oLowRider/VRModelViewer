using UnityEngine;
using System.Collections;

public class BreathControl : MonoBehaviour {

    public AudioSource BreathingSource;

    bool canPlayAudio = false;
	
	void FixedUpdate ()
    {
	    if(canPlayAudio && !BreathingSource.isPlaying)
        {
            BreathingSource.Play();
        }

        if (!canPlayAudio)
        {
            BreathingSource.Stop();
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Breathing Trigger")
            canPlayAudio = true;
        else
            canPlayAudio = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Breathing Trigger")
            canPlayAudio = false;
    }
}
