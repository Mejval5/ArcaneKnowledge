using Eco.Shared.Serialization;
using System;


#nullable enable
namespace Eco.Mods.TechTree
{
    [Serialized]
    public class ArcaneKnowledgeLavishResourcesTalent : LavishWorkspaceTalent
    {
        public override bool Base => false;

        public override Type TalentGroupType => typeof (ArcaneKnowledgeLavishWorkspaceTalentGroup);

        public ArcaneKnowledgeLavishResourcesTalent() => this.Value = 0.95f;
    }
}