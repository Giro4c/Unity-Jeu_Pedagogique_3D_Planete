using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public interface TypedIdentifiable
{

    public string GetIdentifier();

    public bool Match(string[] identifiers)
    {
        foreach (string identifier in identifiers)
        {
            if (!GetIdentifier().Contains(identifier)) return false;
        }

        return true;
    }
    
}
