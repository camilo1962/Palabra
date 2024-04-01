using UnityEngine;

public class AbrirPaginaWeb : MonoBehaviour
{
    // Define la URL que quieres abrir al hacer clic en el botón
    public string url = "https://dle.rae.es/";

    // Método que se ejecuta al hacer clic en el botón
    public void AbrirPagina()
    {
        // Abre la URL en el navegador predeterminado
        Application.OpenURL(url);
    }
}
