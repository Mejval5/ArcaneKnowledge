using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [LocDisplayName("Parallel Processing: Arcane Knowledge")]
    public class ArcaneKnowledgeParallelProcessingTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription => Localizer.DoStr("Increases the crafting speed of related tables when they share a room with the same tables by 20 percent.");

        public ArcaneKnowledgeParallelProcessingTalentGroup()
        {
            this.Talents = new Type[1]
            {
                typeof (ArcaneKnowledgeParallelSpeedTalent)
            };
            this.OwningSkill = typeof (ArcaneKnowledgeSkill);
            this.Level = 3;
        }
    }
}