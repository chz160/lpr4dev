﻿using System;
using System.Collections.Generic;
using MimeKit;
using Lpr4dev.DbModel;

namespace Lpr4dev.Server
{
    public class RelayRecipientResult
    {
        public string Email { get; set; }
        public DateTime RelayDate { get; set; }
    }

    public class RelayResult
    {
        public RelayResult()
        {
        }

        public Dictionary<MailboxAddress, Exception> Exceptions { get; set; } = new Dictionary<MailboxAddress, Exception>();
        public List<RelayRecipientResult> RelayRecipients { get; set; } = new List<RelayRecipientResult>();
        public bool WasRelayed => RelayRecipients.Count > 0;
    }
}