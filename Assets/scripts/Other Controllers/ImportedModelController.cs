using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ImportedModelController : MonoBehaviour {

    public GameObject importedModel;
    public Slider ImportRotSlider, ImportYPosSlider;
    public Text ImportRotText, ImportYPosText;
    InputField importScale;

    ExternalImportModelController eIMC;

	void Start ()
    {
        eIMC = GameObject.Find("ImportedModelController").GetComponent<ExternalImportModelController>();
        eIMC.currentImportedModel = this.gameObject;
        eIMC.imc = this.GetComponent<ImportedModelController>();

        importedModel = this.gameObject;        

        //Will work as all names are correct
        ImportRotSlider = GameObject.Find("ImportRotateSlider").GetComponent<Slider>();
        ImportYPosSlider = GameObject.Find("ImportYPosSlider").GetComponent<Slider>();

        ImportRotText = GameObject.Find("ImportRotNumber").GetComponent<Text>();
        ImportYPosText = GameObject.Find("ImportYPosNumber").GetComponent<Text>();

        importScale = GameObject.Find("ModelScaleInputField").GetComponent<InputField>();
    }

    void FixedUpdate ()
    {
        Vector3 importRotSpeed = new Vector3(0f, ImportRotSlider.value, 0f);
        importedModel.transform.Rotate(importRotSpeed * Time.deltaTime);
        Vector3 importYPos = new Vector3(0f, ImportYPosSlider.value, 0f);
        importedModel.transform.position = importYPos;

        ImportRotText.text = ImportRotSlider.value.ToString();
        ImportYPosText.text = ImportYPosSlider.value.ToString();

        //Test for unwanted characters.
        var errorCount = Regex.Matches(importScale.text, @"[a-zA-Z]").Count;
        if(errorCount > 0 || importScale.text == "")
        {
            return;
        }
        float importNum = float.Parse(importScale.text);
        Vector3 importedModelScale = new Vector3(importNum, importNum, importNum);
        importedModel.transform.localScale = importedModelScale;
    }
}
