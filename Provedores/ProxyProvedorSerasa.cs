public class ProxyProvedorSerasa : IProvedorSerasa
{
    private IProvedorSerasa _provedorSerasa;

    public ProxyProvedorSerasa(IProvedorSerasa provedorSerasa)
    {
        _provedorSerasa = provedorSerasa;
    }

    public bool PossuiRestriacao(string cpf)
    {
        var possuiRestricao = BuscarRestricaoCache(cpf);

        if (possuiRestricao != null)
        {
            return possuiRestricao.Value;
        }

        possuiRestricao = _provedorSerasa.PossuiRestriacao(cpf);

        SalvarRestricaoCache(cpf, possuiRestricao);

        return possuiRestricao.Value;
    }

    private void SalvarRestricaoCache(string cpf, bool? possuiRestricao)
    {
        return;
    }

    private bool? BuscarRestricaoCache(string cpf)
    {
        return false;
    }
}