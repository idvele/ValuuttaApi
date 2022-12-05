using ValuuttaApi.Models;
using System.Collections;
using System.Linq;

namespace ValuuttaApi.Services;

public static class ValuuttaService{

    static List<Valuutta> Rates {get;}

    static ValuuttaService(){
        Rates = new List<Valuutta>{
            new Valuutta{ID=Guid.NewGuid(), Currency= "EUR", Rate= 0.949115},
            new Valuutta{ID=Guid.NewGuid(), Currency= "GBP", Rate= 0.816527},

        };
    }
    public static List<Valuutta> GetAll() => Rates;
    public static Valuutta? Get (string Currency) => Rates.FirstOrDefault(p=>p.Currency==Currency);
    public static void Add(Valuutta valuutta){
        valuutta.ID=Guid.NewGuid();
        Rates.Add(valuutta);
    }
    public static void Delete(string Currency){
        var valuutta=Get(Currency);
        if (valuutta is null)
        return;

        Rates.Remove(valuutta);
    }

    public static void Update(Valuutta valuutta){
        var index= Rates.FindIndex(p=>p.Currency==valuutta.Currency);
        if(index== -1)
        return;

        Rates[index]= valuutta;
    }
}