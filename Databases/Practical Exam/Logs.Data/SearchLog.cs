using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logs.Data
{
    public class SearchLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SearchLogId { get; set; }

        public DateTime Date { get; set; }

        public string QueryXml { get; set; }
    }
}
