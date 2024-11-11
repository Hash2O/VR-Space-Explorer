using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PushButtonOpenDoor : MonoBehaviour
{
    public Animator animator;
    public string boolName = "Open";

    // Start is called before the first frame update
    void Start()
    {
        //x => nameOfTheFunction() prevents from using SelectEventArgs argument in the function, calling it directly
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ToggleOpenDoor());
    }

    public void ToggleOpenDoor()
    {
        bool isOpen = animator.GetBool(boolName);
        animator.SetBool(boolName, !isOpen);
    }

}
