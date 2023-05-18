using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text2Trigger : MonoBehaviour
{
    new Collider collider;
    public GameObject Target;
    public GameObject panel;    
    //public GameObject Trap1;  
    //Renderer Obj_Renderer;
    bool first = true;

   

    
    

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        //Obj_Renderer = Target.GetComponent<Renderer>();
        //Trap1.SetActive(false);
        
        //cam2.SetActive(false);
        //Player1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider item)  //偵測碰撞進入
    {
        if (item.tag == "Player"&&first)
        {
            Debug.Log(" Through~~~~ ");
            first =false;
            panel.SetActive(true);
            
            // Canvas.SetActive(true);
            // source = word_typing_music.GetComponent<AudioSource>();
            // GetTextFromFile(textFile);
            // textIndex = 0 ;
            // StartCoroutine(SetTextUI());
            // source.Play();
            
            //Obj_Renderer.material.SetColor("_Color", Color.red); //換顏色
            //Trap1.SetActive(true);
            //CountDown = 0.3f;
        }
        //else animator.SetBool("IsReady",false);
    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log(" exit.~~~ ");
       
    }

    


}

