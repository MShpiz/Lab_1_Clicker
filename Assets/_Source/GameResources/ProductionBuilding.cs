using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace GameResources {
    public class ProductionBuilding : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] public GameResource resource;
        private uint _productionTime = 10;

        private Button _btn;
        private GameManager _manager;
        private ResourceProgress _progressBar;
        void Awake()
        {
            _btn = GameObject.Find(this.name).GetComponent<Button>();
            
            _progressBar = _btn.transform.GetChild(1).GetComponent<ResourceProgress>();
            

            _manager = GameObject.Find("ResourceVisual").GetComponent<GameManager>();

            _btn.onClick.AddListener(ClickTask);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDestroy()
        {
            _btn.onClick.RemoveAllListeners();
        }

        private void ClickTask()
        {
            if (!_btn.interactable)
            {
                return;
            }
            _btn.interactable = false;
            StartCoroutine(MakeResource());
        }

        private IEnumerator MakeResource()
        {
            StartCoroutine(_progressBar.StartProgress(_productionTime));
            yield return new WaitForSeconds(_productionTime);
            _manager._bank.ChangeResource(resource, _manager._bank.GetResource(resource).Value + 1);
            if (!_btn.interactable)
            {
                _btn.interactable = true;
            }
        }
    }
}
