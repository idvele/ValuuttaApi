namespace ValuuttaApi.Models;

public class Valuutta{
    
    public Guid ID { get; set; }         
    public string Currency { get; set; }
    public double Rate { get; set; }

    
}
//sivuuta deault builderi customilla jossa ID valmiiksi