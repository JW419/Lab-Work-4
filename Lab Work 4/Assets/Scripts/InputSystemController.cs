using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{
    public GameObject laserPrefab;
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void HandleMovement(InputAction.CallbackContext Context)
    {
        print (Context.phase);
        
        if (Context.performed)
        {
            print ("Movement performed");
        }
        else if (Context.started)
        {
            print("Movement started");
        }
        else if (Context.canceled)
        {
            print("Movement canceled");
        }
    }
    public void HandleAttack(InputAction.CallbackContext context)
    {
        print (context.phase);
        
        if (context.performed)
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            audioSource.Play();
            print ("Attack performed");
        }
        else if (context.started)
        {
            print("Attack started");
        }
        else if (context.canceled)
        {
            print("Attack canceled");
        }
    }

}
