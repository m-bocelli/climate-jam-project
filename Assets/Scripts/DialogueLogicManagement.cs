using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class DialogueNextButton : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Image dialogueImage;
    public AudioSource audio;
    public List<Sprite> imageList = new List<Sprite>();
    public int DialogueIndex = 0;
    public List<string> DialogueList = new List<string>();
    public List<AudioClip> audioClips = new List<AudioClip>();
    // Start is called before the first frame update




    public void OnClickNext()
    {
        if(DialogueIndex< DialogueList.Count)
        {
            dialogueText.SetText(DialogueList[DialogueIndex]);
            if (DialogueIndex< imageList.Count)
            {
                dialogueImage.sprite = imageList[DialogueIndex];

            }
            if(DialogueIndex< audioClips.Count)
            {
                audio.clip = audioClips[DialogueIndex];
                audio.Play(); 
            }
            DialogueIndex = DialogueIndex + 1;


        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
