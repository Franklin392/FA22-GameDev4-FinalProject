using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public float speed;
    public float angle;
    public float Lean;

    
    void LateUpdate() //每一帧，先update，然后是animation，之后才是lateupdate 
    {   
        Lean = Mathf.Sin(Time.time * speed);

        transform.Rotate(Vector3.left * Lean * angle, Space.Self);
        transform.Rotate(Vector3.up * Lean * angle, Space.Self);


        
        //Space:changing self mode or Local mode
        //UP left right// Sin give -1 to 1, *60 让他变更大角度//up and down// 5.0f = how fast   60.f= 范围 （-60-  +60）LIKE MOVING ANGLE

        //transform.Rotate(Vector3.up * Mathf.sin(Time.time * speed) * angle, Space.Self);
        //批注：  这里的UP可以改foward 前后变左右，Sin 这里是三角函数，从-1到1上下反复横跳，speed 是他反复横跳的速度， angle是他上下反复横跳的角度,Space.self 指的是让他自己动，就他按照自己的那个rotate 三色动
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
