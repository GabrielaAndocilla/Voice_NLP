using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;


public class Interaction : MonoBehaviour
{
    [SerializeField]
    Text Texttt;
    
    public void responder(JSONNode resultados){


              
        string respuesta = "";
         
        foreach (KeyValuePair<string, JSONNode> kvp in resultados)
        {
            //Debug.Log(kvp.Value[0]["role"]+" - "+kvp.Value[0]["confidence"]);
            string role =kvp.Value[0]["role"];
            if(kvp.Value[0]["confidence"]>0.60){
                switch (role)
                {
                    case "message_body":
                      if( respuesta!="" || respuesta=="Tu mensaje no esta claro" ){
                            respuesta = "Tu mensaje no esta claro";
                        }
                        break;
                    case "estado":
                      if( respuesta!="" || respuesta=="Tu mensaje no esta claro" ){
                                respuesta = "Tu mensaje no esta claro";
                            }
                            else
                            {
                                respuesta = respuesta + "yo estoy bien muchas gracias, me agrada saber como te sientes";

                            }
                        break;
                    case "saludar":
                      if( respuesta!="" || respuesta=="Tu mensaje no esta claro" ){
                            respuesta = "Tu mensaje no esta claro";
                        }
                        else
                        {
                        respuesta =  "Hola soy un bot " + respuesta ;

                        }
                        break;
                    case "ubicaci_n":
                      if( respuesta!="" || respuesta=="Tu mensaje no esta claro" ){
                            respuesta = "Tu mensaje no esta claro";
                        }
                        else
                        {
                        respuesta =  "Si, tu y yo estamos en Quito"  + respuesta;

                        }
                        break;
                    case "ch_action":
                      if( respuesta!="" || respuesta=="Tu mensaje no esta claro" ){
                            respuesta = "Tu mensaje no esta claro";
                        }
                        else
                        {
                        respuesta =  "Que accion deseas hacer"  + respuesta;
                        }
                        break;
                    case "location":
                      if( respuesta!="" || respuesta=="Tu mensaje no esta claro" ){
                            respuesta = "Tu mensaje no esta claro";
                        }
                        else
                        {
                        respuesta = "yo estoy bien muchas gracias, me agrada saber como te sientes";
                        }
                        break;
                    case "nombre":
                      if( respuesta!="" || respuesta=="Tu mensaje no esta claro" ){
                            respuesta = "Tu mensaje no esta claro";
                        }
                        else
                        {
                        respuesta = respuesta + "Que lindo nombre, el mio es bot ";
                        }
                        break;
                    default:
                        respuesta = "Tu mensaje no esta claro";
                        

                        break;
                }
            }else{
                if(respuesta=="" ){
                respuesta = "Disculpa no te entendi";

                }
 
            }
            
        }

        GameObject voice = GameObject.Find ("VoiceController");
        VoiceController speech = voice.GetComponent <VoiceController> ();
        speech.StartSpeaking(respuesta);

    }
}
