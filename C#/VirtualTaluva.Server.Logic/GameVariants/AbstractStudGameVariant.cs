namespace VirtualTaluva.Server.Logic.GameVariants
{
    public abstract class AbstractStudGameVariant : AbstractGameVariant
    {
        public bool NeedsBringIn { get; set; }

        public override EvaluationParams EvaluationParms => new EvaluationParams
        {
            //Selector = new OnlyHoleCardsSelector()
        };
    }
}
