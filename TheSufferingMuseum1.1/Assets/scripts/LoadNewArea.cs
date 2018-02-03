using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

    public string levelToLoad;
    private bool interactFlag;
    private GameObject player;
    private AudioSource sound;
    public string exitName;

    // Para controlar si empieza o no la transición
    bool start = false;
    // Para controlar si la transición es de entrada o salida
    bool isFadeIn = false;
    // Opacidad inicial del cuadrado de transición
    float alpha = 0;
    // Transición de 1 segundo
    float fadeTime = 0.5f;
   
    void Start () {
        interactFlag = false;
        player = GameObject.FindGameObjectWithTag("Player");
        sound = GetComponent<AudioSource>();
        if (player == null)
        {
            Debug.LogError("No player found");
        }
	}
    IEnumerator OnTriggerEnter2D(Collider2D other) { 
    
        if (other.tag == "Player") 
        {
            //if (Input.GetButton("Fire1")) {
            FadeIn();
            other.GetComponent<Animator>().enabled = false;
            other.GetComponent<PlayerController>().enabled = false;
            other.GetComponent<PlayerController>().spawnName = exitName;

            sound.Play();

            yield return new WaitForSeconds(fadeTime);

            //FadeOut();

            other.GetComponent<Animator>().enabled = true;
            other.GetComponent<PlayerController>().enabled = true;

            interactFlag = true;
            //player.GetComponent<GridMovement>().setMoving(false);
            //player.GetComponent<GridMovement>().setCanMove(true);
            SceneManager.LoadScene(levelToLoad);
            //}
        }
    }
    // Dibujaremos un cuadrado con opacidad encima de la pantalla simulando una transición
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


    //get set
    public bool getInteractFlag()
    {
        return interactFlag;
    }
    public void setInteractFlag(bool flag)
    {
        interactFlag = flag;
    }
}
