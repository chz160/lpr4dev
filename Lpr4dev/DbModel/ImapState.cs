using System;
using System.ComponentModel.DataAnnotations;

namespace Lpr4dev.DbModel
{
    public class ImapState
    {
        [Key]
        public Guid Id { get; set; }

        public long LastUid { get; set; }
    }
}
