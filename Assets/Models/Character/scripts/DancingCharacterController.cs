using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DancingCharacterController : MonoBehaviour
{

    private Animator animator;

    private int currentAnimation = -1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        animator = gameObject.GetComponent<Animator>();
        switch (SceneManager.GetActiveScene().name)
        {
            case "Menu":

                break;
            case "Gameplay":
                ActivateAnimation(CustomSceneManager.characterInfo.currentAnimation);
                break;
        }
    }

    public void ActivateAnimation(int Id)
    {
        if(Id != currentAnimation)
        {
            Debug.Log("Activando animación " + Id);
            switch (Id)
            {
                case 0:
                    animator.SetTrigger("House");
                    break;
                case 1:
                    animator.SetTrigger("Wave");
                    break;
                case 2:
                    animator.SetTrigger("Macarena");
                    break;
            }
            currentAnimation = Id;
            CustomSceneManager.characterInfo.currentAnimation = Id;
        }
        else
        {
            Debug.Log("Animación " + Id + " ya activa");
        }
    }
}
