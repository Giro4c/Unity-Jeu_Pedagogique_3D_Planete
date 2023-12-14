using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StringHTMLParser
{
    private string html;
    
    public StringHTMLParser(string html)
    {
        this.html = html;
    }

    public string getHTMLContainerContent(string type, string classContainer, string id)
    {
        return Between(html, buildContainerOP(type, classContainer, id), buildContainerED(type));
    }
    
    public string Between(string str , string firstString, string lastString)
    {
        Debug.Log("First String : " + firstString);
        Debug.Log("Last String : " + lastString);
        int pos1;
        int pos2;
        if (firstString == null || firstString.Equals(""))
        {
            pos1 = 0;
        }
        else
        {
            pos1 = str.IndexOf(firstString) + firstString.Length;
        }
        Debug.Log("Position Dep : " + pos1);
        
        if (lastString == null || lastString.Equals(""))
        {
            pos2 = str.Length;
        }
        else
        {
            pos2 = str.IndexOf(lastString, pos1);
        }
        Debug.Log("Position Stop : " + pos2);

        string finalString = str.Substring(pos1, pos2 - pos1);
        return finalString;
    }

    public string buildContainerOP(string type, string classContainer, string id)
    {
        if (type == null || type.Equals("")) return null;
        string container = "<" + type;
        if (classContainer != null && ! classContainer.Equals(""))
        {
            container = container + " class=" + classContainer;
        }
        if (id != null && ! id.Equals(""))
        {
            container = container + " id=" + id;
        }

        container = container + ">";
        return container;
    }
    
    public string buildContainerED(string type)
    {
        if (type == null || type.Equals("")) return null;
        string container = "</" + type + ">";
        return container;
    }
    
}
