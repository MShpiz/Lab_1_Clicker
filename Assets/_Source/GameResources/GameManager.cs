using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace GameResources
{

    public class GameManager : MonoBehaviour
    {
        public ResourceBank _bank = new ResourceBank();
        [SerializeField]  public TMP_Text simpleText;
        [SerializeField]  public TMP_Text prodLvlText;
        private void Awake()
        {
            _bank.ChangeResource(GameResource.Humans, 10);
            _bank.ChangeResource(GameResource.Food, 5);
            _bank.ChangeResource(GameResource.Wood, 5);

        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            simpleText.SetText($"Humans {_bank.GetResource(GameResource.Humans).Value} " +
                $"Food {_bank.GetResource(GameResource.Food).Value} " +
                $"Wood {_bank.GetResource(GameResource.Wood).Value} " +
                $"Stone {_bank.GetResource(GameResource.Stone).Value} " +
                $"Gold {_bank.GetResource(GameResource.Gold).Value}");

            prodLvlText.SetText($"Humans Lvl {_bank.GetResource(GameResource.HumansProdLvl).Value} " +
                $"Food Lvl {_bank.GetResource(GameResource.FoodProdLvl).Value} " +
                $"Wood Lvl {_bank.GetResource(GameResource.WoodProdLvl).Value} " +
                $"Stone Lvl {_bank.GetResource(GameResource.StoneProdLvl).Value} " +
                $"Gold Lvl {_bank.GetResource(GameResource.GoldProdLvl).Value}");
        }
    }
}
