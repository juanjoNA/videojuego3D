using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    private Vector3 movement = new Vector3(1, 1, 0);
    Rigidbody rb;
    float timeFromPreviousMove;
    private Vector3 controlPos;
    private ActivateControlPoint scriptActivation;
    public int speed;
    private ChangeScenes csManager;
    private int room = 0;
    private bool exit = false;

    private void Update()
    {
        timeFromPreviousMove += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timeFromPreviousMove > 0.2f)
        {
            movement.y = -movement.y;
            timeFromPreviousMove = 0.0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "wall" || collision.collider.tag == "palette")
        {
            Vector3 side = collision.contacts[0].normal;
            if(side == transform.up) movement.y = 1;
            else if( side == -transform.up) movement.y = -1;
            else if( side == transform.right)  movement.x = 1;
            else if( side == -transform.right) movement.x = -1;
            
        }else if(collision.collider.tag == "enemy")
        {
            movement = new Vector3(0, 0, 0);
            Animation anim = collision.collider.gameObject.GetComponent<Animation>();
            if (anim != null && !anim.isPlaying)
            {
                anim.Play();
                while (anim.isPlaying) ;
            }

            /**Recorrer array de puntos de control para ver donde lo posiciono.
             * Crear un array de puntos de control
             * Recorrer el array del final hacia delante
             * Añadir una transicion suave entre que cargo la escena y no.
             */
            StartCoroutine("restart");
        }
        else if(collision.collider.tag == "win")
        {
            Debug.Log("entro en COLLISION WIN");
            movement = new Vector3(0, 0, 0);
            Animator animator = collision.collider.gameObject.GetComponent<Animator>();
            /*if (animator != null)
            {
                animator.Play("openChest");
                while (animator.GetCurrentAnimatorStateInfo()) ;
            }*/
            SceneManager.LoadScene("PruebaWinScene");
        }
        else if(collision.collider.tag == "controlPoint")
        {
            controlPos = collision.collider.transform.position;
            collision.collider.gameObject.GetComponent<ActivateControlPoint>().StartCoroutine("activate");
            collision.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cameraPoint" && !exit) exit = true;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "cameraPoint" && exit)
        {
            int num = int.Parse(other.name.Substring(other.name.Length - 1));
            if (room == num) room--;
            else if (room < num) room++;
            exit = false;
        }
    }


    private void FixedUpdate()
    {
        transform.Translate(movement * speed * Time.deltaTime);
    }

    private void Awake()
    {
        timeFromPreviousMove = 0.0f;
        rb = GetComponent<Rigidbody>();
        controlPos = transform.position;
    }

    IEnumerator restart()
    {
        gameObject.transform.position = controlPos;
        yield return new WaitForSeconds(1);
        movement = new Vector3(1, 1, 0);
    }

    public int getRoom()
    {
        return room;
    }
}
