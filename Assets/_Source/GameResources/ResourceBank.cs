using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameResources
{
    
    public class ResourceBank
    {
        private Dictionary<GameResource, ObservableInt> _resources = new Dictionary<GameResource, ObservableInt>();

        public void ChangeResource(GameResource r, int v)
        {
            if (!_resources.ContainsKey(r))
            {
                _resources[r] = new ObservableInt(v);
            }
            else
            {
                _resources[r].Value = v;
            }
        }

        public ObservableInt GetResource(GameResource r)
        {
            if (!_resources.ContainsKey(r))
            {
                _resources[r] = new ObservableInt(0);
            }
            return _resources[r];
        }
    }
}
