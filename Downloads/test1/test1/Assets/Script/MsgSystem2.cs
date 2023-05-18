using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgSystem2 : MonoBehaviour
{
    public GameObject cam1, cam2;
    public GameObject Player1,light1;
    public GameObject roadPeople;

    [Header("UI組件")]
    public Text textLabel;
    public Image faceImage;
    public Text nameLabel;

    [Header("文本資料")]
    public TextAsset textFile;
    //public TextAsset textFile2;
    public int textIndex;
    public float textSpeed=0.01f;

    [Header("頭像")]
    public Sprite face01;
    public Sprite face02;
    public Sprite face03;
    public Sprite face04;
    public Sprite face05;
    public Sprite face06;

    [Header("打字聲")]
    public GameObject word_typing_music;
    AudioSource source;



    bool textFinish;
    //int textCount =0;

    List<string> textList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //textCount++;
        source = word_typing_music.GetComponent<AudioSource>();

        
        GetTextFromFile(textFile);
        //GetTextFromFile(textFile2);

        textIndex = 0 ;
        StartCoroutine(SetTextUI());
        source.Play();
        //cam2.SetActive(false);
        
        Player1.SetActive(false);
       
        
        
    }

    // Update is called once per frame
    // void onEable()
    // {
    //     // textLabel.text = textList[textIndex];
    //     // textIndex++;
        
    // }
    void Update()
    {
        if(textIndex==22)
        {
            roadPeople.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Space)&&textIndex == textList.Count)
        {
            cam1.SetActive(false);
            light1.SetActive(false);
            Player1.SetActive(true);
            //cam2.SetActive(true);
           
            gameObject.SetActive(false);
            textList.Clear();
            textIndex =0 ;
            source.Stop();
            //Canvas.SetActive(false);
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
        textLabel.text ="";
        //textList[textIndex]="A";
        switch(textList[textIndex])
        {
            
            case "女友\r":
                faceImage.sprite = face01;
                textIndex++;
                nameLabel.text="女友";
                //Debug.Log("change!!!!!!!!!!!");
                break;
            case "金金\r":
                faceImage.sprite = face02;
                textIndex++;
                nameLabel.text="金金";
                break;
            case "主角\r":
                faceImage.sprite = face03;
                textIndex++;
                nameLabel.text="主角";
                break;
            case "路人學長\r":
                faceImage.sprite = face04;
                textIndex++;
                nameLabel.text="路人學長";
                break;
            case "路人學弟\r":
                faceImage.sprite = face05;
                textIndex++;
                nameLabel.text="路人學弟";
                break;
            case "路人學妹\r":
                faceImage.sprite = face06;
                textIndex++;
                nameLabel.text="路人學妹";
                break;
            default:
                Debug.Log(textList[textIndex]);
                //Debug.Log("default!!!!!!!!!!!");
                break;
        }
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
