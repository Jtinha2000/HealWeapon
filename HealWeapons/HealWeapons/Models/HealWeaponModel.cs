using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealWeapons.Models
{
    public class HealWeaponModel
    {
        public bool ShouldHealVictim { get; set; }
        public int VictimHealAmount { get; set; }
        public bool ShouldHealShooter { get; set; }
        public int ShooterHealAmount { get; set; }
        public ushort WeaponID { get; set; }
        public string ShooterNeededPermission { get; set; }
        public string VictimNeededPermission { get; set; }
        public bool ShooterNeedsPermission { get; set; }
        public bool VictimNeedsPermission { get; set; }
        public bool CancelOriginalWeaponDamage { get; set; }
        public bool HasPermissionErrorMessage { get; set; }
        public bool HasSuceesfulyHealMessage { get; set; }
        public List<EAction> AcceptableActionTypes = new List<EAction>();
        public HealWeaponModel()
        {

        }

        public HealWeaponModel(bool ShouldHealVitim, int victimHealAmount, bool shouldHealShooter, int shooterHealAmount, ushort weaponID, string shooterNeededPermission, string victimNeededPermission, bool shooterNeedsPermission, bool victimNeedsPermission, bool cancelOriginalWeaponDamage, bool hasPermissionErrorMessage, bool hasSuceesfulyHealMessage, List<EAction> acceptableActionTypes)
        {
            ShouldHealVictim = ShouldHealVitim;
            VictimHealAmount = victimHealAmount;
            ShouldHealShooter = shouldHealShooter;
            ShooterHealAmount = shooterHealAmount;
            WeaponID = weaponID;
            ShooterNeededPermission = shooterNeededPermission;
            VictimNeededPermission = victimNeededPermission;
            ShooterNeedsPermission = shooterNeedsPermission;
            VictimNeedsPermission = victimNeedsPermission;
            CancelOriginalWeaponDamage = cancelOriginalWeaponDamage;
            HasPermissionErrorMessage = hasPermissionErrorMessage;
            HasSuceesfulyHealMessage = hasSuceesfulyHealMessage;
            AcceptableActionTypes = acceptableActionTypes;
        }
    }
}
