using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GestorDeTexto : MonoBehaviour
{
    public TMP_InputField inputField;

    public void ObtenerTexto()
    {
        string palabra = inputField.text;
        // Llamar a una función para manejar el texto, por ejemplo, guardar en un archivo.
        ManejarTexto(palabra);
    }

    public void ManejarTexto(string texto)
    {
        // Ruta del archivo de texto en la carpeta "Assets".
        string rutaArchivo = "Assets/TextoGuardado.txt";

        // Añadir el texto a una nueva línea en el archivo.
        System.IO.File.AppendAllText(rutaArchivo, texto + "\n");

        Debug.Log("Texto añadido al archivo: " + texto);
    }
}
