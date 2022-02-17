using TMPro;
using UnityEngine;

public class ViewField : MonoBehaviour
{
    private TMP_Text _inputField;

    private void OnEnable()
    {
        _inputField = GetComponent<TMP_Text>();
        CalcMV.OnInputUpdate += UpdateInput;
    }

    private void OnDisable()
    {
        CalcMV.OnInputUpdate -= UpdateInput;
    }

    private void UpdateInput(string val)
    {
        _inputField.text = val;
    }
}
