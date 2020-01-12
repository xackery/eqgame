using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ChatPanel;
    public GameObject ChatWindowText;

    public InputField ChatBox;

    bool isChatBoxRecentlyDeactivated;
    int maxMessages = 25;


    [SerializeField]
    List<Message> messages = new List<Message>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!isChatBoxRecentlyDeactivated && Input.GetKeyDown(KeyCode.Return) && !ChatBox.isFocused) {
            ChatBox.ActivateInputField();
            //ChatBox.Select();
            return;
        }
        if (isChatBoxRecentlyDeactivated) isChatBoxRecentlyDeactivated = false;
    }

    public void OnChatMessage() 
    {
        if (ChatBox.text != "") {
            SendMessageToChat(ChatBox.text);    
            ChatBox.text = "";
            ChatBox.DeactivateInputField();
            isChatBoxRecentlyDeactivated = true;
            return;
        }
        if (ChatBox.text == "") {
            ChatBox.DeactivateInputField();
            isChatBoxRecentlyDeactivated = true;
            return;
        }

    }

    public void SendMessageToChat(string text) 
    {
        if (messages.Count >= maxMessages) 
        {
            Destroy(messages[0].textObject.gameObject);
            messages.Remove(messages[0]);
        }
        Message msg = new Message();
        msg.text = text;

        GameObject txt = Instantiate(ChatWindowText, ChatPanel.transform);
        msg.textObject = txt.GetComponent<Text>();
        msg.textObject.text = msg.text;

        messages.Add(msg);
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;

}