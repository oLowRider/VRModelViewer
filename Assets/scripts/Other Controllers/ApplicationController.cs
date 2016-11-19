using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.VR;
using Valve.VR;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class ApplicationController : MonoBehaviour {

    public string VersionNumber;
    public Text[] VersionUI;

    public GameObject SteamVRObject;
    public FirstPersonController OculusFPC;
    public AudioSource OculusAS;
    public CharacterController OculusCC;
    public OculusRaycast OculusRaycast;
    public GameObject OculusCrosshair;
    bool SteamVRDetected;

    public float ScaleValue = 0.23f;
    public int DefaultRotation = 90;

    public GameObject LowPolyStage, Bedroom, DarkRoom, JapRoom, ParkingLot, BookersOffice;
    public GameObject LowPolyStageProbe, BedroomProbe, DarkRoomProbe, JapRoomProbe, ParkingLotProbe, BookersOfficeProbe;

    /// <summary>
    /// List of all models and their UI
    /// </summary>
    public GameObject ClaraLille;
    public GameObject Quiet;    
    public GameObject Ciri;
    public GameObject Yennefer;
    public GameObject Tracer;
    public GameObject MadMoxxi;
    public GameObject DVa;
    public GameObject Nidalee;
    public GameObject Elizabeth;
    public GameObject Triss;
    public GameObject HarleyQuinn;
    public GameObject JillValentine;
    public GameObject LaraToO;
    public GameObject Jack;
    public GameObject JulietStarling;
    public GameObject Widowmaker;

    public GameObject[] DisableUIScreens;
    public GameObject MainMenuUI;

    public Slider ClaraRotationSlider;
    public Text ClaraRotText;
    public Slider ClaraScaleSlider;
    public Text ClaraScaleText;
    public Slider ClaraYPosSlider;
    public Text ClaraYPosText;

    public Slider QuietRotationSlider;
    public Text QuietRotText;
    public Slider QuietScaleSlider;
    public Text QuietScaleText;
    public Slider QuietYPosSlider;
    public Text QuietYPosText;

    public Slider CiriRotationSlider;
    public Text CiriRotText;
    public Slider CiriScaleSlider;
    public Text CiriScaleText;
    public Slider CiriYPosSlider;
    public Text CiriYPosText;

    public Slider YenneferRotationSlider;
    public Text YenneferRotText;
    public Slider YenneferScaleSlider;
    public Text YenneferScaleText;
    public Slider YenneferYPosSlider;
    public Text YenneferYPosText;

    public Slider TracerRotationSlider;
    public Text TracerRotText;
    public Slider TracerScaleSlider;
    public Text TracerScaleText;
    public Slider TracerYPosSlider;
    public Text TracerYPosText;

    public Slider MoxxiRotationSlider;
    public Text MoxxiRotText;
    public Slider MoxxiScaleSlider;
    public Text MoxxiScaleText;
    public Slider MoxxiYPosSlider;
    public Text MoxxiYPosText;

    public Slider DVaRotSlider;
    public Text DVaRotText;
    public Slider DVaScaleSlider;
    public Text DVaScaleText;
    public Slider DVaYPosSlider;
    public Text DVaYPosText;

    public Slider NidaleeRotSlider;
    public Text NidaleeRotText;
    public Slider NidaleeScaleSlider;
    public Text NidaleeScaleText;
    public Slider NidaleeYPosSlider;
    public Text NidaleeYPosText;

    public Slider ElizabethRotSlider, ElizabethScaleSlider, ElizabethYPosSlider;
    public Text ElizabethRotText, ElizabethScaleText, ElizabethYPosText;

    public Slider TrissRotSlider, TrissScaleSlider, TrissYPosSlider;
    public Text TrissRotText, TrissScaleText, TrissYPosText;

    public Slider HarleyQuinnRotSlider, HarleyQuinnScaleSlider, HarleyQuinnYPosSlider;
    public Text HarleyQuinnRotText, HarleyQuinnScaleText, HarleyQuinnYPosText;

    public Slider JillValentineRotSlider, JillValentineScaleSlider, JillValentineYPosSlider;
    public Text JillValentineRotText, JillValentineScaleText, JillValentineYPosText;

    public Slider LaraToORotSlider, LaraToOScaleSlider, LaraCroftToOYPosSlider;
    public Text LaraToORotText, LaraToOScaleText, LaraCroftToOYPosText;

    public Slider JackRotSlider, JackScaleSlider, JackYPosSlider;
    public Text JackRotText, JackScaleText, JackYPosText;

    public Slider JulietStarlingRotSlider, JulietStarlingScaleSlider, JulietStarlingYPosSlider;
    public Text JulietStarlingRotText, JulietStarlingScaleText, JulietStarlingYPosText;

    public Slider WidowmakerRotSlider, WidowmakerScaleSlider, WidowmakerYPosSlider;
    public Text WidowmakerRotText, WidowmakerScaleText, WidowmakerYPosText;

    public float addScaleAmount = 0.01f;
    public float minusScaleAmount = 0.01f;

    public float addRotAmount = 5f;
    public float minusRotAmount = 5f;

    public float addYPosAmount = 0.01f;
    public float minusYPosAmount = 0.01f;

    public bool pose3isTicked = false;

    public bool ViveDetected = false;
    public bool OculusDetected = false;
    public bool NoHeadsetDetected = false;

    void Start ()
    {
        //Check if Vive detected and enable/disable the appropriate things
        if (ViveDetected)
        {
            OculusFPC.enabled = false;
            OculusCC.enabled = false;
            OculusAS.enabled = false;
            OculusRaycast.enabled = false;
            OculusCrosshair.SetActive(false);
            SteamVRObject.transform.position = new Vector3(0f, 0f, 0f);
        }
        else if (OculusDetected)
        {
            OculusFPC.enabled = true;
            OculusCC.enabled = true;
            OculusAS.enabled = true;
            OculusRaycast.enabled = true;
            OculusCrosshair.SetActive(true);
            SteamVRObject.transform.position = new Vector3(0f, 0.6f, 0f);

            CharacterController cc = SteamVRObject.GetComponent<CharacterController>();
            cc.height = 1.0f;
        }
        else
        {
            Debug.Log("No Oculus Detected. Going to player mode");

            OculusFPC.enabled = true;
            OculusCC.enabled = true;
            OculusAS.enabled = true;
            OculusRaycast.enabled = true;
            OculusCrosshair.SetActive(true);
            SteamVRObject.transform.position = new Vector3(0f, 0.6f, 0f);

            CharacterController cc = SteamVRObject.GetComponent<CharacterController>();
            cc.height = 3.0f;
        }


        foreach (Text VersionNum in VersionUI)
        {
            VersionNum.text = "VR Model Viewer: " + VersionNumber;
        }

        //Check that the right objects are enabled/disabled on start
        MainMenuUI.SetActive(true);

        LowPolyStage.SetActive(true);
        Bedroom.SetActive(false);
        DarkRoom.SetActive(false);
        JapRoom.SetActive(false);
        ParkingLot.SetActive(false);
        BookersOffice.SetActive(false);

        //All characters disabled on start
        ClaraLille.SetActive(false);
        Quiet.SetActive(false);
        Ciri.SetActive(false);
        Yennefer.SetActive(false);
        Tracer.SetActive(false);        
        MadMoxxi.SetActive(false);       
        DVa.SetActive(false);
        Widowmaker.SetActive(false);

        Nidalee.SetActive(false);
        Elizabeth.SetActive(false);
        Triss.SetActive(false);
        HarleyQuinn.SetActive(false);
        JillValentine.SetActive(false);
        LaraToO.SetActive(false);
        Jack.SetActive(false);
        JulietStarling.SetActive(false);

        foreach (GameObject obj in DisableUIScreens)
        {
            obj.SetActive(false);
        }

        //Set all UI values to 0
        ClaraRotationSlider.value = 0f; 
        QuietRotationSlider.value = 0f;
        CiriRotationSlider.value = 0f;
        YenneferRotationSlider.value = 0f;
        TracerRotationSlider.value = 0f;                      
        MoxxiRotationSlider.value = 0f;
        DVaRotSlider.value = 0f;
        NidaleeRotSlider.value = 0f;
        ElizabethRotSlider.value = 0f;
        TrissRotSlider.value = 0f;
        HarleyQuinnRotSlider.value = 0f;
        JillValentineRotSlider.value = 0f;
        LaraToORotSlider.value = 0f;
        JackRotSlider.value = 0f;
        JulietStarlingRotSlider.value = 0f;
        WidowmakerRotSlider.value = 0f;

        //Change scale values once you know the right ones
        ClaraScaleSlider.value = 0.23f;
        QuietScaleSlider.value = 0.23f;
        CiriScaleSlider.value = 0.23f;
        YenneferScaleSlider.value = 0.23f;
        TracerScaleSlider.value = 0.23f;
        MoxxiScaleSlider.value = 0.23f;
        DVaScaleSlider.value = 0.23f;
        NidaleeScaleSlider.value = 0.23f;
        ElizabethScaleSlider.value = 0.23f;
        TrissScaleSlider.value = 0.23f;
        HarleyQuinnScaleSlider.value = 0.23f;
        JillValentineScaleSlider.value = 0.23f;
        LaraToOScaleSlider.value = 0.23f;
        JackScaleSlider.value = 0.23f;
        JulietStarlingScaleSlider.value = 0.23f;
        WidowmakerScaleSlider.value = 0.23f;
    }
	
    /// <summary>
    /// Update function controls all the UI which rotates, scales and moves on their Y axis.
    /// </summary>
	void Update ()
    {
        pose3isTicked = DVa.GetComponent<DVaController>().pose3isTicked;
        if(ViveDetected)
        {
            OculusCrosshair.SetActive(false);
        }

        //Apply models scale/rotation on slider change
        Vector3 claraRotationSpeed = new Vector3(0f, 0f, ClaraRotationSlider.value);
        ClaraLille.transform.Rotate(claraRotationSpeed * Time.deltaTime);
        Vector3 claraScale = new Vector3(ClaraScaleSlider.value, ClaraScaleSlider.value, ClaraScaleSlider.value);
        ClaraLille.transform.localScale = claraScale;
        Vector3 claraYPos = new Vector3(0f, ClaraYPosSlider.value, 0f);
        ClaraLille.transform.position = claraYPos;

        Vector3 quietRotationSpeed = new Vector3(0f, 0f, QuietRotationSlider.value);
        Quiet.transform.Rotate(quietRotationSpeed * Time.deltaTime);
        Vector3 quietScale = new Vector3(QuietScaleSlider.value, QuietScaleSlider.value, QuietScaleSlider.value);
        Quiet.transform.localScale = quietScale;
        Vector3 quietYPos = new Vector3(0f, QuietYPosSlider.value, 0f);
        Quiet.transform.position = quietYPos;

        Vector3 ciriRotationSpeed = new Vector3(0f, 0f, CiriRotationSlider.value);
        Ciri.transform.Rotate(ciriRotationSpeed * Time.deltaTime);
        Vector3 ciriScale = new Vector3(CiriScaleSlider.value, CiriScaleSlider.value, CiriScaleSlider.value);
        Ciri.transform.localScale = ciriScale;
        Vector3 ciriYPos = new Vector3(0f, CiriYPosSlider.value, 0f);
        Ciri.transform.position = ciriYPos;

        Vector3 moxxiRotationSpeed = new Vector3(0f, 0f, MoxxiRotationSlider.value);
        MadMoxxi.transform.Rotate(moxxiRotationSpeed * Time.deltaTime);
        Vector3 moxxiScale = new Vector3(MoxxiScaleSlider.value, MoxxiScaleSlider.value, MoxxiScaleSlider.value);
        MadMoxxi.transform.localScale = moxxiScale;
        Vector3 moxxiYPos = new Vector3(0f, MoxxiYPosSlider.value, 0f);
        MadMoxxi.transform.position = moxxiYPos;

        Vector3 yenneferRotationSpeed = new Vector3(0f, 0f, YenneferRotationSlider.value);
        Yennefer.transform.Rotate(yenneferRotationSpeed * Time.deltaTime);
        Vector3 yenneferScale = new Vector3(YenneferScaleSlider.value, YenneferScaleSlider.value, YenneferScaleSlider.value);
        Yennefer.transform.localScale = yenneferScale;
        Vector3 yenneferYPos = new Vector3(0f, YenneferYPosSlider.value, 0f);
        Yennefer.transform.position = yenneferYPos;

        Vector3 tracerRotationSpeed = new Vector3(0f, 0f, TracerRotationSlider.value);
        Tracer.transform.Rotate(tracerRotationSpeed * Time.deltaTime);
        Vector3 tracerScale = new Vector3(TracerScaleSlider.value, TracerScaleSlider.value, TracerScaleSlider.value);
        Tracer.transform.localScale = tracerScale;
        Vector3 tracerYPos = new Vector3(0f, TracerYPosSlider.value, 0f);
        Tracer.transform.position = tracerYPos;

        if (!pose3isTicked)
        {
            Vector3 dvaRotSpeed = new Vector3(0f, 0f, DVaRotSlider.value);
            DVa.transform.Rotate(dvaRotSpeed * Time.deltaTime);
            Vector3 dvaScale = new Vector3(DVaScaleSlider.value, DVaScaleSlider.value, DVaScaleSlider.value);
            DVa.transform.localScale = dvaScale;
            Vector3 dvaYPos = new Vector3(0f, DVaYPosSlider.value, 0f);
            DVa.transform.position = dvaYPos;
        }
        else
        {
            Vector3 dvaRotSpeed = new Vector3(0f, DVaRotSlider.value, 0f);
            DVa.transform.Rotate(dvaRotSpeed * Time.deltaTime);
            Vector3 dvaScale = new Vector3(DVaScaleSlider.value, DVaScaleSlider.value, DVaScaleSlider.value);
            DVa.transform.localScale = dvaScale;
            Vector3 dvaYPos = new Vector3(0f, DVaYPosSlider.value, 0f);
            DVa.transform.position = dvaYPos;
        }

        Vector3 nidaleeRotSpeed = new Vector3(0f, 0f, NidaleeRotSlider.value);
        Nidalee.transform.Rotate(nidaleeRotSpeed * Time.deltaTime);
        Vector3 nidaleeScale = new Vector3(NidaleeScaleSlider.value, NidaleeScaleSlider.value, NidaleeScaleSlider.value);
        Nidalee.transform.localScale = nidaleeScale;
        Vector3 nidaleeYPos = new Vector3(0f, NidaleeYPosSlider.value, 0f);
        Nidalee.transform.position = nidaleeYPos;

        Vector3 elizabethRotSpeed = new Vector3(0f, 0f, ElizabethRotSlider.value);
        Elizabeth.transform.Rotate(elizabethRotSpeed * Time.deltaTime);
        Vector3 elizabethScale = new Vector3(ElizabethScaleSlider.value, ElizabethScaleSlider.value, ElizabethScaleSlider.value);
        Elizabeth.transform.localScale = elizabethScale;
        Vector3 elizabethYPos = new Vector3(0f, ElizabethYPosSlider.value, 0f);
        Elizabeth.transform.position = elizabethYPos;

        Vector3 trissRotSpeed = new Vector3(0f, 0f, TrissRotSlider.value);
        Triss.transform.Rotate(trissRotSpeed * Time.deltaTime);
        Vector3 trissScale = new Vector3(TrissScaleSlider.value, TrissScaleSlider.value, TrissScaleSlider.value);
        Triss.transform.localScale = trissScale;
        Vector3 trissYPos = new Vector3(0f, TrissYPosSlider.value, 0f);
        Triss.transform.position = trissYPos;

        Vector3 harleyRotSpeed = new Vector3(0f, 0f, HarleyQuinnRotSlider.value);
        HarleyQuinn.transform.Rotate(harleyRotSpeed * Time.deltaTime);
        Vector3 harleyScale = new Vector3(HarleyQuinnScaleSlider.value, HarleyQuinnScaleSlider.value, HarleyQuinnScaleSlider.value);
        HarleyQuinn.transform.localScale = harleyScale;
        Vector3 harleyYPos = new Vector3(0f, HarleyQuinnYPosSlider.value, 0f);
        HarleyQuinn.transform.position = harleyYPos;

        Vector3 jillRotSpeed = new Vector3(0f, 0f, JillValentineRotSlider.value);
        JillValentine.transform.Rotate(jillRotSpeed * Time.deltaTime);
        Vector3 jillScale = new Vector3(JillValentineScaleSlider.value, JillValentineScaleSlider.value, JillValentineScaleSlider.value);
        JillValentine.transform.localScale = jillScale;
        Vector3 jillValentineYPos = new Vector3(0f, JillValentineYPosSlider.value, 0f);
        JillValentine.transform.position = jillValentineYPos;

        Vector3 laraToORotSpeed = new Vector3(0f, 0f, LaraToORotSlider.value);
        LaraToO.transform.Rotate(laraToORotSpeed * Time.deltaTime);
        Vector3 laraToOScale = new Vector3(LaraToOScaleSlider.value, LaraToOScaleSlider.value, LaraToOScaleSlider.value);
        LaraToO.transform.localScale = laraToOScale;
        Vector3 laraToOYPos = new Vector3(0f, LaraCroftToOYPosSlider.value, 0f);
        LaraToO.transform.position = laraToOYPos;

        Vector3 jackRotSpeed = new Vector3(0f, 0f, JackRotSlider.value);
        Jack.transform.Rotate(jackRotSpeed * Time.deltaTime);
        Vector3 jackScale = new Vector3(JackScaleSlider.value, JackScaleSlider.value, JackScaleSlider.value);
        Jack.transform.localScale = jackScale;
        Vector3 jackYPos = new Vector3(0f, JackYPosSlider.value, 0f);
        Jack.transform.position = jackYPos;

        Vector3 julietRotSpeed = new Vector3(0f, 0f, JulietStarlingRotSlider.value);
        JulietStarling.transform.Rotate(julietRotSpeed * Time.deltaTime);
        Vector3 julietScale = new Vector3(JulietStarlingScaleSlider.value, JulietStarlingScaleSlider.value, JulietStarlingScaleSlider.value);
        JulietStarling.transform.localScale = julietScale;
        Vector3 julietYPos = new Vector3(0f, JulietStarlingYPosSlider.value, 0f);
        JulietStarling.transform.position = julietYPos;

        Vector3 widowmakerRotSpeed = new Vector3(0f, 0f, WidowmakerRotSlider.value);
        Widowmaker.transform.Rotate(widowmakerRotSpeed * Time.deltaTime);
        Vector3 widowmakerScale = new Vector3(WidowmakerScaleSlider.value, WidowmakerScaleSlider.value, WidowmakerScaleSlider.value);
        Widowmaker.transform.localScale = widowmakerScale;
        Vector3 widowmakerYPos = new Vector3(0f, WidowmakerYPosSlider.value, 0f);
        Widowmaker.transform.position = widowmakerYPos;

        //Sliders Value Updates
        //Clara Lille
        ClaraRotText.text = ClaraRotationSlider.value.ToString();
        ClaraScaleText.text = ClaraScaleSlider.value.ToString();
        ClaraYPosText.text = ClaraYPosSlider.value.ToString();
        //Quiet
        QuietRotText.text = QuietRotationSlider.value.ToString();
        QuietScaleText.text = QuietScaleSlider.value.ToString();
        QuietYPosText.text = QuietYPosSlider.value.ToString();
        //Ciri
        CiriRotText.text = CiriRotationSlider.value.ToString();
        CiriScaleText.text = CiriScaleSlider.value.ToString();
        CiriYPosText.text = CiriYPosSlider.value.ToString();
        //Yennefer
        YenneferRotText.text = YenneferRotationSlider.value.ToString();
        YenneferScaleText.text = YenneferScaleSlider.value.ToString();
        YenneferYPosText.text = YenneferYPosSlider.value.ToString();
        //Tracer
        TracerRotText.text = TracerRotationSlider.value.ToString();
        TracerScaleText.text = TracerScaleSlider.value.ToString();
        TracerYPosText.text = TracerYPosSlider.value.ToString();
        //Mad Moxxi
        MoxxiRotText.text = MoxxiRotationSlider.value.ToString();
        MoxxiScaleText.text = MoxxiScaleSlider.value.ToString();
        MoxxiYPosText.text = MoxxiYPosSlider.value.ToString();
        //DVa
        DVaRotText.text = DVaRotSlider.value.ToString();
        DVaScaleText.text = DVaScaleSlider.value.ToString();
        DVaYPosText.text = DVaYPosSlider.value.ToString();
        //Nidalee
        NidaleeRotText.text = NidaleeRotSlider.value.ToString();
        NidaleeScaleText.text = NidaleeScaleSlider.value.ToString();
        NidaleeYPosText.text = NidaleeYPosSlider.value.ToString();
        //Elizabeth
        ElizabethRotText.text = ElizabethRotSlider.value.ToString();
        ElizabethScaleText.text = ElizabethScaleSlider.value.ToString();
        ElizabethYPosText.text = ElizabethYPosSlider.value.ToString();
        //Triss
        TrissRotText.text = TrissRotSlider.value.ToString();
        TrissScaleText.text = TrissScaleSlider.value.ToString();
        TrissYPosText.text = TrissYPosSlider.value.ToString();
        //HarleyQuinn
        HarleyQuinnRotText.text = HarleyQuinnRotSlider.value.ToString();
        HarleyQuinnScaleText.text = HarleyQuinnScaleSlider.value.ToString();
        HarleyQuinnYPosText.text = HarleyQuinnYPosSlider.value.ToString();
        //Jill Valentine
        JillValentineRotText.text = JillValentineRotSlider.value.ToString();
        JillValentineScaleText.text = JillValentineScaleSlider.value.ToString();
        JillValentineYPosText.text = JillValentineYPosSlider.value.ToString();
        //Lara Croft - Temple of Osiris
        LaraToORotText.text = LaraToORotSlider.value.ToString();
        LaraToOScaleText.text = LaraToOScaleSlider.value.ToString();
        LaraCroftToOYPosText.text = LaraCroftToOYPosSlider.value.ToString();
        //Jack - Mass Effect
        JackRotText.text = JackRotSlider.value.ToString();
        JackScaleText.text = JackScaleSlider.value.ToString();
        JackYPosText.text = JackYPosSlider.value.ToString();
        //Juliet Starling - Lollipop Chainsaw
        JulietStarlingRotText.text = JulietStarlingRotSlider.value.ToString();
        JulietStarlingScaleText.text = JulietStarlingScaleSlider.value.ToString();
        JulietStarlingYPosText.text = JulietStarlingYPosSlider.value.ToString();
        //Widowmaker - Overwatch
        WidowmakerRotText.text = WidowmakerRotSlider.value.ToString();
        WidowmakerScaleText.text = WidowmakerScaleSlider.value.ToString();
        WidowmakerYPosText.text = WidowmakerYPosSlider.value.ToString();
    }

    /// <summary>
    /// Function to reset a model to their normal values
    /// </summary>
    /// <param name="model"></param>
    public void ResetModel(GameObject model)
    {
        model.transform.eulerAngles = new Vector3(DefaultRotation, 0, 0);
        model.transform.localScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);
        model.transform.position = new Vector3(0f, 0f, 0f);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }

    /// <summary>
    /// Reset a slider to 0
    /// </summary>
    /// <param name="slider"></param>
    public void ResetSliderRotValues(Slider slider)
    {
        slider.value = 0; //Reset to 0 rotated, not 0 rotation
    }

    public void ResetScaleSliderValue(Slider slider)
    {
        slider.value = ScaleValue;
    }

    /// <summary>
    /// Toggle light probes. "Enhanced Lighting" option
    /// </summary>
    /// <param name="toggle"></param>
    public void ToggleLightProbes(bool toggle)
    {
        if(toggle)
        {
            if (LowPolyStage.activeInHierarchy)
                LowPolyStageProbe.SetActive(true);
            else if (Bedroom.activeInHierarchy)
                BedroomProbe.SetActive(true);
            else if (DarkRoom.activeInHierarchy)
                DarkRoomProbe.SetActive(true);
            else if (JapRoom.activeInHierarchy)
                JapRoomProbe.SetActive(true);
            else if (ParkingLot.activeInHierarchy)
                ParkingLotProbe.SetActive(true);
            else if (BookersOfficeProbe.activeInHierarchy)
                BookersOfficeProbe.SetActive(true);
            else
                Debug.Log("Can't enable any light probes!");
        }
        else
        {
            if (LowPolyStage.activeInHierarchy)
                LowPolyStageProbe.SetActive(false);
            else if (Bedroom.activeInHierarchy)
                BedroomProbe.SetActive(false);
            else if (DarkRoom.activeInHierarchy)
                DarkRoomProbe.SetActive(false);
            else if (JapRoom.activeInHierarchy)
                JapRoomProbe.SetActive(false);
            else if (ParkingLot.activeInHierarchy)
                ParkingLotProbe.SetActive(false);
            else if (BookersOfficeProbe.activeInHierarchy)
                BookersOfficeProbe.SetActive(false);
            else
                Debug.Log("Can't disable any light probes!");
        }
    }

    public void ExitApp()
    {
#if UNITY_EDITOR
        Debug.Log("Close Application");
#else
        Application.Quit();
#endif
    }

    /// <summary>
    /// Nothing else in this script. Below are fucntions to add and subtract to each models sliders
    /// </summary>
    /*The Never Ending Code*/
    //Clara Lille
    public void CLScaleAdd()
    {
        ClaraScaleSlider.value = ClaraScaleSlider.value + addScaleAmount;
    }
    public void CLScaleMinus()
    {
        ClaraScaleSlider.value = ClaraScaleSlider.value - minusScaleAmount;
    }
    public void CLRotAdd()
    {
        ClaraRotationSlider.value = ClaraRotationSlider.value + addRotAmount;
    }
    public void CLRotMinus()
    {
        ClaraRotationSlider.value = ClaraRotationSlider.value - minusRotAmount;
    }
    public void ClaraYPosAdd()
    {
        ClaraYPosSlider.value = ClaraYPosSlider.value + addYPosAmount;
    }
    public void ClaraYPosMinus()
    {
        ClaraYPosSlider.value = ClaraYPosSlider.value - minusYPosAmount;
    }
    //Quiet
    public void QuietScaleAdd()
    {
        QuietScaleSlider.value = QuietScaleSlider.value + addScaleAmount;
    }
    public void QuietScaleMinus()
    {
        QuietScaleSlider.value = QuietScaleSlider.value - minusScaleAmount;
    }
    public void QuietRotAdd()
    {
        QuietRotationSlider.value = QuietRotationSlider.value + addRotAmount;
    }
    public void QuietRotMinus()
    {
        QuietRotationSlider.value = QuietRotationSlider.value - minusRotAmount;
    }
    public void QuietYPosAdd()
    {
        QuietYPosSlider.value = QuietYPosSlider.value + addYPosAmount;
    }
    public void QuietYPosMinus()
    {
        QuietYPosSlider.value = QuietYPosSlider.value - minusYPosAmount;
    }
    //Ciri
    public void CiriScaleAdd()
    {
        CiriScaleSlider.value = CiriScaleSlider.value + addScaleAmount;
    }
    public void CiriScaleMinus()
    {
        CiriScaleSlider.value = CiriScaleSlider.value - minusScaleAmount;
    }
    public void CiriRotAdd()
    {
        CiriRotationSlider.value = CiriRotationSlider.value + addRotAmount;
    }
    public void CiriRotMinus()
    {
        CiriRotationSlider.value = CiriRotationSlider.value - minusRotAmount;
    }
    public void CiriYPosAdd()
    {
        CiriYPosSlider.value = CiriYPosSlider.value + addYPosAmount;
    }
    public void CiriYPosMinus()
    {
        CiriYPosSlider.value = CiriYPosSlider.value - minusYPosAmount;
    }
    //Yennefer
    public void YenneferScaleAdd()
    {
        YenneferScaleSlider.value = YenneferScaleSlider.value + addScaleAmount;
    }
    public void YenneferScaleMinus()
    {
        YenneferScaleSlider.value = YenneferScaleSlider.value - minusScaleAmount;
    }
    public void YenneferRotAdd()
    {
        YenneferRotationSlider.value = YenneferRotationSlider.value + addRotAmount;
    }
    public void YenneferRotMinus()
    {
        YenneferRotationSlider.value = YenneferRotationSlider.value - minusRotAmount;
    }
    public void YenneferYPosAdd()
    {
        YenneferYPosSlider.value = YenneferYPosSlider.value + addYPosAmount;
    }
    public void YenneferYPosMinus()
    {
        YenneferYPosSlider.value = YenneferYPosSlider.value - minusYPosAmount;
    }
    //Tracer
    public void TracerScaleAdd()
    {
        TracerScaleSlider.value = TracerScaleSlider.value + addScaleAmount;
    }
    public void TracerScaleMinus()
    {
        TracerScaleSlider.value = TracerScaleSlider.value - minusScaleAmount;
    }
    public void TracerRotAdd()
    {
        TracerRotationSlider.value = TracerRotationSlider.value + addRotAmount;
    }
    public void TracerRotMinus()
    {
        TracerRotationSlider.value = TracerRotationSlider.value - minusRotAmount;
    }
    public void TracerYPosAdd()
    {
        TracerYPosSlider.value = TracerYPosSlider.value + addYPosAmount;
    }
    public void TracerYPosMinus()
    {
        TracerYPosSlider.value = TracerYPosSlider.value - minusYPosAmount;
    }
    //Mad Moxxi
    public void MoxxiScaleAdd()
    {
        MoxxiScaleSlider.value = MoxxiScaleSlider.value + addScaleAmount;
    }
    public void MoxxiScaleMinus()
    {
        MoxxiScaleSlider.value = MoxxiScaleSlider.value - minusScaleAmount;
    }
    public void MoxxiRotAdd()
    {
        MoxxiRotationSlider.value = MoxxiRotationSlider.value + addRotAmount;
    }
    public void MoxxiRotMinus()
    {
        MoxxiRotationSlider.value = MoxxiRotationSlider.value - minusRotAmount;
    }
    public void MoxxiYPosAdd()
    {
        MoxxiYPosSlider.value = MoxxiYPosSlider.value + addYPosAmount;
    }
    public void MoxxiYPosMinus()
    {
        MoxxiYPosSlider.value = MoxxiYPosSlider.value - minusYPosAmount;
    }
    //DVa
    public void DVaScaleAdd()
    {
        DVaScaleSlider.value = DVaScaleSlider.value + addScaleAmount;
    }
    public void DVaScaleMinus()
    {
        DVaScaleSlider.value = DVaScaleSlider.value - minusScaleAmount;
    }
    public void DVaRotAdd()
    {
        DVaRotSlider.value = DVaRotSlider.value + addRotAmount;
    }
    public void DVaRotMinus()
    {
        DVaRotSlider.value = DVaRotSlider.value - minusRotAmount;
    }
    public void DVaYPosAdd()
    {
        DVaYPosSlider.value = DVaYPosSlider.value + addYPosAmount;
    }
    public void DVaYPosMinus()
    {
        DVaYPosSlider.value = DVaYPosSlider.value - minusYPosAmount;
    }
    //Nidalee
    public void NidaleeScaleAdd()
    {
        NidaleeScaleSlider.value = NidaleeScaleSlider.value + addScaleAmount;
    }
    public void NidaleeScaleMinus()
    {
        NidaleeScaleSlider.value = NidaleeScaleSlider.value - minusScaleAmount;
    }
    public void NidaleeRotAdd()
    {
        NidaleeRotSlider.value = NidaleeRotSlider.value + addRotAmount;
    }
    public void NidaleeRotMinus()
    {
        NidaleeRotSlider.value = NidaleeRotSlider.value - minusRotAmount;
    }
    public void NidaleeYPosAdd()
    {
        NidaleeYPosSlider.value = NidaleeYPosSlider.value + addYPosAmount;
    }
    public void NidaleeYPosMinus()
    {
        NidaleeYPosSlider.value = NidaleeYPosSlider.value - minusYPosAmount;
    }
    //Elizabeth
    public void ElizabethScaleAdd()
    {
        ElizabethScaleSlider.value = ElizabethScaleSlider.value + addScaleAmount;
    }
    public void ElizabethScaleMinus()
    {
        ElizabethScaleSlider.value = ElizabethScaleSlider.value - minusScaleAmount;
    }
    public void ElizabethRotAdd()
    {
        ElizabethRotSlider.value = ElizabethRotSlider.value + addRotAmount;
    }
    public void ElizabethRotMinus()
    {
        ElizabethRotSlider.value = ElizabethRotSlider.value - minusRotAmount;
    }
    public void ElizabethYPosAdd()
    {
        ElizabethYPosSlider.value = ElizabethYPosSlider.value + addYPosAmount;
    }
    public void ElizabethYPosMinus()
    {
        ElizabethYPosSlider.value = ElizabethYPosSlider.value - minusYPosAmount;
    }
    //Triss
    public void TrissScaleAdd()
    {
        TrissScaleSlider.value = TrissScaleSlider.value + addScaleAmount;
    }
    public void TrissScaleMinus()
    {
        TrissScaleSlider.value = TrissScaleSlider.value - minusScaleAmount;
    }
    public void TrissRotAdd()
    {
        TrissRotSlider.value = TrissRotSlider.value + addRotAmount;
    }
    public void TrissRotMinus()
    {
        TrissRotSlider.value = TrissRotSlider.value - minusRotAmount;
    }
    public void TrissYPosAdd()
    {
        TrissYPosSlider.value = TrissYPosSlider.value + addYPosAmount;
    }
    public void TrissYPosMinus()
    {
        TrissYPosSlider.value = TrissYPosSlider.value - minusYPosAmount;
    }
    //Harley Quinn
    public void HarleyQuinnScaleAdd()
    {
        HarleyQuinnScaleSlider.value = HarleyQuinnScaleSlider.value + addScaleAmount;
    }
    public void HarleyQuinnScaleMinus()
    {
        HarleyQuinnScaleSlider.value = HarleyQuinnScaleSlider.value - minusScaleAmount;
    }
    public void HarleyQuinnRotAdd()
    {
        HarleyQuinnRotSlider.value = HarleyQuinnRotSlider.value + addRotAmount;
    }
    public void HarleyQuinnRotMinus()
    {
        HarleyQuinnRotSlider.value = HarleyQuinnRotSlider.value - minusRotAmount;
    }
    public void HarleyQuinnYPosAdd()
    {
        HarleyQuinnYPosSlider.value = JillValentineYPosSlider.value + addYPosAmount;
    }
    public void HarleyQuinnYPosMinus()
    {
        HarleyQuinnYPosSlider.value = JillValentineYPosSlider.value - minusYPosAmount;
    }
    //Jill Valentine
    public void JillValentineScaleAdd()
    {
        JillValentineScaleSlider.value = JillValentineScaleSlider.value + addScaleAmount;
    }
    public void JillValentineScaleMinus()
    {
        JillValentineScaleSlider.value = JillValentineScaleSlider.value - minusScaleAmount;
    }
    public void JillValentineRotAdd()
    {
        JillValentineRotSlider.value = JillValentineRotSlider.value + addRotAmount;
    }
    public void JillValentineRotMinus()
    {
        JillValentineRotSlider.value = JillValentineRotSlider.value - minusRotAmount;
    }
    public void JillValentineYPosAdd()
    {
        JillValentineYPosSlider.value = JillValentineYPosSlider.value + addYPosAmount;
    }
    public void JillValentineYPosMinus()
    {
        JillValentineYPosSlider.value = JillValentineYPosSlider.value - minusYPosAmount;
    }
    //Lara - Temple of Osiris
    public void LaraToOScaleAdd()
    {
        LaraToOScaleSlider.value = LaraToOScaleSlider.value + addScaleAmount;
    }
    public void LaraToOScaleMinus()
    {
        LaraToOScaleSlider.value = LaraToOScaleSlider.value - minusScaleAmount;
    }
    public void LaraToORotAdd()
    {
        LaraToORotSlider.value = LaraToORotSlider.value + addRotAmount;
    }
    public void LaraToORotMinus()
    {
        LaraToORotSlider.value = LaraToORotSlider.value - minusRotAmount;
    }
    public void LaraToOYPosAdd()
    {
        LaraCroftToOYPosSlider.value = LaraCroftToOYPosSlider.value + addYPosAmount;
    }
    public void LaraToOYPosMinus()
    {
        LaraCroftToOYPosSlider.value = LaraCroftToOYPosSlider.value - minusYPosAmount;
    }
    //Jack - Mass Effect
    public void JackScaleAdd()
    {
        JackScaleSlider.value = JackScaleSlider.value + addScaleAmount;
    }
    public void JackScaleMinus()
    {
        JackScaleSlider.value = JackScaleSlider.value - minusScaleAmount;
    }
    public void JackRotAdd()
    {
        JackRotSlider.value = JackRotSlider.value + addRotAmount;
    }
    public void JackRotMinus()
    {
        JackRotSlider.value = JackRotSlider.value - minusRotAmount;
    }
    public void JackYPosAdd()
    {
        JackYPosSlider.value = JackYPosSlider.value + addYPosAmount;
    }
    public void JackYPosMinus()
    {
        JackYPosSlider.value = JackYPosSlider.value - minusYPosAmount;
    }
    //Juliet Starling - Lollipop Chainsaw
    public void JulietStarlingScaleAdd()
    {
        JulietStarlingScaleSlider.value = JulietStarlingScaleSlider.value + addScaleAmount;
    }
    public void JulietStarlingScaleMinus()
    {
        JulietStarlingScaleSlider.value = JulietStarlingScaleSlider.value - minusScaleAmount;
    }
    public void JulietStarlingRotAdd()
    {
        JulietStarlingRotSlider.value = JulietStarlingRotSlider.value + addRotAmount;
    }
    public void JulietStarlingRotMinus()
    {
        JulietStarlingRotSlider.value = JulietStarlingRotSlider.value - minusRotAmount;
    }
    public void JulietYPosAdd()
    {
        JulietStarlingYPosSlider.value = JulietStarlingYPosSlider.value + addYPosAmount;
    }
    public void JulietYPosMinus()
    {
        JulietStarlingYPosSlider.value = JulietStarlingYPosSlider.value - minusYPosAmount;
    }
    //Widowmaker - Overwatch
    public void WidowmakerScaleAdd()
    {
        WidowmakerScaleSlider.value = WidowmakerScaleSlider.value + addScaleAmount;
    }
    public void WidowmakerScaleMinus()
    {
        WidowmakerScaleSlider.value = WidowmakerScaleSlider.value - minusScaleAmount;
    }
    public void WidowmakerRotAdd()
    {
        WidowmakerRotSlider.value = WidowmakerRotSlider.value + addRotAmount;
    }
    public void WidowmakerRotMinus()
    {
        WidowmakerRotSlider.value = WidowmakerRotSlider.value - minusRotAmount;
    }
    public void WidowmakerYPosAdd()
    {
        WidowmakerYPosSlider.value = WidowmakerYPosSlider.value + addYPosAmount;
    }
    public void WidowmakerYPosMinus()
    {
        WidowmakerYPosSlider.value = WidowmakerYPosSlider.value - minusYPosAmount;
    }
}
