using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Provider;
using SDG.Framework;
using Rocket.Core;
using SDG.Unturned;
using Rocket.Unturned.Events;
using SDG.NetTransport;
using SDG.SteamworksProvider;
using Rocket.Unturned.Permissions;
using Rocket.API.Collections;
using Rocket.Unturned.Enumerations;
using Rocket.API.Serialisation;
using UnityEngine;
using Random = System.Random;
using System.Collections;
using SDG.Framework.Utilities;
using Steamworks;

namespace HealWeapons
{
    public class Config : IRocketPluginConfiguration
    {
        public List<HealWeapons.Models.HealWeaponModel> HealWeapons = new List<Models.HealWeaponModel>();
        public void LoadDefaults()
        {
            HealWeapons.Add(new Models.HealWeaponModel(true, 10, true, 20, 100, "HealWeapon.Shooter", "HealWeapon.Victim", false, false, true, true, true, new List<EAction> { EAction.Trigger, EAction.Bolt, EAction .Break, EAction .Minigun, EAction .Pump, EAction .Rail, EAction .Rocket, EAction .String}));
        }
    }
}
