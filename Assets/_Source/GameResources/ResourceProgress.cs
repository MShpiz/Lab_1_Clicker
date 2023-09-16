using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace GameResources
{

    public class ResourceProgress : MonoBehaviour
    {
        private bool _isInProgress = false;
        private  Slider _bar;


        private void Awake()
        {
            _bar = GameObject.Find(this.name).GetComponent<Slider>();
        }


        public IEnumerator StartProgress(float duration)
        {
            if (!_isInProgress)
            {
                _isInProgress = true;

                _bar.maxValue = duration;

                while (_bar.value < duration)
                {
                    _bar.value = Mathf.Min(_bar.value + Time.deltaTime, duration);
                    yield return new WaitForEndOfFrame();
                }
                _isInProgress = false;

                _bar.value = 0;
            }
        }
    }
}
