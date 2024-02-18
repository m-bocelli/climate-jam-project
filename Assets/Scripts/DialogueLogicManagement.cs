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
    public List<Sprite> imageList = new List<Sprite>();
    public int DialogueIndex = 0;
    public List<string> DialogueList = new List<string>();
    // Start is called before the first frame update




    public void OnClickNext()
    {
        if(DialogueIndex< DialogueList.Count)
        {
            dialogueText.SetText(DialogueList[DialogueIndex]);
            DialogueIndex = DialogueIndex + 1;
            if (DialogueIndex< imageList.Count)
            {
                dialogueImage.sprite = imageList[DialogueIndex];

            }


        }
        else{
            SceneManager.LoadScene(2);
        }
    }
}
