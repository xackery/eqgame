using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ChatPanel;
    public GameObject ChatWindowText;

    public InputField ChatBox;

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
        if (ChatBox.text != "" && Input.GetKeyDown(KeyCode.Return)) {
            SendMessageToChat(ChatBox.text);    
            ChatBox.text = "";
        }

        if (!ChatBox.isFocused && Input.GetKeyDown(KeyCode.Space)) {
            SendMessageToChat("You pressed space");
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