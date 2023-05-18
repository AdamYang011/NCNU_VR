using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MsgSystem1 : MonoBehaviour
{
    // public GameObject cam1, cam2;
    // public GameObject Player1,light1;

    [Header("UI組件")]
    public Text textLabel;
    

    [Header("文本資料")]
    public TextAsset textFile;
    public int textIndex;
    public float textSpeed=0.1f;

    
    [Header("打字聲")]
    public GameObject word_typing_music;
    AudioSource source;

    // [Header("頭像")]
    // public Sprite face01;

    bool textFinish;

    List<string> textList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        source = word_typing_music.GetComponent<AudioSource>();
        GetTextFromFile(textFile);
        textIndex = 0 ;
        StartCoroutine(SetTextUI());
        source.Play();
        //cam2.SetActive(false);
        //Player1.SetActive(false);
       
        //textFinish = true;
        
    }

    // Update is called once per frame
    // void onEable()
    // {
    //     // textLabel.text = textList[textIndex];
    //     // textIndex++;
        
    // }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&textIndex == textList.Count)
        {
            // cam1.SetActive(false);
            // light1.SetActive(false);
            // Player1.SetActive(true);
            //cam2.SetActive(true);
            
            SceneManager.LoadScene(2);
            gameObject.SetActive(false);
            
            textIndex =0 ;
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space)&&textFinish)
        {
            
            // textLabel.text = textList[textIndex];
            // textIndex++;

            StartCoroutine(SetTextUI());
            
        }
        
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        textIndex =0;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            textList.Add(line);
        }

    }
    IEnumerator SetTextUI()
    {
        source.UnPause();
        textFinish = false;
        if(textList[textIndex]=="\r")
            textLabel.text ="";
        else
            textLabel.text +="\n";
        //textList[textIndex]="A";
        // switch(textList[textIndex])
        // {
            
        //     case "A\r":
        //         faceImage.sprite = face01;
        //         textIndex++;
        //         Debug.Log("change!!!!!!!!!!!");
        //         break;
        //     case "B\r":
        //         faceImage.sprite = face01;
        //         textIndex++;
        //         break;
        //     default:
        //         Debug.Log(textList[textIndex]);
        //         Debug.Log("default!!!!!!!!!!!");
        //         break;
        // }
        for(int i =0;i<textList[textIndex].Length;i++)
        {
            textLabel.text += textList[textIndex][i];

            yield return new WaitForSeconds(textSpeed);

        }
        source.Pause();
        textFinish = true;
        textIndex ++;
    }
}
