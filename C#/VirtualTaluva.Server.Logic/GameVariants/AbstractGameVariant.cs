using System.Collections.Generic;
using System.Reflection;
using VirtualTaluva.Protocol.DataTypes.Attributes;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes;
using VirtualTaluva.Server.DataTypes.Attributes;
using VirtualTaluva.Server.DataTypes.EventHandling;
using Com.Ericmas001.Common;

namespace VirtualTaluva.Server.Logic.GameVariants
{
    public class EvaluationParams
    {
        
    }
    public abstract class AbstractGameVariant
    {
        protected virtual int NbCardsInHand => 2;
        public virtual EvaluationParams EvaluationParms => new EvaluationParams();

        public abstract IEnumerable<IGameModule> GetModules(PokerGameObserver o, PokerTable table); 

        private AbstractDealer m_Dealer;
        public AbstractDealer Dealer => m_Dealer ?? (m_Dealer = GenerateDealer());
        
        protected virtual AbstractDealer GenerateDealer()
        {
            return new Shuffled52CardsDealer();
        }

        public GameSubTypeEnum Variant
        {
            get
            {
                var att = GetType().GetCustomAttribute<GameVariantAttribute>();
                if (att != null)
                    return att.Variant;
                return GameSubTypeEnum.TexasHoldem;
            }
        }

        public GameTypeEnum GameType
        {
            get
            {
                var att = Variant.GetAttribute<GameTypeAttribute>();
                if (att != null)
                    return att.GameType;
                return GameTypeEnum.CommunityCardsPoker;
            }
        }
    }
}
