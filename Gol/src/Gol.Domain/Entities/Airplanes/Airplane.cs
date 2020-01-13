using Gol.Domain.Core.Entites;
using Gol.Domain.Entities.Passagers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Airplanes
{
    public class Airplane : Entity<Airplane>
    {
        #region [ Constructors ]

        public Airplane(Guid id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
        public Airplane(string name, string type)
        {
            Id = Guid.NewGuid();
            Name = name;
            Type = type;
        }

        private Airplane()
        {
        }

        #endregion [ Constructors ]

        #region [ Properties ]

        public string Name { get; private set; }
        public string Type { get; private set; }

        #endregion [ Properties ]


        #region [ Methods ]

        public override bool Valido()
        {
            AirplaneValidation objValidate = new AirplaneValidation();

            bool Valido = objValidate.Valido(this);
            ValidationErro = objValidate.ValidationErro;

            return Valido;
        }

        #endregion [ Methods ]

        #region [ Factory ]

        #endregion [ Factory ]
    }
}
