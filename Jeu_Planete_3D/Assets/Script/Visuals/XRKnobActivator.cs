using System;
using Unity.VRTemplate;
using UnityEngine;

namespace Script.Visuals
{
    public class XRKnobActivator : MonoBehaviour, IdentifiableRestrictable
    {
        // Interface implementation ---------------
        [SerializeField] protected string identifier = "None";
        public bool activationRestricted { get; set; } = false;
        [SerializeField] private bool _defaultActivation = false;
    
        public void Activate(bool activation)
        {
            enabled = activation;
        }

        public string GetIdentifier()
        {
            return identifier;
        }

        public bool MatchRegex(string[] identifiers)
        {
            return IdentifiableRestrictable.MatchRegex(GetIdentifier(), identifiers);
        }

        public bool GetDefaultActivation()
        {
            return _defaultActivation;
        }

        // ----------------------------------------------

        [SerializeField] private XRKnob _xrKnob;

        private void OnEnable()
        {
            if (activationRestricted)
            {
                enabled = false;
                return;
            }

            _xrKnob.enabled = true;
        }

        private void OnDisable()
        {
            _xrKnob.enabled = false;
        }
    }
}