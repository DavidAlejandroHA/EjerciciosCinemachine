using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovementControllerBlendTree2D : MonoBehaviour
{
    public float speed = 5.0f; // La velocidad a la que se va a mover el personaje
    public float rotationSpeed = 100.0f; // Speed of rotation
    private CharacterController characterController;
    private Animator animatorController;
    public CinemachineVirtualCamera camaFrente;
    public CinemachineVirtualCamera camaArriba;
  

    void Start()
    {
   
        // Get the Character Controller on the player
        characterController = GetComponent<CharacterController>();
        animatorController = GetComponent<Animator>();
        //GetComponent<CinemachineBrain>().
    }

    void Update()
    {
      //Pillamos input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        // Nos movemos eje x + eje z
        if(animatorController.GetFloat("OC") != 1f)
        {
            Vector3 move = transform.forward * vertical + transform.right * horizontal;
            characterController.Move(move * speed * Time.deltaTime);
        }


        
        animatorController.SetFloat("Velocidad x", horizontal);
        animatorController.SetFloat("Velocidad z", -vertical);

        if(Input.GetKeyDown(KeyCode.O)) animatorController.SetFloat("OC", 1f);

        if (Input.GetKeyDown(KeyCode.Escape)) animatorController.SetFloat("OC", 0f);


        if (Input.GetKeyDown(KeyCode.P)) changeCamera();

    }

    public void changeCamera()
    {
        if (camaArriba.Priority == 0)
        {
            camaArriba.Priority = 1;
            camaFrente.Priority = 0;
        }
        else
        {
            camaArriba.Priority = 0;
            camaFrente.Priority = 1;
        }
    }
}
