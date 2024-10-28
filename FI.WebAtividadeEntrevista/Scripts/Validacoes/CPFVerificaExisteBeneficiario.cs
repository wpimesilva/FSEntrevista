﻿using FI.AtividadeEntrevista.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace WebAtividadeEntrevista.Models.Validations
{
    public sealed class CPFVerificaExisteBeneficiario : ValidationAttribute, IClientValidatable
    {
        public CPFVerificaExisteBeneficiario() { }

        public override bool IsValid(object value)
        {
            if (value is null || string.IsNullOrEmpty(value.ToString()))
                return false;

            var result = VerificaExistenciaBanco(value.ToString());

            return result;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = this.FormatErrorMessage(null),
                ValidationType = "CPFVerificaExisteBeneficiario"
            };
        }

        private static bool VerificaExistenciaBanco(string cpf)
        {
            var result = BoBeneficiario.VerificarExistencia(cpf);

            return !result;
        }
    }
}