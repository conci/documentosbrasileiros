﻿using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using DocumentosBrasileiros.Interfaces;
using System;

namespace DocumentosBrasileiros.IE
{
    public class Roraima : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.RR;

        public int Tamanho => 9;

        private readonly int[] _peso = { 1, 2, 3, 4, 5, 6, 7, 8 };
        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != Tamanho || !inscricaoEstadual.StartsWith("24")) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 8);

            return inscricaoEstadual ==
            inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod9(inscricaoSemDigito, _peso).ToString();
        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "24";
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            return inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod9(inscricaoSemDigito, _peso);
        }

    }
}
