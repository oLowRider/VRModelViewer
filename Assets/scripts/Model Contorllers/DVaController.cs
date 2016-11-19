using UnityEngine;
using System.Collections;

public class DVaController : MonoBehaviour {

    public GameObject DVaPistolPose1, DVaMechPose2, DVaMechPose3;

    public SkinnedMeshRenderer DVaBlendShapes;
    public Animator DVaAnimator;

    public AudioClip[] StartClips, RandomClips, EndClips;
    public AudioSource DVaAudioSource;

    public bool pose3isTicked = false;

    //Count for Audio
    float counter = 0;

    void Start ()
    {
        DVaPistolPose1.SetActive(true);
        DVaMechPose2.SetActive(false);
        DVaMechPose3.SetActive(false);
    }

    void FixedUpdate ()
    {
        //int randomClips = Random.Range(0, RandomClips.Length);
        //if (!DVaAudioSource.isPlaying)
        //{
        //    counter = counter + 1;
        //    if (counter > 5400)
        //    {
        //        DVaAudioSource.PlayOneShot(RandomClips[randomClips]);
        //        counter = 0;
        //    }
        //}
    }

    void LateUpdate()
    {
        if (pose3isTicked)
        {
            this.transform.position = new Vector3(0.008f, 1.5f, -0.562f);
        }
        else
        {
            this.transform.position = new Vector3(0f, 0f, 0f);
        }
    }

    public void DVaChangeToPose1(bool value)
    {
        if (value)
        {
            DVaAnimator.SetBool("DVapose1isTicked", true);
            DVaAnimator.SetBool("DVapose2isTicked", false);
            DVaAnimator.SetBool("DVapose3isTicked", false);

            DVaPistolPose1.SetActive(true);
            DVaMechPose2.SetActive(false);
            DVaMechPose3.SetActive(false);

            this.transform.position = new Vector3(0f, 0f, -0f);
            this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            pose3isTicked = false;
        }
    }
    public void DVaChangeToPose2(bool value)
    {
        if (value)
        {
            DVaAnimator.SetBool("DVapose1isTicked", false);
            DVaAnimator.SetBool("DVapose2isTicked", true);
            DVaAnimator.SetBool("DVapose3isTicked", false);

            DVaPistolPose1.SetActive(false);
            DVaMechPose2.SetActive(true);
            DVaMechPose3.SetActive(false);
      
            this.transform.position = new Vector3(0f, 0f, -0f);
            this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            pose3isTicked = false;
        }
    }
    public void DVaChangeToPose3(bool value)
    {
        if (value)
        {
            DVaAnimator.SetBool("DVapose1isTicked", false);
            DVaAnimator.SetBool("DVapose2isTicked", false);
            DVaAnimator.SetBool("DVapose3isTicked", true);

            DVaPistolPose1.SetActive(false);
            DVaMechPose2.SetActive(false);
            DVaMechPose3.SetActive(true);
            
            this.transform.rotation = Quaternion.Euler(0f, 180, 0f);
            pose3isTicked = true;
        }
    }

    public void OnActivate()
    {
        if (DVaAudioSource.isPlaying) return;

        int randomStart = Random.Range(0, StartClips.Length);
        DVaAudioSource.PlayOneShot(StartClips[randomStart]);

        InvokeRepeating("PlayDvaSound", 1, 60f);
    }

    public void OnDeactivate()
    {
        if (DVaAudioSource.isPlaying) return;

        int randomEnd = Random.Range(0, EndClips.Length);
        DVaAudioSource.PlayOneShot(EndClips[randomEnd]);

        CancelInvoke("PlayDvaSound");
    }

    void PlayDvaSound()
    {
        int randomClips = Random.Range(0, RandomClips.Length);
        if (!DVaAudioSource.isPlaying)
        {
            DVaAudioSource.PlayOneShot(RandomClips[randomClips]);
            Debug.Log("Playing DVa sound");
        }
    }
}
