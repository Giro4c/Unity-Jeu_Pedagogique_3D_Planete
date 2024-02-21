using System;
using UnityEngine;

namespace Script.Services
{
    public class InteractionChecking : MonoBehaviour
    {

        private PlayerControl[] playerControls;
        private int indexCurrentActivatedControl = -1;
        
        public string[] restrictionsToEnable { get; private set; }
        public string[] restrictionsToDisable { get; private set; }

        private WebDatabaseAccessInterface linkWeb;

        public void NewRestrictions(string[] resEnable, string[] resDisable)
        {
            bool newRs = AreNewRestrictions(resEnable, resDisable);
            restrictionsToEnable = resEnable;
            restrictionsToDisable = resDisable;
            if (newRs)
            {
                ApplyRestrictions();
            }
        }

        private bool AreNewRestrictions(string[] resEnable, string[] resDisable)
        {
            // Verify if same size
            if (resEnable.Length != restrictionsToEnable.Length ||
                resDisable.Length != restrictionsToDisable.Length) return true;
            
            // Verify all elements identical in enable restrictions
            for (int i = 0; i < restrictionsToEnable.Length; ++i)
            {
                if (resEnable[i] != restrictionsToEnable[i]) return true;
            }
            // Verify all elements identical in disable restrictions
            for (int i = 0; i < restrictionsToDisable.Length; ++i)
            {
                if (resDisable[i] != restrictionsToDisable[i]) return true;
            }
            
            // Everything is identical
            return false;
        }
        
        public void ApplyRestrictions()
        {
            ApplyRestrictions(true, restrictionsToEnable);
            ApplyRestrictions(false, restrictionsToDisable);
        }
        
        public void ApplyRestrictions(bool enabling, string[] restrictions)
        {
            foreach (string restrictionType in restrictions)
            {
                if (restrictionType.Contains("Detector"))
                {
                    ActivationDetectorFor(enabling, restrictionType.Replace("Detector ", "").Split(" "));
                }
                else if (restrictionType.Contains("SubScript"))
                {
                    ActivationSubScriptsFor(enabling, restrictionType.Replace("SubScript ", "").Split(" "));
                }
                else
                {
                    ActivationAllFor(enabling, restrictionType.Split(" "));
                }
            }
        }
        
        public void ManageControls()
        {
            // ApplyRestrictions();
            
            if (playerControls[indexCurrentActivatedControl].IsFinished() || !playerControls[indexCurrentActivatedControl].enabled)
            {
                indexCurrentActivatedControl = -1;
                // ApplyRestrictions();
            }
            
            if (indexCurrentActivatedControl == -1)
            {
                for (int i = 0; i < playerControls.Length; ++i)
                {
                    if (!playerControls[i].activationRestricted && playerControls[i].IsTriggered() && !playerControls[i].enabled)
                    {
                        playerControls[i].Activate(true);
                        indexCurrentActivatedControl = i;
                    }
                }
            }
            
        }

        public void ResetFinishedInteractionsAndRegisterCycleToDatabaseIfPossible(bool quizzStarted)
        {
            foreach (PlayerControl control in playerControls)
            {
                if (!control.IsFinished()) continue;
                control.SetFinished(false);
                if (control.GetRegisterable() && control.GetType().IsSubclassOf(typeof(CycleInteraction)))
                {
                    StartCoroutine(linkWeb.AddInteraction(control.GetControlTypeSimplified(), ((CycleInteraction)control).GetValue(),
                        quizzStarted));
                }
                    
            }
        }

        public void ActivationDetectorFor(bool activationDetector, string[] typesRegex)
        {
            foreach (PlayerControl control in playerControls)
            {
                if (PlayerControl.MatchIdentifiers(control.GetControlType(), typesRegex))
                {
                    if (!activationDetector)
                    {
                        control.Activate(false);
                    }
                    control.activationRestricted = activationDetector;
                    
                }

            }

        }
        
        public void ActivationSubScriptsFor(bool activation, string[] typesRegex)
        {
            foreach (PlayerControl control in playerControls)
            {
                control.SetActivationRestrictions(activation, typesRegex);
                if (activation)
                {
                    control.SetActivation(true, typesRegex);
                }
        
            }
        }
        
        public void ActivationAllFor(bool activation, string[] typesRegex)
        {
            ActivationDetectorFor(activation, typesRegex);
            ActivationSubScriptsFor(activation, typesRegex);
        }
        

    }
}