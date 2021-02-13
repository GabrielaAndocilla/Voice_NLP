using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;

public class PokeAPIController : MonoBehaviour
{
   
    [SerializeField]
    Text pokeNameText;
    JSONNode results;

    private readonly string basePokeURL = "https://api.wit.ai/message?v=20210129&q=";

    private void Start()
    {
        pokeNameText.text = "";
        results = null;
    }

    public void OnButtonRandomPokemon(string texto)
    {


        
        StartCoroutine(GetPokemonAtIndex(texto));
        
               
    }

    IEnumerator GetPokemonAtIndex(string texto)
    {
        

        string pokemonURL = basePokeURL + texto;
        pokeNameText.text = basePokeURL + texto;

        UnityWebRequest pokeInfoRequest = UnityWebRequest.Get(pokemonURL);
        pokeInfoRequest.SetRequestHeader("Authorization", "Bearer EUH2P7XTBL32WU5QO6NCXFST46MRSTIT");

        yield return pokeInfoRequest.SendWebRequest();

        if (pokeInfoRequest.isNetworkError || pokeInfoRequest.isHttpError)
        {
            Debug.Log(pokemonURL);
            Debug.LogError(pokeInfoRequest.error);
            yield break;
        }

        JSONNode pokeInfo = JSON.Parse(pokeInfoRequest.downloadHandler.text);
        
        results = pokeInfo["entities"];

        GameObject go = GameObject.Find ("Interaccion");
        Interaction speedController = go.GetComponent <Interaction> ();
        speedController.responder(results);


       
    }

    private string CapitalizeFirstLetter(string str)
    {
        return char.ToUpper(str[0]) + str.Substring(1);
    }
}
