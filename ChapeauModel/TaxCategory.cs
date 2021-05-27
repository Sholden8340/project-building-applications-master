namespace ChapeauModel
{
    /// <summary>
    /// A tax category.
    /// </summary>
    public class TaxCategory
    {
        /// <summary>
        /// The ID of the tax category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A human readable name for this category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The percentage of TAX that has to be payed.
        /// </summary>
        public int VAT { get; set; }
    }
}
