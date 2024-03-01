using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public interface TypedIdentifiable
{

    public string GetIdentifier();

    public bool MatchRegex(string[] identifiers)
    {
        foreach (string identifier in identifiers)
        {
            if (!GetIdentifier().Contains(identifier)) return false;
        }

        return true;
    }
    public static bool MatchRegex(string id, string[] identifiers)
    {
        foreach (string identifier in identifiers)
        {
            if (!id.Contains(identifier)) return false;
        }

        return true;
    }
    
}
