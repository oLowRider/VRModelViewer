using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class ExternalImportModelController : MonoBehaviour {

    public GameObject currentImportedModel;
    public ImportedModelController imc;

    public float addYPosAmount = 0.1f;
    public float minusYPosAmount = 0.1f;

    public float addRotAmount = 5f;
    public float minusRotAmount = 5f;

    public Dropdown NeckDropdown;
    public Dropdown HeadDropdown;
    public GameObject HeadLookUI;

    public Dropdown LEyeDropdown;
    public Dropdown REyeDropdown;
    public InputField OffsetX;
    public InputField OffsetY;
    public InputField OffsetZ;
    public GameObject EyeUI;

    public GameObject SearchForAnimsButton;
    public Text currentAnimationName;
    public GameObject[] AnimationControlsUI;

    HeadLookController hlc;

    bool headLookAdded = false;
    bool eyeLookAdded = false;
    bool hasAnimation = false;
    int selectedInDropdown = 0;

    BendingSegment headAndNeckSegment = new BendingSegment();

    Transform[] modelChildrenBones;
    Dropdown.OptionDataList boneList;

    Animation animationComponent;
    List<AnimationState> modelAnimations;
    int currentAnimation = 0;

    void Start ()
    {
        HeadLookUI.SetActive(false);
        EyeUI.SetActive(false);
        SearchForAnimsButton.SetActive(true);

        foreach(GameObject obj in AnimationControlsUI)
        {
            obj.SetActive(false);
        }
    }

    void FixedUpdate ()
    {
        if (currentImportedModel == null)
        {
            return;
        }

        if(headLookAdded)
        {
            var selectedNeckBone = modelChildrenBones[NeckDropdown.value];
            headAndNeckSegment.firstTransform = selectedNeckBone;

            var selectedHeadBone = modelChildrenBones[HeadDropdown.value];            
            headAndNeckSegment.lastTransform = selectedHeadBone;

            hlc.segments[0] = headAndNeckSegment;
        }

        //if(eyeLookAdded)
        //{
        //    var selectedLEye = modelChildrenBones[LEyeDropdown.value];
        //    elc.lefteye = selectedLEye.transform;

        //    var selectedREye = modelChildrenBones[REyeDropdown.value];
        //    elc.righteye = selectedREye.transform;

        //    //Test for unwanted characters.
        //    var errorCountX = Regex.Matches(OffsetX.text, @"[a-zA-Z]").Count;
        //    var errorCountY = Regex.Matches(OffsetY.text, @"[a-zA-Z]").Count;
        //    var errorCountZ = Regex.Matches(OffsetZ.text, @"[a-zA-Z]").Count;
        //    if (errorCountX > 0 || errorCountY > 0 || errorCountZ > 0 || OffsetX.text == "" || OffsetY.text == "" || OffsetZ.text == "")
        //    {
        //        Debug.Log("Not accepting input value from Eye Rotation Offset");
        //        return;
        //    }

        //    float offsetXf = float.Parse(OffsetX.text);
        //    float offsetYf = float.Parse(OffsetY.text);
        //    float offsetZf = float.Parse(OffsetZ.text);
        //    var offsetCoordinates = new Vector3(offsetXf, offsetYf, offsetZf);
        //    elc.eyeLookOffset = offsetCoordinates;
        //}
	}
    /************** HEAD LOOK **************/
    public void AddHeadLook()
    {
        //Dont add multiple scripts
        if(currentImportedModel.GetComponent<HeadLookController>())
        {
            return;
        }

        HeadLookController hlc = currentImportedModel.AddComponent<HeadLookController>();
        headLookAdded = true;
        HeadLookUI.SetActive(true);

        hlc.target = GameObject.Find("Camera (eye)").transform.position; //Set target for HLC
        hlc.overrideAnimation = true;
        hlc.rootNode = currentImportedModel.transform;
        //Set values for Neck and Head segment
        headAndNeckSegment.thresholdAngleDifference = 0;
        headAndNeckSegment.bendingMultiplier = 0.7f;
        headAndNeckSegment.maxAngleDifference = 30;
        headAndNeckSegment.maxBendingAngle = 80;
        headAndNeckSegment.responsiveness = 4;

        //Scan imported model for all bones and list them for the UI
        modelChildrenBones = currentImportedModel.GetComponentsInChildren<Transform>();

        AddBonesToDropdown(NeckDropdown);
        AddBonesToDropdown(HeadDropdown);
    }

    public void RemoveHeadLook()
    {
        Destroy(hlc);
        headLookAdded = false;
        HeadLookUI.SetActive(false);
    }

    /************** EYE LOOK **************/
    public void AddEyeLook()
    {
        //Dont add multiple scripts
        if (currentImportedModel.GetComponent<HeadLookController>())
        {
            return;
        }

        //elc = currentImportedModel.AddComponent<>();
        //eyeLookAdded = true;
        //EyeUI.SetActive(true);

        ////Set Eye Look targeting to be enabled.
        //elc.targetEnabled = true; 
        ////AutoTarget
        //elc.autoTarget = true;
        //elc.autoTargetTag = "MainCamera";
        ////Or the standrad way
        //elc.viewTarget = GameObject.Find("Camera (eye)").transform;
        ////Make eyes look at target
        //elc.targetWeight = 1;        
        //elc.blinkingEnabled = false;
        //elc.randomLookingEnabled = false;

        //Scan imported model for all bones and list them for the UI
        modelChildrenBones = currentImportedModel.GetComponentsInChildren<Transform>();

        AddBonesToDropdown(LEyeDropdown);
        AddBonesToDropdown(REyeDropdown);
    }

    void AddBonesToDropdown(Dropdown dropdown)
    {
        foreach (Transform child in modelChildrenBones)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = child.ToString() });
        }
    }

    public void RemoveEyeLook()
    {
        //Destroy(elc);
        eyeLookAdded = false;
        EyeUI.SetActive(false);
    }

    public void ImportRotAdd()
    {
        imc.ImportRotSlider.value = imc.ImportRotSlider.value + addRotAmount;
    }
    public void ImportRotMinus()
    {
        imc.ImportRotSlider.value = imc.ImportRotSlider.value - minusRotAmount;
    }
    public void ImportYPosAdd()
    {
        imc.ImportYPosSlider.value = imc.ImportYPosSlider.value + addYPosAmount;
    }
    public void ImportYPosMinus()
    {
        imc.ImportYPosSlider.value = imc.ImportYPosSlider.value - minusYPosAmount;
    }

    public void SearchForAnimations()
    {
        SearchForAnimsButton.SetActive(false);
        animationComponent = currentImportedModel.GetComponentInParent<Animation>();

        modelAnimations = new List<AnimationState>();

        foreach (GameObject obj in AnimationControlsUI)
        {
            obj.SetActive(true);
        }

        foreach (AnimationState states in animationComponent)
        {
            modelAnimations.Add(states);
        }

        currentAnimationName.text = modelAnimations[currentAnimation].name;
    }

    public void NextAnimation()
    {
        if(currentAnimation == modelAnimations.Capacity)
        {
            return;
        }
        Debug.Log("Next Animation clicked");

        currentAnimation++;
        animationComponent.CrossFade(modelAnimations[currentAnimation].name, 0f);
        currentAnimationName.text = modelAnimations[currentAnimation].name;
    }

    public void PreviousAnimation()
    {
        if(currentAnimation == 0)
        {
            return;
        }
        Debug.Log("Previous Animation clicked");

        currentAnimation--;
        animationComponent.CrossFade(modelAnimations[currentAnimation].name, 0f);
        currentAnimationName.text = modelAnimations[currentAnimation].name;
    }

    public void OnClosing()
    {
        foreach (GameObject obj in AnimationControlsUI)
        {
            obj.SetActive(false);
        }
    }

}
