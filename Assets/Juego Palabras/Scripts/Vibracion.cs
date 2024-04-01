using UnityEngine;

public class Vibracion : MonoBehaviour
{
    public static Vibracion instance;

    // Duración de la vibración en segundos
    public float duracionVibracion = 0.5f;

    
    
    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        
    }

    public void Vibrar()
    {
        // Verificar si el dispositivo soporta vibración
        if (SystemInfo.supportsVibration)
        {
            // Iniciar la vibración con la duración especificada
            Handheld.Vibrate();
            // Puedes ajustar la duración de la vibración usando Handheld.Vibrate()
            // Por ejemplo, para vibrar durante 1 segundo: Handheld.Vibrate();
            // Para vibrar durante 0.5 segundos (como en este ejemplo): Handheld.Vibrate();
            // Ten en cuenta que la duración real puede variar según el dispositivo.
        }
        else
        {
            Debug.LogWarning("El dispositivo no admite vibración.");
        }
    }
}
