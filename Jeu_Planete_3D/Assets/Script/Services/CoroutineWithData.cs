using System.Collections;
using UnityEngine;

namespace Script.Services
{
    public class CoroutineWithData<T>
    {
        public Coroutine coroutine { get; private set; }
        public T result;
        private IEnumerator target;

        public CoroutineWithData(MonoBehaviour owner, IEnumerator target) {
            this.target = target;
            this.coroutine = owner.StartCoroutine(Run());
        }

        private IEnumerator Run()
        {
            object tmp = new object();
            while(target.MoveNext()) {
                tmp = target.Current;
                yield return tmp;
            }

            result = (T) tmp;
        }
        
    }
}