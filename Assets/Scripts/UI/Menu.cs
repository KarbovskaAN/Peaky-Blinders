using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TMP_InputField WidthText;
    public TMP_InputField HeightText;
    public TMP_InputField CountGreen;
    public TMP_InputField CountYellow;
    public TMP_InputField CountRed;

    private int Width ;
    private int Height ;

    private int CountGreenButton ;
    private int CountYellowButton ;
    private int CountRedButton ;

    public GameObject UISettingsPanel;
    public GameObject GamePanel;

    public Field _field;
    private Convert _convert;

    private void Start()
    {
        _convert = new Convert();
    }

    public void FieldGenerateButton()
    { 
       _field.DeletedAllButtons();
        
       Width = _convert.ConvertText(WidthText.text);
       Height =  _convert.ConvertText(HeightText.text);
       CountGreenButton =  _convert.ConvertText(CountGreen.text);
       CountYellowButton =  _convert.ConvertText(CountYellow.text);
       CountRedButton =  _convert.ConvertText(CountRed.text);
        
       _field.GenerateField(Width, Height, CountGreenButton, CountYellowButton, CountRedButton);
       UISettingsPanel.SetActive(false);
       GamePanel.SetActive(true);
    }

    public void SettingsButton()
    {
        GamePanel.SetActive(false);
        UISettingsPanel.SetActive(true);
    }

    public void CloseButton()
    {
        UISettingsPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    
}
