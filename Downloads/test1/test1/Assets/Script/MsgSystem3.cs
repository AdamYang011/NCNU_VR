using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgSystem3 : MonoBehaviour
{

    public GameObject roadPeople;
    public GameObject friend;
    public GameObject ghost;

    public GameObject candle1;
    public GameObject candle2;
    public GameObject candle3;
    public GameObject candle4;


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
    public Sprite face07;


    [Header("打字聲")]
    public GameObject word_typing_music;
    AudioSource source;

    [Header("腳步聲")]
    public GameObject footStep_music;
    AudioSource source2;

    [Header("吹蠟燭聲")]
    public GameObject blow_music;
    AudioSource source3;

    [Header("尖叫聲")]
    public GameObject scream_music;
    AudioSource source4;

    [Header("時間聲")]
    public GameObject tiktok_music;
    AudioSource source5;

    [Header("出場聲")]
    public GameObject show_music;
    AudioSource source6;

    [Header("笑聲")]
    public GameObject laugh_music;
    AudioSource source7;

    bool textFinish;
    //int textCount =0;

    List<string> textList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //textCount++;
        source = word_typing_music.GetComponent<AudioSource>();
        source2 = footStep_music.GetComponent<AudioSource>();
        source3 = blow_music.GetComponent<AudioSource>();
        source4 = scream_music.GetComponent<AudioSource>();
        source5 = tiktok_music.GetComponent<AudioSource>();
        source6 = show_music.GetComponent<AudioSource>();
        source7 = laugh_music.GetComponent<AudioSource>();
        
        GetTextFromFile(textFile);
        //GetTextFromFile(textFile2);

        textIndex = 0 ;
        StartCoroutine(SetTextUI());
        source.Play();
        //cam2.SetActive(false);
        
       
       
        
        
    }

    // Update is called once per frame
    // void onEable()
    // {
    //     // textLabel.text = textList[textIndex];
    //     // textIndex++;
        
    // }
    void Update()
    {
        if(textIndex==9)
            source5.Play();
        
        if(textIndex==22)
        {
            roadPeople.SetActive(true);
            source2.Play();
        }
        if(textIndex==24)
        {
            
            source2.Stop();
        }
        if(textIndex==55)
        {
            
            candle1.SetActive(true);
            candle2.SetActive(true);
            candle3.SetActive(true);
            
        }
        if(textIndex==103)
            source3.Play();

        if(textIndex==104)
            candle1.SetActive(false);
        
        if(textIndex==122)
            source3.Play();

        if(textIndex==123)
            candle2.SetActive(false);
        
        if(textIndex==166)
            source3.Play();

        if(textIndex==167)
            candle3.SetActive(false);

        if(textIndex==171)
        {
            //friend.SetActive(true);
            source4.Play();
            //source6.Play();
        }
        if(textIndex==172)
        {
            friend.SetActive(true);
            //source4.Play();
            source6.Play();
        }
        if(textIndex==217)
            source3.Play();

        if(textIndex==218)
            candle4.SetActive(false);

        if(textIndex==218)
            source7.Play();
        
        
            
        
        if(Input.GetKeyDown(KeyCode.Space)&&textIndex == textList.Count)
        {

           
            //gameObject.SetActive(false);
            textList.Clear();
            textIndex =0 ;
            source.Stop();
            ghost.SetActive(true);
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
            case "鬼\r":
                faceImage.sprite = face07;
                textIndex++;
                nameLabel.text="鬼";
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
