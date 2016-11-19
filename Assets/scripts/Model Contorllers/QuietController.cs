using UnityEngine;
using System.Collections;

public class QuietController : MonoBehaviour {

    public GameObject Boots;
    [SerializeField]
    bool bootsEnabled;

    public GameObject Bra;
    [SerializeField]
    bool braEnabled;

    public GameObject Equipment;
    [SerializeField]
    bool equipmentEnabled;

    public GameObject Gloves;
    [SerializeField]
    bool glovesEnabled;

    public GameObject Thong;
    [SerializeField]
    bool thongEnabled;

    public Animator QuietAnimator;

    public AudioClip[] StartClips, RandomClips, EndClips;
    public AudioSource QuietAudioSource;

    void Start ()
    {
        Boots.SetActive(bootsEnabled);
        Bra.SetActive(braEnabled);
        Equipment.SetActive(equipmentEnabled);
        Gloves.SetActive(glovesEnabled);
        Thong.SetActive(thongEnabled);
	}

    void Update()
    {
        int randomClips = Random.Range(0, RandomClips.Length);
        if (!QuietAudioSource.isPlaying && Time.time >= 90)
        {
            QuietAudioSource.PlayOneShot(RandomClips[randomClips]);
        }
    }

    public void QuietChangeToPose1(bool value)
    {
        if (value)
        {
            QuietAnimator.SetBool("Qpose1isTicked", true);
            QuietAnimator.SetBool("Qpose2isTicked", false);
            QuietAnimator.SetBool("Qpose3isTicked", false);
        }
    }

    public void QuietChangeToPose2(bool value)
    {
        if (value)
        {
            QuietAnimator.SetBool("Qpose1isTicked", false);
            QuietAnimator.SetBool("Qpose2isTicked", true);
            QuietAnimator.SetBool("Qpose3isTicked", false);
        }
    }

    public void QuietChangeToPose3(bool value)
    {
        if (value)
        {
            QuietAnimator.SetBool("Qpose1isTicked", false);
            QuietAnimator.SetBool("Qpose2isTicked", false);
            QuietAnimator.SetBool("Qpose3isTicked", true);
        }
    }

    /*Toggle controls for UI*/
    public void BootsControls(bool value)
    {
        if (value)
        {
            bootsEnabled = true;
            Boots.SetActive(true);
        }
        else
        {
            bootsEnabled = false;
            Boots.SetActive(false);
        }
    }
    public void BraControls(bool value)
    {
        if (value)
        {
            braEnabled = true;
            Bra.SetActive(true);
        }
        else
        {
            braEnabled = false;
            Bra.SetActive(false);
        }
    }
    public void EquipmentControls(bool value)
    {
        if (value)
        {
            equipmentEnabled = true;
            Equipment.SetActive(true);
        }
        else
        {
            equipmentEnabled = false;
            Equipment.SetActive(false);
        }
    }
    public void GlovesControls(bool value)
    {
        if (value)
        {
            glovesEnabled = true;
            Gloves.SetActive(true);
        }
        else
        {
            glovesEnabled = false;
            Gloves.SetActive(false);
        }
    }
    public void ThongControls(bool value)
    {
        if (value)
        {
            thongEnabled = true;
            Thong.SetActive(true);
        }
        else
        {
            thongEnabled = false;
            Thong.SetActive(false);
        }
    }

    public void OnActivate()
    {
        if (QuietAudioSource.isPlaying) return;

        int randomStart = Random.Range(0, StartClips.Length);
        QuietAudioSource.PlayOneShot(StartClips[randomStart]);
    }

    public void OnDeactivate()
    {
        if (QuietAudioSource.isPlaying) return;

        int randomEnd = Random.Range(0, EndClips.Length);
        QuietAudioSource.PlayOneShot(EndClips[randomEnd]);
    }
}
