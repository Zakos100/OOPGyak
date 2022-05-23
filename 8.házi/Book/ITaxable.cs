namespace myinterface
{
    /*
     Készítsen új névtérben (myinterface) adóztatható (ITaxable) interfészt.
    Metódusai: getter, setter tulajdonságok az áfakulcshoz (TaxPercent), 
    a double típusú adót kiszámító absztrakt metódus (GetTax()), 
    és a double típusú adóval terhelt értéket kiszámító absztrakt metódus (GetTaxedValue())
     */
    interface ITaxable
    {
        int TaxPercent { get; set; }
        double GetTaxedValue();
        double GetTax();
    }
}
