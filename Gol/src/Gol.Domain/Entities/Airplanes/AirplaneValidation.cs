using Gol.Domain.Core.Entites;
using FluentValidation;
using FluentValidation.Results;
using Gol.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gol.Domain.Entities.Airplanes
{
    internal class AirplaneValidation
    {
        #region [ Propeties ]

        [Description("IGNORE")]
        public List<string> ValidationErro { get; protected set; }

        #endregion [ Propeties ]

        #region [ Methods ]

        public bool Valido(Airplane objValidar)
        {
            ValidationErro = new List<string>();

            ValidateName(objValidar);
            ValidateType(objValidar);
            
            return ValidationErro.Count == 0;
        }

        #endregion [ Methods ]

        #region [ Methods Private ]

        private void ValidateName(Airplane airplane)
        {
            if (string.IsNullOrEmpty(airplane.Name))
            {
                ValidationErro.Add(Messages.MSG_AIRPLANE_NAME_NULL);
                return;
            }

            if (airplane.Name.Length <= 2 && airplane.Name.Length >= 50)
            {
                ValidationErro.Add(Messages.MSG_AIRPLANE_NAME_MIN_MAX);
                return;
            }
        }
        private void ValidateType(Airplane airplane)
        {

            if (string.IsNullOrEmpty(airplane.Type))
            {
                ValidationErro.Add(Messages.MSG_AIRPLANE_TYPE_NULL);
                return;
            }

            if (airplane.Type.Length <= 2 && airplane.Type.Length >= 50)
            {
                ValidationErro.Add(Messages.MSG_AIRPLANE_TYPE_MIN_MAX);
                return;
            }
        }

        #endregion [ Methods Private ]
    }
}
