using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask; //ʹ��layer ���ж�����ѡ��Ҫ������layer��ǩ��interaction

    private PlayerUI playerUI;
    public InputManager inputManager;
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;

        playerUI = GetComponent<PlayerUI>();

        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward); //Create a ray at the center of camera,shooting outwards
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo;// variable to store our collision information;

        if(Physics.Raycast(ray,out hitInfo,distance,mask))//only run when raycast hit something
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null) //���������һ����interactable tag�Ķ���
            {
                Debug.Log(hitInfo.collider.GetComponent<Interactable>().promptMessage);


                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage); //���������Ժ���ʾdebug ����

                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

                //if(inputManager.OnFoot.Interact.triggered)
                if (inputManager.onFoot.Interact.triggered) //�����ʱ�򰴼�
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}