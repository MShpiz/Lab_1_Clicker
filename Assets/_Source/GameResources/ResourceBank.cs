using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameResources
{
    
    public class ResourceBank
    {
        private Dictionary<GameResource, ObservableInt> _resources = new Dictionary<GameResource, ObservableInt>();

        void ChangeResource(GameResource r, int v)
        {
            _resources[r].Value = v;
        }

        ObservableInt GetResource(GameResource r)
        {
            return _resources[r];
        }
    }
}
