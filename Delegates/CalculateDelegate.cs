namespace AT_DWNBD.Delegates
{
    public delegate decimal DiscountCalculator(decimal originalPrice);

    public static class DiscountOperations
    {
        public static decimal ApplyTenPercentDiscount(decimal originalPrice)
        {
            return originalPrice * 0.90m; 
        }
    }
}