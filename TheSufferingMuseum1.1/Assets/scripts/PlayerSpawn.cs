using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

    private PlayerController thePlayer;
    private GameObject player;
    private CameraController theCamera;
    public Vector2 startDir;

    public string spawnName;
    private AudioSource sound;

    bool start = true;
    // Para controlar si la transición es de entrada o salida
    bool isFadeIn = true;
    // Opacidad inicial del cuadrado de transición
    float alpha = 1;
    // Transición de 1 segundo
    float fadeTime = 0.5f;

    // Use this for initialization
    IEnumerator Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        thePlayer = FindObjectOfType<PlayerController>();

        sound = GetComponent<AudioSource>();

        if (thePlayer.spawnName == spawnName) {
        
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<PlayerController>().enabled = false;
            
            thePlayer.transform.position = transform.position;
            
            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x,
                transform.position.y, theCamera.transform.position.z);

            sound.Play();
        }
        //thePlayer.setLastMove(startDir);
        thePlayer.setMov(startDir);

        FadeOut();
        yield return new WaitForSeconds(fadeTime);

        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;
    }
    void OnGUI()
    {

        // Si no empieza la transición salimos del evento directamente
        if (!start)
            return;

        // Si ha empezamos creamos un color con una opacidad inicial a 0
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        // Creamos una textura temporal para rellenar la pantalla
        Texture2D tex;
        tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.black);
        tex.Apply();

        // Dibujamos la textura sobre toda la pantalla
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);

        // Controlamos la transparencia
        if (isFadeIn)
        {
            // Si es la de aparecer le sumamos opacidad
            alpha = Mathf.Lerp(alpha, 1.1f, fadeTime * Time.deltaTime);
        }
        else
        {
            // Si es la de desaparecer le restamos opacidad
            alpha = Mathf.Lerp(alpha, -0.1f, fadeTime * Time.deltaTime);
            // Si la opacidad llega a 0 desactivamos la transición
            if (alpha < 0) start = false;
        }

    }

    // Método para activar la transición de entrada
    void FadeIn()
    {
        start = true;
        isFadeIn = true;
    }

    // Método para activar la transición de salida
    void FadeOut()
    {
        isFadeIn = false;
    }
}
