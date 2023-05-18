using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap1Trigger : MonoBehaviour
{
    new Collider collider;
    public GameObject Target;  
    public GameObject Trap1;  
    Renderer Obj_Renderer;

    float CountDown;
    

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        //Obj_Renderer = Target.GetComponent<Renderer>();
        Trap1.SetActive(false);
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
            //Obj_Renderer.material.SetColor("_Color", Color.white);
            Trap1.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider item)  //偵測碰撞進入
    {
        if (item.tag == "Player")
        {
            Debug.Log(" Through~~~~ ");
            //Obj_Renderer.material.SetColor("_Color", Color.red); //換顏色
            Trap1.SetActive(true);
            CountDown = 0.3f;
        }
        //else animator.SetBool("IsReady",false);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(" exit.~~~ ");
       
    }


}

