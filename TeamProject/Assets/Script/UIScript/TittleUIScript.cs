using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TittleUIScript : MonoBehaviour
{
    [SerializeField]
    public  AudioClip SFX_HoverSound;
    [SerializeField]
    public GameObject SFX_TittleBGM;
    [SerializeField]
    public GameObject UI_Options;
 


    //Options Window Object
    private static GameObject obj_Options;

    private static GameObject obj_TittleBGM;
    
    //Public Button Click Sound Source Object
    private static AudioSource buttonAudio;

 
   
    


    // Start is called before the first frame update
    void Start()
    {
        buttonAudio = gameObject.GetComponent<AudioSource>();
        obj_TittleBGM = GameObject.Instantiate<GameObject>(SFX_TittleBGM);
        obj_TittleBGM.GetComponent<AudioSource>().Play();
        obj_TittleBGM.GetComponent<AudioSource>().loop = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    //Play Button Click Sound
    public void HoverAtButton()
    {
        buttonAudio.Play(); 
    }

    //Close Options window
    public void Click_CloseButton()
    {
        if (obj_Options)
            obj_Options.SetActive(false);
    }


    public void Click_Options()
    {

        if (!obj_Options)
            obj_Options = GameObject.Instantiate<GameObject>(UI_Options);
        else
            obj_Options.SetActive(true);
    }

    //Mute input param's sound
    public void Click_Mute(GameObject muteObject)
    {
        //bool bIsMuted = muteObject.GetComponent<AudioSource>().mute;

        //if (bIsMuted)
        //    muteObject.GetComponent<AudioSource>().mute = false;
        //else
        //    muteObject.GetComponent<AudioSource>().mute = true;

        if (muteObject == SFX_TittleBGM)
            muteBGM();


    }
    public void Click_ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

        #else
            Application.Quit(); 

        #endif
    }

    public void Slide_BGM(Slider slider )
    {
        print(slider.value);
        obj_TittleBGM.GetComponent<AudioSource>().volume = slider.value;

    }

    private void muteBGM()
    {
        bool bIsMuted = obj_TittleBGM.GetComponent<AudioSource>().mute;

        if (bIsMuted)
            obj_TittleBGM.GetComponent<AudioSource>().mute = false;
        else
            obj_TittleBGM.GetComponent<AudioSource>().mute = true;
    }
}
 