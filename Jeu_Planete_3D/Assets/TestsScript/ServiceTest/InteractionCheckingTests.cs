using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Script.WebData;

namespace Script.Services.Tests
{
    public class InteractionCheckingTests
    {
        private InteractionChecking interactionChecking;
        private PlayerControl[] playerControls; // Variable pour stocker les contrôles de joueur
        private WebDatabaseAccess webDatabaseAccess; // Variable pour stocker l'accès à la base de données Web

        [SetUp]
        public void SetUp()
        {
            // Créer une instance de InteractionChecking pour chaque test
            GameObject gameObject = new GameObject();
            interactionChecking = gameObject.AddComponent<InteractionChecking>();

            // Initialiser les objets nécessaires à l'exécution des méthodes de InteractionChecking
            playerControls = new PlayerControl[1]; // Simulez un tableau de contrôles de joueur pour le test

            // Instancier WebDatabaseAccess avec ScriptableObject.CreateInstance
            webDatabaseAccess = ScriptableObject.CreateInstance<WebDatabaseAccess>();

            interactionChecking.Initialize(); // Appelez la méthode d'initialisation

            // Affectez les contrôles de joueur à interactionChecking.playerControls
            interactionChecking.GetType().GetField("playerControls", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(interactionChecking, playerControls);

            // Affectez l'accès à la base de données Web à interactionChecking.linkWeb
            interactionChecking.GetType().GetField("linkWeb", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(interactionChecking, webDatabaseAccess);
        }

        [TearDown]
        public void TearDown()
        {
            // Détruire l'instance de InteractionChecking après chaque test
            Object.Destroy(interactionChecking.gameObject);
        }

        [UnityTest]
        public IEnumerator NewRestrictionsTest()
        {
            // Activer la méthode NewRestrictions avec de nouvelles restrictions
            string[] newRestrictions = new string[] { "restriction1", "restriction2" };
            interactionChecking.NewRestrictions(newRestrictions);

            // Attendre une frame simulée pour que les restrictions soient appliquées
            yield return null;

            // Vérifier que les restrictions ont été correctement définies
            Assert.AreEqual(newRestrictions, interactionChecking.restrictions);
        }

        // Ajoutez d'autres tests selon les besoins pour les autres méthodes de la classe InteractionChecking
    }
}
