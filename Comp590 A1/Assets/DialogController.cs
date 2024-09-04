using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [SerializeField] private GameObject titleObject;
    [SerializeField] private GameObject contentObject;
    [SerializeField] private GameObject layoutObject;
    [SerializeField] private GameObject primaryDialogOptionObject;
    [SerializeField] private GameObject secondaryDialogOptionObject;

    private DialogNode currentDialogNode;
    private int dialogSelectionIndex = 0;

    public int getDialogSelectionIndex()
    {
        return dialogSelectionIndex;
    }


    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDialogNode != null)
        {
            if (currentDialogNode is DialogChoiceNode)
            {
                primaryDialogOptionObject.GetComponent<RawImage>().color = dialogSelectionIndex == 0 ? Color.grey : Color.white;
                secondaryDialogOptionObject.GetComponent<RawImage>().color = dialogSelectionIndex == 1 ? Color.grey : Color.white;
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    dialogSelectionIndex = 1;
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    dialogSelectionIndex = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Ending");
                if (!currentDialogNode.OnEnd(this)) // not continuing
                {
                    GetComponentInParent<FirstPersonController>().SetTicking(true);
                    GetComponentInParent<InteractionController>().enabled = true;

                    this.currentDialogNode = null;

                    layoutObject.SetActive(false);
                }
            }
        }

    }

    public void PlayDialog(DialogNode dialogNode)
    {
        if (dialogNode == null)
        {
            return;
        }

        GetComponentInParent<FirstPersonController>().SetTicking(false);
        GetComponentInParent<InteractionController>().enabled = false;

        this.currentDialogNode = dialogNode;
        
        layoutObject.SetActive(true);


        titleObject.GetComponent<TextMeshProUGUI>().text = dialogNode.getSpeaker();
        contentObject.GetComponent<TextMeshProUGUI>().text = dialogNode.getText();

        if (dialogNode is DialogChoiceNode)
        {
            dialogSelectionIndex = 0;
            contentObject.GetComponent<RectTransform>().sizeDelta = new Vector3(705, 175, 0);
            contentObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(370, -645, 0);
            primaryDialogOptionObject.SetActive(true);
            secondaryDialogOptionObject.SetActive(true);
            primaryDialogOptionObject.GetComponentInChildren<TextMeshProUGUI>().text = ((DialogChoiceNode)dialogNode).getDialogOptions()[0].getText();
            secondaryDialogOptionObject.GetComponentInChildren<TextMeshProUGUI>().text = ((DialogChoiceNode)dialogNode).getDialogOptions()[1].getText();
        } else
        {
            primaryDialogOptionObject.SetActive(false);
            secondaryDialogOptionObject.SetActive(false);
            contentObject.GetComponent<RectTransform>().sizeDelta = new Vector3(950, 175, 0);
            contentObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(494, -645, 0);
        }
    }
}
