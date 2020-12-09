using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    Rigidbody rb;
    float timeFromPreviousMove;
    private Vector3 controlPos;
    public int speed;
    private ChangeScenes csManager;
    private Vector3 lastFrameVelocity;

    private void Update()
    {
        lastFrameVelocity = rb.velocity;
        timeFromPreviousMove += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timeFromPreviousMove > 0.2f)
        {
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);
            timeFromPreviousMove = 0.0f;
        }

    }

    void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.tag == "palette")
        {
            Bounce(collision.contacts[0].normal);
        }
        if (collision.collider.tag == "enemy")
        {
            rb.velocity = Vector3.zero;
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
            rb.velocity = Vector3.zero;
            collision.collider.gameObject.GetComponent<AnimationScript>().activarAnimacion();
            //SceneManager.LoadScene("PruebaWinScene");
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "controlPoint")
        {
            controlPos = other.transform.position;
            other.gameObject.GetComponent<ActivateControlPoint>().StartCoroutine("activate");
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void Awake()
    {
        timeFromPreviousMove = 0.0f;
        rb = GetComponent<Rigidbody>();
        controlPos = transform.position;
        rb.velocity = new Vector3(-1, 1, 0) * speed;
    }

    IEnumerator restart()
    {
        gameObject.transform.position = controlPos;
        yield return new WaitForSeconds(2);
        rb.velocity = new Vector3(-1, 1, 0) * speed;
    }

    private void Bounce(Vector3 collisionNormal)
    {
        float speed = lastFrameVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        rb.velocity = direction * speed;
    }
}
