//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KamilSafiullin320_EducationalPractice.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Academician
    {
        public int Id_academician { get; set; }
        public string FIO { get; set; }
        public Nullable<System.DateTime> Birthdate { get; set; }
        public string Specialization { get; set; }
        public Nullable<int> Year_rank { get; set; }
    }
}