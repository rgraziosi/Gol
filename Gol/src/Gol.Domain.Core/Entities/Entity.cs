using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gol.Domain.Core.Entites
{
    public abstract class Entity<T> 
    {
        #region [ Constructos ]

        protected Entity()
        {
            ValidationErro = new List<string>();
        }

        #endregion [ Constructos ]

        #region [ Propreties ]

        // set protected - para ser somente modificado pela classe que herda da mesma
        public Guid Id { get; protected set; }

        public DateTime? DateInsert { get; protected set; }

        public DateTime? DateUpdate { get; protected set; }

        [Description("IGNORE")]
        public List<string> ValidationErro { get; set; }


        #endregion [ Propreties ]

        #region [ Methos Abstract ]

        public abstract bool Valido();

        #endregion [ Methos Abstract ]

        #region [ Methods ]

        public void SetDateInsert()
        {
            DateInsert = DateTime.Now;
            DateUpdate = null;
        }
        public void SetDateUpdate()
        {
            DateUpdate = DateTime.Now;
        }

        // Sobrepondo o método Equals pois o metodo base compara os tipos entre duas instancias, e o que queremos é comparar duas instancias por seu ID
        public override bool Equals(object obj)
        {
            // O meu objeto sempre vai ser uma Entity
            var compareTo = obj as Entity<T>;

            // Se o objeto for comparevel com Entity, retonar true
            if (ReferenceEquals(this, compareTo)) return true;

            // Se o objeto for comparado com null, retorna false
            if (ReferenceEquals(null, compareTo)) return false;

            // Caso o seja necessario comparar por Id, mesmo que não seja a mesma instancia de objeto
            return Id.Equals(compareTo.Id);
        }

        // Override de operadores
        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            // Verifica se as duas podem ser comparadas com nulo, retorna true
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            // Caso não seja possivel  comparar com nulo, retorna false
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            //Se não conseguir comparar, ele vai chamar o novo metodo Equals que compara pelo Id
            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            // Magic string 42, resposta pra tudo  - "Mochileiro"
            // Para criar um valor único para cada Entity, e quando comparar vc ter certeza que está falando da mesma Entity, não apenas uma instancia e sim a linha da tabela no banco
            return (GetType().GetHashCode() * 42) + Id.GetHashCode();
        }

        // Toda vez que eu der um toString de uma determinda entity, vai retornar o nome + id, para futura analise de LOG
        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + " ] ";
        }

        #endregion [ Methods ]
    }
}