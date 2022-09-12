namespace regras_encadeadas.Controllers;

public class ProvedorSerasa : IProvedorSerasa
{
    public bool PossuiRestriacao(string cpf)
    {
        return false;
    }
}