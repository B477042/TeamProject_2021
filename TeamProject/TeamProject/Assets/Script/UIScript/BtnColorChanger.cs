using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BtnColorChanger : MonoBehaviour
{

    [SerializeField]
    private Color originalColor;
    [SerializeField]
    private Color changedColor = Color.gray;

    bool bIsChanged = false;

    

    // Start is called before the first frame update
    void Start()
    {
        originalColor = gameObject.GetComponent<Image>().color;
    }

   public  void OnClick()
    {
        if (!bIsChanged)
        { gameObject.GetComponent<Image>().color = changedColor;  bIsChanged = true; }
        else
        { gameObject.GetComponent<Image>().color = originalColor;bIsChanged = false; }

    }


}
