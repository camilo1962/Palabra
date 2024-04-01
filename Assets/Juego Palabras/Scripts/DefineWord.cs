using UnityEngine;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System.Collections;

public class DefineWord : MonoBehaviour
{
    
    void Start()
    {
        string wordToDefine = GameManager.instance.secretWord;

        StartCoroutine(GetDefinition(wordToDefine));
    }

    IEnumerator GetDefinition(string word)
    {
        string url = "https://dle.rae.es/";

        // Crea la solicitud POST con el formulario necesario
        WWWForm form = new WWWForm();
        form.AddField("w", word);  // El campo 'w' es donde se envía la palabra

        UnityWebRequest webRequest = UnityWebRequest.Post(url, form);

        // Envía la solicitud y espera la respuesta
        yield return webRequest.SendWebRequest();

        // Verifica si hay algún error
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // Procesa los datos obtenidos
            string htmlResponse = webRequest.downloadHandler.text;

            // Extrae la definición de la respuesta HTML
            string definition = ExtractDefinition(htmlResponse);

            Debug.Log("Definición de " + word + ": " + definition);
        }
        else
        {
            // Muestra un mensaje de error en caso de problemas
            Debug.LogError("Error en la solicitud: " + webRequest.error);
        }
    }

    string ExtractDefinition(string html)
    {
        // Utiliza expresiones regulares para extraer la definición del HTML
        string pattern = @"<div class=""j"".*?>(.*?)<\/div>";
        Match match = Regex.Match(html, pattern, RegexOptions.Singleline);

        if (match.Success)
        {
            // La definición se encuentra en el primer grupo de captura
            return match.Groups[1].Value;
        }
        else
        {
            return "Definición no encontrada";
        }
    }
}
