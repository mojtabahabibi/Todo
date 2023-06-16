using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.Common
{
    public class BaseDomainEntity
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastModifiedBy { get;set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set;} = DateTime.Now;
    }
}
