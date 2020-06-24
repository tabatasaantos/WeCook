using System;

namespace WeCook.Domain.Base
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            IncluidoEm = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime IncluidoEm { get; private set; }
    }
}
