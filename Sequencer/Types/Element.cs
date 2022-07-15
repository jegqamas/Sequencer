namespace Sequencer
{
    class Element
    {
        /// <summary>
        /// The name and id of this element.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The current stage.
        /// </summary>
        public int CurrentStage { get; set; }
        /// <summary>
        /// How many time this element can produce.
        /// </summary>
        public int ProductionsAbilityCount { get; set; }
        /// <summary>
        /// How many stages this element can live.
        /// </summary>
        public int MaxStages { get; set; }
        /// <summary>
        /// Get or set if this element can produce or not.
        /// </summary>
        public bool CanProduce { get; set; }
        /// <summary>
        /// The stage that this element can start producing.
        /// </summary>
        public int TeenStage { get; set; }
        /// <summary>
        /// How many stages it product (not the children count, just the stages number which it have breed at)
        /// </summary>
        public int ProductionsCount { get; set; }
        /// <summary>
        /// How many children it can have in a production stage
        /// </summary>
        public int HowMuchItProduceInAStage { get; set; }
    }
}
