public class FakeCache : ICache
{
    public void SalvarRestricaoCache(string cpf, bool? possuiRestricao)
    {
        return;
    }

    public bool? BuscarRestricaoCache(string cpf)
    {
        return false;
    }
}