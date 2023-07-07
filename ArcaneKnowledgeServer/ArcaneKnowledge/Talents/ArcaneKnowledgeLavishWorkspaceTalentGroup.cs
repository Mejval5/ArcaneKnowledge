using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [LocDisplayName("Lavish Workspace: Arcane Knowledge")]
    public class ArcaneKnowledgeLavishWorkspaceTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription => Localizer.DoStr("Increases the tier requirement of tables by 0.2, but reduces the resources needed by 5 percent.");

        public ArcaneKnowledgeLavishWorkspaceTalentGroup()
        {
            this.Talents = new Type[2]
            {
                typeof (ArcaneKnowledgeLavishResourcesTalent),
                typeof (ArcaneKnowledgeLavishReqTalent)
            };
            this.OwningSkill = typeof (ArcaneKnowledgeSkill);
            this.Level = 6;
        }
    }
}