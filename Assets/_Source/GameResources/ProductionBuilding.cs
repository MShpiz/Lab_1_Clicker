using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace GameResources {
    public class ProductionBuilding : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] public GameResource resource;
        [SerializeField] public GameResource productionLevelType;
        [SerializeField] public uint productionTime = 10;

        private Button _btn;
        private GameManager _manager;

#nullable enable
        private ResourceProgress? _progressBar = null;
#nullable disable

        void Awake()
        {
            _btn = GameObject.Find(this.name).GetComponent<Button>();

            try
            {
                _progressBar = _btn.transform.GetChild(1).GetComponent<ResourceProgress>();
            }
            catch (UnityException e)
            {
                Debug.LogError($"Progress bar exception: {e.Message}, btn {this.name}");
                _progressBar = null;
            }
            
            

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
            if (_progressBar != null)
            {
                StartCoroutine(_progressBar.StartProgress(productionTime * (1 - (float)_manager._bank.GetResource(productionLevelType).Value / 100)));
            }
            
            yield return new WaitForSeconds(productionTime * (1 - (float)_manager._bank.GetResource(productionLevelType).Value / 100));
            _manager._bank.ChangeResource(resource, _manager._bank.GetResource(resource).Value + 1);
            if (!_btn.interactable)
            {
                _btn.interactable = true;
            }
        }
    }
}
