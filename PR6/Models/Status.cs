//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PR6.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Status
    {
        public int id { get; set; }
        public Nullable<int> Worker_id { get; set; }
        public Nullable<int> Salaries_id { get; set; }
        public Nullable<double> accrued { get; set; }
        public Nullable<double> Withheld { get; set; }
        public Nullable<double> payable { get; set; }
    
        public virtual Salaries Salaries { get; set; }
        public virtual Workers Workers { get; set; }
    }
}