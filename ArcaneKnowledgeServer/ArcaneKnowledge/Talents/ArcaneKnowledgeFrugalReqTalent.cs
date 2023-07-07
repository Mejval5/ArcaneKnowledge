using Eco.Shared.Serialization;
using System;

namespace Eco.Mods.TechTree
{
    [Serialized]
    public class ArcaneKnowledgeFrugalReqTalent : FrugalWorkspaceTalent
    {
        public override bool Base => false;

        public override Type TalentGroupType => typeof (ArcaneKnowledgeFrugalWorkspaceTalentGroup);

        public ArcaneKnowledgeFrugalReqTalent() => this.Value = -0.2f;
    }
}
