using System.Xml.Serialization;
// serializer
XmlSerializer serializer = new(typeof(osoba));
// serializacja
Stream plikSerial = new FileStream("test.xml", FileMode.Create);

osoba doPliku = new();
doPliku.imie = "Artur";
doPliku.nazwisko = "Borkowski";
doPliku.pesel = 12345678910;

osobaAdres adres1 = new();
adres1.ulica = "aleja Grunwaldzka";
adres1.nrDomu = "238A";
adres1.nrLokalu = "B103";
adres1.miejscowosc = "Gdańsk";

osobaAdres adres2 = new();
adres2.ulica = "ul. Śląska";
adres2.nrDomu = "35";
adres2.nrLokalu = "37";
adres2.miejscowosc = "Gdynia";

osobaAdres[] adresy = { adres1, adres2 };
doPliku.adresy = adresy;

serializer.Serialize(plikSerial, doPliku);
plikSerial.Close();

// deserializacja
Stream plikDeserial = new FileStream("test.xml", FileMode.Open);
osoba? zPliku;

zPliku = serializer.Deserialize(plikDeserial) as osoba;

if (zPliku != null)
{
    Console.WriteLine($"Osoba: {zPliku.imie} {zPliku.nazwisko} ({zPliku.pesel}), adresy:");
    foreach (var item in zPliku.adresy)
    {
        Console.WriteLine($" - {item.miejscowosc}, {item.ulica} {item.nrDomu}/{item.nrLokalu}");
    }
}
plikDeserial.Close();
