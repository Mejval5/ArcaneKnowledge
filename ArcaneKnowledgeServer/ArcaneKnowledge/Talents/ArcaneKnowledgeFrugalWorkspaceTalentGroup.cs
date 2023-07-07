using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [LocDisplayName("Frugal Workspace: Arcane Knowledge")]
    public class ArcaneKnowledgeFrugalWorkspaceTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription => Localizer.DoStr("Lowers the tier requirement of related tables by 0.2");

        public ArcaneKnowledgeFrugalWorkspaceTalentGroup()
        {
            this.Talents = new Type[1]
            {
                typeof (ArcaneKnowledgeFrugalReqTalent)
            };
            this.OwningSkill = typeof (ArcaneKnowledgeSkill);
            this.Level = 6;
        }
    }
}
