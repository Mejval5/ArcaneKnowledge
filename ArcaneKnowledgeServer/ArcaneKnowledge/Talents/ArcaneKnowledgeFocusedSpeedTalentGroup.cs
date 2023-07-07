using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using System;

namespace Eco.Mods.TechTree
{
    [LocDisplayName("Focused Workflow: Arcane Knowledge")]
    public class ArcaneKnowledgeFocusedSpeedTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public ArcaneKnowledgeFocusedSpeedTalentGroup()
        {
            this.Talents = new Type[1]
            {
                typeof (ArcaneKnowledgeFocusedSpeedTalent)
            };
            this.OwningSkill = typeof (ArcaneKnowledgeSkill);
            this.Level = 3;
        }
    }
}
