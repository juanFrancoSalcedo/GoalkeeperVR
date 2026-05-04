using System;
using TMPro;
using UnityEngine;

public class FormInputCellphoneField : MonoBehaviour, IFormInput
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private string errorType = "No es un número de correo valido";
    public event Action<object> OnUpdateState;
    public event Action<string> OnError;

    private void Start() => inputField.onValueChanged.AddListener(CheckInput);
    private void CheckInput(string arg0) => OnUpdateState?.Invoke(arg0);
    public bool CheckComplete() => inputField.text.Length >= 10;
    public object GetValue() => inputField.text;
}

