using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace GameResources {
    public class ProductionBuilding : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] public GameResource resource;

        private Button _btn;
        private GameManager _manager;
        void Awake()
        {
            _btn = GameObject.Find(this.name).GetComponent<Button>();
            _manager = GameObject.Find("ResourceVisual").GetComponent<GameManager>();

            _btn.onClick.AddListener(() => _manager._bank.ChangeResource(resource, _manager._bank.GetResource(resource).Value + 1));
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDestroy()
        {
            _btn.onClick.RemoveAllListeners();
        }
    }
}
