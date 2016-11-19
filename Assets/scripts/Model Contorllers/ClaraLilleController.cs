using UnityEngine;
using System.Collections;

public class ClaraLilleController : MonoBehaviour {

    public GameObject Belt;
    [SerializeField] bool beltEnabled;

    public GameObject[] Boots;
    [SerializeField]
    bool bootsEnabled;

    public GameObject[] Bracelet;
    [SerializeField]
    bool braceletEnabled;

    public GameObject Jacket;
    [SerializeField]
    public bool jacketEnabled;

    public GameObject Necklace;
    [SerializeField]
    bool necklaceEnabled;

    public GameObject Pants;
    [SerializeField]
    bool pantsEnabled;

    public GameObject[] Rings;
    [SerializeField]
    bool ringsEnabled;

    public GameObject Shirt;
    [SerializeField]
    bool shirtEnabled;

    public Animator CLAnimator;

    void Start ()
    {
        Belt.gameObject.SetActive(beltEnabled);        
        Jacket.gameObject.SetActive(jacketEnabled);
        Necklace.gameObject.SetActive(necklaceEnabled);
        Pants.gameObject.SetActive(pantsEnabled);
        Shirt.gameObject.SetActive(shirtEnabled);

        foreach(GameObject obj in Boots)
        {
            obj.SetActive(bootsEnabled);
        }
        foreach(GameObject go in Bracelet)
        {
            go.SetActive(braceletEnabled);
        }
        foreach(GameObject rings in Rings)
        {
            rings.SetActive(ringsEnabled);
        }
    }
	
	void Update ()
    {

	}

    public void ClaraChangeToPose1(bool value)
    {
        if (value)
        {
            CLAnimator.SetBool("CLpose1isTicked", true);
            CLAnimator.SetBool("CLpose2isTicked", false);
            CLAnimator.SetBool("CLpose3isTicked", false);
        }
    }

    public void ClaraChangeToPose2(bool value)
    {
        if (value)
        {
            CLAnimator.SetBool("CLpose1isTicked", false);
            CLAnimator.SetBool("CLpose2isTicked", true);
            CLAnimator.SetBool("CLpose3isTicked", false);
        }
    }

    public void ClaraChangeToPose3(bool value)
    {
        if (value)
        {
            CLAnimator.SetBool("CLpose1isTicked", false);
            CLAnimator.SetBool("CLpose2isTicked", false);
            CLAnimator.SetBool("CLpose3isTicked", true);
        }
    }

    /*Toggle controls for UI*/
    public void BeltControls(bool value)
    {
        if (value)
        {
            beltEnabled = true;
            Belt.SetActive(true);
        }
        else
        {
            beltEnabled = false;
            Belt.SetActive(false);
        }
    }

    public void BootsControls(bool value)
    {
        if (value)
        {
            bootsEnabled = true;
            foreach (GameObject obj in Boots)
            {
                obj.SetActive(bootsEnabled);
            }
        }
        else
        {
            bootsEnabled = false;
            foreach (GameObject obj in Boots)
            {
                obj.SetActive(bootsEnabled);
            }
        }
    }

    public void BraceletControls(bool value)
    {
        if (value)
        {
            braceletEnabled = true;
            foreach (GameObject obj in Bracelet)
            {
                obj.SetActive(braceletEnabled);
            }
        }
        else
        {
            braceletEnabled = false;
            foreach (GameObject obj in Bracelet)
            {
                obj.SetActive(braceletEnabled);
            }
        }
    }

    public void JacketControls(bool value)
    {
        if (value)
        {
            jacketEnabled = true;
            Jacket.SetActive(true);
        }
        else
        {
            jacketEnabled = false;
            Jacket.SetActive(false);
        }
    }

    public void NecklaceControls(bool value)
    {
        if (value)
        {
            necklaceEnabled = true;
            Necklace.SetActive(true);
        }
        else
        {
            necklaceEnabled = false;
            Necklace.SetActive(false);
        }
    }

    public void PantsControls(bool value)
    {
        if (value)
        {
            pantsEnabled = true;
            Pants.SetActive(true);
        }
        else
        {
            pantsEnabled = false;
            Pants.SetActive(false);
        }
    }

    public void RingsControls(bool value)
    {
        if (value)
        {
            ringsEnabled = true;
            foreach (GameObject obj in Rings)
            {
                obj.SetActive(ringsEnabled);
            }
        }
        else
        {
            ringsEnabled = false;
            foreach (GameObject obj in Rings)
            {
                obj.SetActive(ringsEnabled);
            }
        }
    }

    public void ShirtControls(bool value)
    {
        if (value)
        {
            shirtEnabled = true;
            Shirt.SetActive(true);
        }
        else
        {
            shirtEnabled = false;
            Shirt.SetActive(false);
        }
    }
}
