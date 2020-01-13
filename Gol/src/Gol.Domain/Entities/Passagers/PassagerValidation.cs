using FluentValidation;
using FluentValidation.Results;
using Gol.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gol.Domain.Entities.Passagers
{
    internal class PassagerValidation 
    {
        #region [ Propeties ]

        [Description("IGNORE")]
        public List<string> ValidationErro { get; protected set; }

        #endregion [ Propeties ]


        #region [ Methods ]

        public bool Valido(Passager objValidar)
        {
            ValidationErro = new List<string>();

            ValidateName(objValidar);
            ValidateType(objValidar);

            return ValidationErro.Count == 0;
        }

        #endregion [ Methods ]

        #region [ Methods Private ]

        private void ValidateName(Passager passager)
        {
            if (string.IsNullOrEmpty(passager.Name))
            {
                ValidationErro.Add(Messages.MSG_PASSAGER_NAME_NULL);
                return;
            }

            if (passager.Name.Length <= 2 && passager.Name.Length >= 50)
            {
                ValidationErro.Add(Messages.MSG_PASSAGER_NAME_MIN_MAX);
                return;
            }
        }
        private void ValidateType(Passager passager)
        {

            if (string.IsNullOrEmpty(passager.Type))
            {
                ValidationErro.Add(Messages.MSG_PASSAGER_TYPE_NULL);
                return;
            }

            if (passager.Type.Length <= 2 && passager.Type.Length >= 50)
            {
                ValidationErro.Add(Messages.MSG_PASSAGER_TYPE_MIN_MAX);
                return;
            }
        }

        #endregion [ Methods Private ]
    }
}
