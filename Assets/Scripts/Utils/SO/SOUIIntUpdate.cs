using UnityEngine;
using TMPro;
using UnityEditor.AssetImporters;

public class SOUIIntUpdate : MonoBehaviour
{
    public SOint soInt;
    public TextMeshProUGUI uiTextValue;

    private void Start()
    {
        uiTextValue.text = soInt.value.ToString();
    }


    private void Update()
    {
        uiTextValue.text = soInt.value.ToString();
    }










}

