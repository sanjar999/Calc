using UnityEngine;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    [SerializeField] private char _val;
    [SerializeField] private CalcMV _calcMV;
    private Button _btn;
    private void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(()=> _calcMV.GetInput(_val));
    }
}
