using Eco.Core.Items;
using Eco.Gameplay.Modules;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [LocDisplayName("Arcane Upgrade")]
    [Eco.Gameplay.Items.Weight(1)]
    [Tag("Advanced Upgrade", 1)]
    public class ArcaneUpgradeItem : EfficiencyModule
    {
        public override LocString DisplayDescription => Localizer.DoStr("Advanced Upgrade that greatly increases efficiency when crafting Arcane recipes.");

        public ArcaneUpgradeItem()
            : base(ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency, 0.55f, typeof (LoggingSkill), 0.5f)
        {
        }
    }
}