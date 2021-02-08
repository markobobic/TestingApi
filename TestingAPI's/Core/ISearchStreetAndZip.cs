namespace TestingAPI_s.Factory
{
    public interface ISearchStreetAndZip
    {
        string GetStateSearchByStreetAndZip(string street, string zipCode);
        (bool isValid, string accuracy) ValidateStreetAndZip(string street, string zipCode);
    }
}
