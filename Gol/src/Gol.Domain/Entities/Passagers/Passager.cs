using Gol.Domain.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Passagers
{
    public class Passager : Entity<Passager>
    {
        #region [ Constructors ]

        public Passager(string name, string type, string seat, Guid idAirplane)
        {
            Id = Guid.NewGuid();
            Name = name;
            Type = type;
            Seat = seat;
            IdAirplane = idAirplane;
        }

        private Passager()
        {
        }

        #endregion [ Constructors ]

        #region [ Properties ]

        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Seat { get; private set; }

        #endregion [ Properties ]

        #region [ FK ]

        public virtual Guid? IdAirplane { get; private set; }

        #endregion [ FK ]

        #region [ Methods ]
        public Passager SetAirplane(Guid? idAirplane)
        {
            //Caso precise de regras, lembre-se de verificar se é melhor ter um serviço de dominio 
            IdAirplane = idAirplane;
            return this;
        }

        public override bool Valido()
        {
            PassagerValidation objValidate = new PassagerValidation();

            bool Valido = objValidate.Valido(this);
            ValidationErro = objValidate.ValidationErro;

            return Valido;
        }

        #endregion [ Methods ]

        #region [ Factory ]

        public static class PassagerFactory
        {
            public static Passager Passager(Guid id, string name, string type, string seat)
            {
                Passager passager = new Passager()
                {
                    Id = id,
                    Name = name,
                    Type = type,
                    Seat = seat
                };

                return passager;
            }

            public static Passager PassagerWithAirplane(Guid id, string name, string type, string seat, Guid? idAirplane)
            {
                Passager passager = new Passager()
                {
                    Id = id,
                    Name = name,
                    Type = type,
                    Seat = seat,
                    IdAirplane = idAirplane,
                };

                return passager;
            }
        }
        #endregion [ Factory ]
    }
}
