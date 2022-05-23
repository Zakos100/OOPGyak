
namespace myinterface
{
    /*

     */
    public interface ITaxable
    {
        int TaxPercent { get; set; }
        double GetTaxedValue();
        double GetTax();
    }
}
