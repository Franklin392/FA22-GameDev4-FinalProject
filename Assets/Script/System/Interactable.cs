using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour  //allow to use sub class
{
    // Start is called before the first frame update
    public string promptMessage;

    public void BaseInteract()
    {
        Interact();
    }
  protected virtual void Interact() //每个量产模板的功能都在这里面
    {

    }
}
