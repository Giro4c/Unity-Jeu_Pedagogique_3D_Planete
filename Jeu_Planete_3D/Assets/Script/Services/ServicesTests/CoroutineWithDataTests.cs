using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Script.Services;

namespace Script.Services.Test
{
    public class CoroutineWithDataTests
    {
        [UnityTest]
        public IEnumerator CoroutineWithData_ReturnsResult()
        {
            // Crée une coroutine qui retourne un résultat après un court délai
            IEnumerator MyCoroutine()
            {
                yield return new WaitForSeconds(1f); // Attend une seconde
                yield return 42; // Renvoie le résultat 42
            }

            // Crée un objet GameObject factice pour les besoins du test
            GameObject gameObject = new GameObject("TestObject");
            MonoBehaviour dummyMonoBehaviour = gameObject.AddComponent<MonoBehaviour>();

            // Crée une instance de CoroutineWithData en utilisant l'objet GameObject factice
            CoroutineWithData<int> coroutineWithData = new CoroutineWithData<int>(dummyMonoBehaviour, MyCoroutine());

            // Attends que la coroutine soit terminée
            yield return coroutineWithData.coroutine;

            // Vérifie si le résultat est correct
            Assert.AreEqual(42, coroutineWithData.result);

            // Détruit l'objet GameObject factice
            GameObject.Destroy(gameObject);
        }
    }
}
