﻿using DocumentosBrasileiros.Enums;
using DocumentosBrasileiros.Helpers;
using DocumentosBrasileiros.Interfaces;
using System;

namespace DocumentosBrasileiros.IE
{
    public class RioDeJaneiro : IInscricaoEstadual
    {
        public UfEnum UfEnum => UfEnum.RJ;

        public int Tamanho => 8;

        private readonly int[] peso = { 2, 7, 6, 5, 4, 3, 2 };
        public bool Validar(string inscricaoEstadual)
        {
            if (inscricaoEstadual.Length != Tamanho) return false;

            string inscricaoSemDigito = inscricaoEstadual.Substring(0, 7);

            return inscricaoEstadual ==
            inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso).ToString();
        }

        public string GerarFake()
        {
            string inscricaoSemDigito = "";
            Random rnd = new Random();
            for (int i = 0; i < 7; i++)
            {
                inscricaoSemDigito += rnd.Next(0, 9).ToString();
            }

            return inscricaoSemDigito + new DigitoVerificador().ObterDigitoMod11(inscricaoSemDigito, peso);
        }

    }
}
