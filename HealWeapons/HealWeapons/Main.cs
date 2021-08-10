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
using HealWeapons.Models;

namespace HealWeapons
{
    public class Main : RocketPlugin<Config>
    {
        public static Main Instance { get; set; }
        protected override void Load()
        {
            Instance = this;
            UseableGun.onBulletHit += UseableGun_onBulletHit;
        }

        private void UseableGun_onBulletHit(UseableGun gun, BulletInfo bullet, InputInfo hit, ref bool shouldAllow)
        {
            if (!(Main.Instance.Configuration.Instance.HealWeapons.Exists(x => x.WeaponID == gun.equippedGunAsset.id) || hit.player == null))
            {
                return;
            }
            HealWeaponModel ConfigUtil = Main.Instance.Configuration.Instance.HealWeapons.Find(x => x.WeaponID == gun.equippedGunAsset.id);
            if (!(ConfigUtil.AcceptableActionTypes.Exists(q => q == gun.equippedGunAsset.action))) { return; }
            else if (ConfigUtil.ShooterNeedsPermission == true && !(UnturnedPlayer.FromPlayer(gun.player).GetPermissions().Exists(y => y.Name == ConfigUtil.ShooterNeededPermission)))
            {
                if (ConfigUtil.HasPermissionErrorMessage)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromPlayer(gun.player), Main.Instance.Translate("DontHasNescessaryPermission", ConfigUtil.ShooterNeededPermission));
                }
                ConfigUtil.ShouldHealShooter = false;
            }
            else if (ConfigUtil.VictimNeedsPermission == true && !(UnturnedPlayer.FromPlayer(hit.player).GetPermissions().Exists(y => y.Name == ConfigUtil.VictimNeededPermission)))
            {
                if (ConfigUtil.HasPermissionErrorMessage)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromPlayer(hit.player), Main.Instance.Translate("DontHasNescessaryPermission", ConfigUtil.VictimNeededPermission));
                }
                ConfigUtil.ShouldHealVictim = false;
            }
            if (ConfigUtil.CancelOriginalWeaponDamage)
            {
                shouldAllow = false;
            }
            
            if (ConfigUtil.ShouldHealShooter) { gun.player.life.ReceiveHealth((byte)(gun.player.life.health + ConfigUtil.ShooterHealAmount)); if (ConfigUtil.HasSuceesfulyHealMessage) { UnturnedChat.Say(UnturnedPlayer.FromPlayer(hit.player), Main.Instance.Translate("ShooterHealAdvice", ConfigUtil.ShooterHealAmount)); } }
            if (ConfigUtil.ShouldHealVictim)
            {
                hit.player.life.ReceiveHealth((byte)(hit.player.life.health + ConfigUtil.VictimHealAmount));
                if (ConfigUtil.HasSuceesfulyHealMessage)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromPlayer(hit.player), Main.Instance.Translate("VictimHealAdvice", ConfigUtil.VictimHealAmount));
                }
            }
        }

        protected override void Unload()
        {
            UseableGun.onBulletHit -= UseableGun_onBulletHit;
        }
        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "DontHasNescessaryPermission", "You doesn't has the nescessary permission ({0})" },
            { "ShooterHealAdvice", "You get {0} of life, for shoot in {1}!" },
            { "VictimHealAdvice", "You get {0} of life, for being shoot by {1}!" },
        };
        }
}
