using System.Collections;
using System.Collections.Generic;

using UnityEngine;


//alternate between two colors
public class BlinkingLetter : MonoBehaviour
{
    //Letters represented by this game object
    string SubjectText;

    //Glittering Spacing
    [SerializeField]
    public float BlinkTime=5.0f;

   
    [SerializeField]
    public Color Color1= Color.yellow;
    [SerializeField]
    public Color Color2 = Color.blue;

    float blinkTimer = 0.0f;
    //If color1 to color2 is interpolated, it is true.
    bool bIsAlternated = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }



    // Update is called once per frame
    void Update()
    {
        blinkTimer += Time.fixedDeltaTime;

        if (blinkTimer >= BlinkTime)
            resetTimer();
        //Percentage calculation Time
        float percent = (BlinkTime - blinkTimer) / BlinkTime;

        blink(percent);

    }


    void blink(float percent)
    {
        var TextComponent = gameObject.GetComponent<UnityEngine.UI.Text>();

        //Color1 -----> Color2
        if(!bIsAlternated)
        {
            TextComponent.color= Color.Lerp(Color1, Color2, percent);
        }
        //Color2 -----> Color1
        else
        {
            TextComponent.color = Color.Lerp(Color2, Color1, percent);
        }

        
    }
    //Reset Timer and Change Alternated
    void resetTimer()
    {
        blinkTimer = 0.0f;

        if (bIsAlternated) bIsAlternated = false;
        else bIsAlternated = true;

    }



}
