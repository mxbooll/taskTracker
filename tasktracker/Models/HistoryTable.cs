//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

namespace tasktracker.Models
{
    [ExcludeFromCodeCoverage]
    public partial class HistoryTable
    {
        public int ID { get; set; }
        public int Story_id { get; set; }
        public string Status { get; set; }
        public System.DateTime Time_enter { get; set; }
        public string Comment { get; set; }
    }
}
