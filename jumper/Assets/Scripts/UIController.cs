using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private InputField inputField;
    
    void Start()
    {
        
        button.onClick.AddListener(() =>
        {
            image.enabled = !image.IsActive();
            image.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = image.IsActive();
        });
        inputField.onEndEdit.AddListener(delegate { ChangeText(inputField); });
    }
    
     private void ChangeText(InputField input)
    {
        image.transform.GetChild(0).gameObject.GetComponent<Text>().text = input.text;
    }

    
    
}
