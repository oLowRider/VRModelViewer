using UnityEngine;
using System.Collections;

public class WidowmakerController : MonoBehaviour {

    public SkinnedMeshRenderer WidowmakerBlendShapes;
    public Animator WidowmakerAnimator;

    public AudioClip[] StartClips, RandomClips, EndClips;
    public AudioSource WidowmakerAudioSource;

    //Count for Audio
    float counter = 0f;

    void Start ()
    {
        //Physics.IgnoreLayerCollision(8, 9);
    }	

    void FixedUpdate()
    {
        int randomClips = Random.Range(0, RandomClips.Length);
        if (!WidowmakerAudioSource.isPlaying)
        {
            counter = counter + 1;
            if (counter > 5400)
            {
                WidowmakerAudioSource.PlayOneShot(RandomClips[randomClips]);
                counter = 0;
            }
        }
    }

    public void OnActivate()
    {
        if (WidowmakerAudioSource.isPlaying) return;

        int randomStart = Random.Range(0, StartClips.Length);
        WidowmakerAudioSource.PlayOneShot(StartClips[randomStart]);
    }

    public void OnDeactivate()
    {
        if (WidowmakerAudioSource.isPlaying) return;

        int randomEnd = Random.Range(0, EndClips.Length);
        WidowmakerAudioSource.PlayOneShot(EndClips[randomEnd]);
    }

    public void WidowChangeToPose1(bool value)
    {
        if (value)
        {
            WidowmakerAnimator.SetBool("Widowpose1isTicked", true);
            WidowmakerAnimator.SetBool("Widowpose2isTicked", false);
            WidowmakerAnimator.SetBool("Widowpose3isTicked", false);

            this.transform.position = new Vector3(0f, 0f, 0f);
        }
    }
    public void WidowChangeToPose2(bool value)
    {
        if (value)
        {
            WidowmakerAnimator.SetBool("Widowpose1isTicked", false);
            WidowmakerAnimator.SetBool("Widowpose2isTicked", true);
            WidowmakerAnimator.SetBool("Widowpose3isTicked", false);

            this.transform.position = new Vector3(0f, -0.5f, 0f);

        }
    }
    public void WidowChangeToPose3(bool value)
    {
        if (value)
        {
            WidowmakerAnimator.SetBool("Widowpose1isTicked", false);
            WidowmakerAnimator.SetBool("Widowpose2isTicked", false);
            WidowmakerAnimator.SetBool("Widowpose3isTicked", true);

            this.transform.position = new Vector3(0f, 0f, 0f);
        }
    }

    void BlendshapeSmile()
    {

    }
}
