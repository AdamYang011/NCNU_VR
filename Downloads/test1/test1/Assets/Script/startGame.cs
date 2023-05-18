using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startGame : MonoBehaviour
{
    public GameObject Background_music, Buttom_click_music;
    // Start is called before the first frame update
    IEnumerator Delay(AudioSource music)
    {
        yield return new WaitUntil(() => { return !music.isPlaying; });
        SceneManager.LoadScene(1);
    }

    public void start()
    {
        //SceneManager.LoadScene(1);
        AudioSource source = Background_music.GetComponent<AudioSource>();
        AudioSource source2 = Buttom_click_music.GetComponent<AudioSource>();
        source.Stop(); 
        source2.Play();
        StartCoroutine(Delay(source2)); ;
    }
    
}
