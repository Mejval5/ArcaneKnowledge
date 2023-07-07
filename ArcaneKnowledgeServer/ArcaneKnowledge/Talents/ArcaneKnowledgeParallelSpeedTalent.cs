using Eco.Shared.Serialization;
using System;


#nullable enable
namespace Eco.Mods.TechTree
{
    [Serialized]
    public class ArcaneKnowledgeParallelSpeedTalent : ParallelProcessingTalent
    {
        public override bool Base => false;

        public override Type TalentGroupType => typeof (ArcaneKnowledgeParallelProcessingTalentGroup);

        public ArcaneKnowledgeParallelSpeedTalent() => this.Value = 0.8f;
    }
}