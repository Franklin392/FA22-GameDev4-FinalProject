using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public float speed;
    public float angle;
    public float Lean;

    
    void LateUpdate() //ÿһ֡����update��Ȼ����animation��֮�����lateupdate 
    {   
        Lean = Mathf.Sin(Time.time * speed);

        transform.Rotate(Vector3.left * Lean * angle, Space.Self);
        transform.Rotate(Vector3.up * Lean * angle, Space.Self);


        
        //Space:changing self mode or Local mode
        //UP left right// Sin give -1 to 1, *60 ���������Ƕ�//up and down// 5.0f = how fast   60.f= ��Χ ��-60-  +60��LIKE MOVING ANGLE

        //transform.Rotate(Vector3.up * Mathf.sin(Time.time * speed) * angle, Space.Self);
        //��ע��  �����UP���Ը�foward ǰ������ң�Sin ���������Ǻ�������-1��1���·���������speed ���������������ٶȣ� angle�������·��������ĽǶ�,Space.self ָ���������Լ��������������Լ����Ǹ�rotate ��ɫ��
    }
    private void Start()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            
            //Debug.Log("Got Ammo");
        }
    }
}
