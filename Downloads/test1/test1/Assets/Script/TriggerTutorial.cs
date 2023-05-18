using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : MonoBehaviour
{
    new Collider collider;
    public GameObject Target;  
    Renderer Obj_Renderer;
    float CountDown;
    

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        Obj_Renderer = Target.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CountDown > 0.0f)
        {
            CountDown -= Time.deltaTime;
            Debug.Log(CountDown);
            
        }

        if (CountDown < 0.0f)
        {
            Obj_Renderer.material.SetColor("_Color", Color.white);
        }
    }

    private void OnTriggerEnter(Collider item)  //偵測碰撞進入
    {
        if (item.tag == "Player")
        {
            Debug.Log(" Through~~~~ ");
            Obj_Renderer.material.SetColor("_Color", Color.red); //換顏色
            CountDown = 2.0f;
        }
        //else animator.SetBool("IsReady",false);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(" exit.~~~ ");
       
    }


}

