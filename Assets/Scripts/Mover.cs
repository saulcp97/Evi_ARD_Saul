using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Mover: MonoBehaviour {
	public float speed = 5.0f;
    public float turnSpeed = 5.0f;
    AudioSource audioSource;
    //Solo esta en publico para poder usarlo en el inspector
    public bool isMoving = false;
   // Start is called before the first frame update
    void Start() {
        //Obtener el gameObject hijo llamado footsteps
        GameObject footsteps = transform.Find("footsteps").gameObject;
        //Obtener el componente AudioSource del gameObject footsteps
        audioSource = footsteps.GetComponent<AudioSource>();
        //El clip de audio que se va a reproducir es el que se encuentra en la carpeta usedSounds
        //audioSource.clip = Resources.Load<AudioClip>("usedSounds/metalFootsteps");
    }

    // Update is called once per frame
    void Update() {
        isMoving = false;
        //Cuando se presiona la tecla W, se mueve hacia adelante en la dirección en la que esté el objeto
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            isMoving = true;
        }
        //Cuando se presiona la tecla S, se mueve hacia atrás en la dirección en la que esté el objeto
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            isMoving = true;
        }
        //Cuando se presiona la tecla A, se mueve hacia la izquierda en la dirección en la que esté el objeto
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
            isMoving = true;
        }
        //Cuando se presiona la tecla D, se mueve hacia la derecha en la dirección en la que esté el objeto
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            isMoving = true;
        }
        //Cuando se presiona la tecla Q, se rota en el eje Y en el sentido antihorario
        if (Input.GetKey(KeyCode.Q)) {
            transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
        }
        //Cuando se presiona la tecla E, se rota en el eje Y en el sentido horario
        if (Input.GetKey(KeyCode.E)) {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }

        if (audioSource.isPlaying && !isMoving) {
            audioSource.Stop();
        } else if (!audioSource.isPlaying && isMoving) {
            audioSource.Play();
        }

		//transform.position += Input.GetAxis("Horizontal") * Vector3.right * speed * Time.deltaTime +
        //Input.GetAxis("Vertical") * Vector3.forward * speed * Time.deltaTime;

        

        //transform.position += Input.GetAxis("Vertical") * Vector3.up * speed * Time.deltaTime;
         
    }
}