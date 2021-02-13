using System.Collections;
using System.Collections.Generic;

using TextSpeech;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "es-EC";

    
    void Start()
    {
        Setup(LANG_CODE);

#if UNITY_ANDROID

        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;

#endif
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakStop;

        checkPermissions();

    }

    public string getUITEXT(){
        return "kk";
    }

    void checkPermissions()
    {
#if UNITY_ANDROID
        if(!Permission.HasUserAuthorizedPermission(Permission.Microphone)){
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }

#region Text to Speech
    public void StartSpeaking(string message)
    {

        TextToSpeech.instance.StartSpeak(message);
    }
    public void StopSpeaking()
    {

        TextToSpeech.instance.StopSpeak();

    }

    void OnSpeakStart()
    {
        Debug.Log("Talking started...");
    }

    void OnSpeakStop()
    {
        Debug.Log(" End Talk");
    }
#endregion
#region Speech to text
    public void StartListening()
    {

        SpeechToText.instance.StartRecording();
    }
    public void StopListening()
    {
        SpeechToText.instance.StopRecording();

    }

    void OnFinalSpeechResult(string result)
    {
       
        GameObject api = GameObject.Find ("Api");
        PokeAPIController apiObj = api.GetComponent <PokeAPIController> ();
        apiObj.OnButtonRandomPokemon(result);
    }
    void OnPartialSpeechResult(string result)
    {
       
    }
#endregion

    void Setup(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
    }

}
