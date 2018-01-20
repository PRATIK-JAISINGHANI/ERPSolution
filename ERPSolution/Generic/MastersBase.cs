using ERPSolution.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using ERPSolution.Common;

namespace ERPSolution.Models
{
    public abstract class MastersBase : EntityBase
    {
        #region Constructor

        public MastersBase()
            : base()
        {
            Init();
        }

        public MastersBase(Guid Id)
            : base()
        {
        }

        #endregion

        #region Properties 

        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }

        #endregion

        #region Private Methods

        private void Init()
        {
            if (EntityBase.ERPContext.Entry(this).State == EntityState.Detached)
            {
                Id = Guid.NewGuid();
                CreatedBy = Guid.NewGuid();
                CreatedDateTime = DateTime.Now;
            }
        }

        protected virtual object GetEntity(Guid id)
        {
            return EntityBase.ERPContext.Set(this.GetType()).Find(id);
        }

        #endregion

        #region Public Methods

        public virtual bool SaveAll()
        {
            return DbHelper.SaveAll(this.GetType(), this);
        }

        public virtual bool DeleteAll()
        {
            return DbHelper.DeleteAll(this.GetType(), this);
        }

        #endregion
    }
}