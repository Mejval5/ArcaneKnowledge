using Eco.Shared.Serialization;
using System;

namespace Eco.Mods.TechTree
{
    [Serialized]
    public class ArcaneKnowledgeFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base => false;

        public override Type TalentGroupType => typeof (ArcaneKnowledgeFocusedSpeedTalentGroup);

        public ArcaneKnowledgeFocusedSpeedTalent() => this.Value = 0.5f;
    }
}
