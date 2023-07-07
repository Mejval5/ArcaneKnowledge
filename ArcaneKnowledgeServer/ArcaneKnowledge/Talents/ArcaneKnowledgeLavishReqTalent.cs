using Eco.Shared.Serialization;
using System;


#nullable enable
namespace Eco.Mods.TechTree
{
    [Serialized]
    public class ArcaneKnowledgeLavishReqTalent : LavishWorkspaceTalent
    {
        public override bool Base => false;

        public override Type TalentGroupType => typeof (ArcaneKnowledgeLavishWorkspaceTalentGroup);

        public ArcaneKnowledgeLavishReqTalent() => this.Value = 0.2f;
    }
}