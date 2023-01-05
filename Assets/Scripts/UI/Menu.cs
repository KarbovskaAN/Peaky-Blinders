using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public TMP_InputField WidthText;
    public TMP_InputField HeightText;
    public TMP_InputField CountGreen;
    public TMP_InputField CountYellow;
    public TMP_InputField CountRed;
    
    [SerializeField] private TextMeshProUGUI m_text;
    
    public TMP_Text TotalNumber; 
    private int _totalNumber; 

    private int _width ;
    private int _height ;

    private int _countGreenButton;
    private int _countYellowButton ;
    private int _countRedButton ;

    public GameObject UISettingsPanel;
    public GameObject GamePanel;

    public Field _field;
    private Convert _convert;

    private void Start()
    {
        _convert = new Convert();
        
        WidthText.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
        HeightText.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
        
    }

    public void FieldGenerateButton()
    { 
       _field.DeletedAllButtons();
        
       _width = _convert.ConvertText(WidthText.text);
       _height =  _convert.ConvertText(HeightText.text);
       _countGreenButton =  _convert.ConvertText(CountGreen.text);
       _countYellowButton =  _convert.ConvertText(CountYellow.text);
       _countRedButton =  _convert.ConvertText(CountRed.text);
        
       _field.GenerateField(_width, _height, _countGreenButton, _countYellowButton, _countRedButton);
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

    public void ValueChangeCheck()
    {
        if (WidthText.text != "" && HeightText.text != "")
        {
            _width = _convert.ConvertText(WidthText.text);
            _height = _convert.ConvertText(HeightText.text);
            _totalNumber = _width * _height;
            TotalNumber.text = _totalNumber.ToString();
            
            _countGreenButton = _totalNumber / 3;
            
            CountGreen.text= _countGreenButton.ToString();

            _countYellowButton = (_totalNumber / 3) - 1;
            if (_countYellowButton <=0)
            {
                _countYellowButton = 0;
            }
            CountYellow.text = _countYellowButton.ToString();
        }

        
    }
    
}
