using System;
using System.ComponentModel.DataAnnotations;
using LprServer;

namespace Lpr4dev.DbModel
{
    public class Mailbox
    {
        public Mailbox()
        {

        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
