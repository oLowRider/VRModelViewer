using UnityEngine;
using System.Collections;

public class MuteSound : MonoBehaviour {
    
    bool MuteAllSound;
    public GameObject SteamVRAudio;
    public GameObject OculusAudio;

    AudioListener SteamAU;
    AudioListener OculusAU;

    void Start()
    {
        SteamAU = SteamVRAudio.GetComponent<AudioListener>();
        OculusAU = SteamVRAudio.GetComponent<AudioListener>();
    }
	
	void Update ()
    {
        if(MuteAllSound)
        {
            SteamAU.enabled = false;
            OculusAU.enabled = false;
        }
        else
        {
            SteamAU.enabled = true;
            OculusAU.enabled = true;
        }
	}

    public void isTicked()
    {
        MuteAllSound = !MuteAllSound;
    }
}
