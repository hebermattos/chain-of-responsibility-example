public class ProxyProvedorSerasa : IProvedorSerasa
{
    private IProvedorSerasa _provedorSerasa;
    private readonly ICache _cache;

    public ProxyProvedorSerasa(ICache cache, IProvedorSerasa provedorSerasa)
    {
        _provedorSerasa = provedorSerasa;
        _cache = cache;
    }

    public bool PossuiRestriacao(string cpf)
    {
        var possuiRestricao = _cache.BuscarRestricaoCache(cpf);

        if (possuiRestricao != null)
        {
            return possuiRestricao.Value;
        }

        possuiRestricao = _provedorSerasa.PossuiRestriacao(cpf);

        _cache.SalvarRestricaoCache(cpf, possuiRestricao);

        return possuiRestricao.Value;
    }
}