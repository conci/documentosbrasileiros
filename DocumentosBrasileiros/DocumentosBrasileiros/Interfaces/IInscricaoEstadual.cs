using DocumentosBrasileiros.Enums;

namespace DocumentosBrasileiros.Interfaces
{
    public interface IInscricaoEstadual
    {
        UfEnum UfEnum { get; }

        int Tamanho { get; }

        bool Validar(string inscricaoEstadual);
        string GerarFake();
    }
}